using ControleContatos.Repositorio;
using ControleDeContatos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Filters;
using WebApplication1.helper;
using WebApplication1.Models;
using WebApplication1.repositorio;


namespace WebApplication1.Controllers
{
    [PaginaParaUsuarioLogado]
    public class AlimentoController : Controller
    {
        private readonly IAlimentoRepositorio _alimentoRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly ISessao _sessao;
        private readonly ILogRepositorio _logRepositorio;
        private readonly IFornecimentosRepositorio _fornecimentosRepositorio;
        private readonly BancoContext _bancoContext;

        public AlimentoController(IAlimentoRepositorio alimento,
                                  ISessao sessao,
                                  IFornecedorRepositorio fornecedor,
                                  BancoContext bancoContext,
                                  ILogRepositorio logRepositorio,
                                  IFornecimentosRepositorio fornecimentosRepositorio)
        {
            _alimentoRepositorio = alimento;
            _fornecedorRepositorio = fornecedor;
            _sessao = sessao;
            _bancoContext = bancoContext;
            _logRepositorio = logRepositorio;
            _fornecimentosRepositorio = fornecimentosRepositorio;
        }

        public IActionResult ExibirBotoesAlimento()
        {
            return View("_ExibirBotoesAlimento");
        }
        public class SeuViewModel
        {
            public int CategoriaId { get; set; } = 1;
            public List<AlimentoModel> Categorias { get; set; }
        }
        public IActionResult MinhaAcao()
        {
            ViewBag.Alimentos = new SelectList(_alimentoRepositorio.ObterTodos(), "Id", "nomeAlimento");
            return View();
        }
        public IActionResult Index()
        {
            
            List<AlimentoModel> alimentos = _alimentoRepositorio.BuscarAlimentos();
            return View(alimentos);
        }
        public IActionResult viewImprimirAcabando()
        {
            List<AlimentoModel> alimentos = _alimentoRepositorio.BuscarAlimentos();
            return View(alimentos);
        }
        public IActionResult viewImprimirVencendo()
        {
            List<AlimentoModel> alimentos = _alimentoRepositorio.BuscarAlimentos();
            return View(alimentos);
        }
        [HttpPost]
        public IActionResult Index(string valorSelecionado)
        {
            // Armazene o valor de alguma forma que possa ser acessado pela sua View
            ViewBag.ValorSelecionado = valorSelecionado;

            return View();
        }
        public IActionResult viewCadastrarAlimento()
        {
            var fornecedores = _fornecedorRepositorio.ObterTodos();

            if (fornecedores == null)
            {
                throw new InvalidOperationException("O método ObterTodos retornou null.");
            }

            var fornecedorSelectList = fornecedores.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.nomeFornecedor
            }).ToList();

            ViewBag.Alimentos = fornecedorSelectList;
            return PartialView("_viewCadastrarAlimento");
        }
        public IActionResult viewEditarAlimento(int id)
        {
            
            AlimentoModel alimentoPorID = _alimentoRepositorio.listarPorID(id);
            return PartialView("_viewEditarAlimento",alimentoPorID);
        }
        public IActionResult viewListarAlimentoAcabando()
        {
            List<AlimentoModel> alimentos = _alimentoRepositorio.BuscarAlimentos();
            return PartialView("_viewListarAlimentoAcabando", alimentos);
        }
        public IActionResult viewListarAlimentoVencendo()
        {
            List<AlimentoModel> alimentos = _alimentoRepositorio.BuscarAlimentos();
            return PartialView("_ViewListarAlimentoVencendo", alimentos);
        }
        public IActionResult viewExcluirAlimento(int id)
        {
            AlimentoModel alimentoPorID = _alimentoRepositorio.listarPorID(id);
            return PartialView("_viewExcluirAlimento",alimentoPorID);
        }
        public IActionResult viewLogDeCadastro(int id)
        {
            AlimentoModel alimentoPorID = _alimentoRepositorio.listarPorID(id);
            return PartialView("_viewLogDeCadastro", alimentoPorID);
        }
        public IActionResult viewLogDeRetidada(int id)
        {
            AlimentoModel alimentoPorID = _alimentoRepositorio.listarPorID(id);
            return PartialView("_viewLogDeRetidada", alimentoPorID);
        }
        public IActionResult viewLogDeDevolucao(int id)
        {
            AlimentoModel alimentoPorID = _alimentoRepositorio.listarPorID(id);
            return PartialView("_viewLogDeDevolucao", alimentoPorID);
        }

        public IActionResult viewSaidaAlimento(int id)
        {
            AlimentoModel alimentoPorID = _alimentoRepositorio.listarPorID(id);
            alimentoPorID.quantidadeRetirada = 0;
            return PartialView("_viewSaidaAlimento",alimentoPorID);
        }
        public IActionResult viewDevolveAlimento(int id)
        {
            AlimentoModel alimentoPorID = _alimentoRepositorio.listarPorID(id);
            return PartialView("_viewDevolveAlimento", alimentoPorID);
        }
        public IActionResult viewEstoque()
        {
            List<AlimentoModel> alimentosEstoque = _alimentoRepositorio.BuscarAlimentos();
            return PartialView(alimentosEstoque);
        }


        //os metodos listados abaixo, serão usados para operações dentro do banco
        [HttpPost]
        public IActionResult CadastrarAlimento(AlimentoModel alimento)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (alimento.quantidadeAtual < 1 || alimento.quantidadeMaxima < 1 || alimento.quantidadeMinima < 1)
                        {
                            TempData["ERRO"] = "Você não pode cadastrar quantidades menores que zero!";
                            return RedirectToAction("Index");
                        }
                        if (alimento.quantidadeAtual < alimento.quantidadeMinima)
                        {
                            TempData["ERRO"] = "Você não pode cadastrar uma quantidades menor que a quantidade minima!";
                            return RedirectToAction("Index");
                        }
                        if (alimento.quantidadeAtual > alimento.quantidadeMaxima)
                        {
                            TempData["ERRO"] = "Você não pode cadastrar quantidades maior que a quantidade maxima!";
                            return RedirectToAction("Index");
                        }

                        // Cadastro do alimento
                        UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                        
                        alimento = _alimentoRepositorio.AdicionarAlimento(alimento);

                        // Verificar se o alimento foi adicionado com sucesso
                        if (alimento.Id == 0)
                        {
                            throw new InvalidOperationException("Erro ao adicionar o alimento.");
                        }

                        // Buscar informações do fornecedor
                        FornecedorModel fornecedor = _fornecedorRepositorio.ObterPorI(alimento.FornecedorId);

                        // Verificar se o fornecedor foi encontrado
                        if (fornecedor != null)
                        {
                            // Criar objeto fornecimentos e atribuir informações do fornecedor
                            FornecimentosModel fornecimentos = new FornecimentosModel
                            {
                                IdFornecedor = fornecedor.Id,
                                NomeFornecedor = fornecedor.nomeFornecedor,
                                CNPJ = fornecedor.CNPJ,
                                Telefone = fornecedor.telefone,
                                CEP = fornecedor.CEP,
                                NumeroResidencia = fornecedor.numeroResidencia,
                                IdAlimento = alimento.Id, // Certifique-se de que o ID do alimento está sendo usado corretamente
                                NomeAlimento = alimento.nomeAlimento,
                                DataVencimento = alimento.dataVencimento,
                                UnidadeMedida = alimento.unidadeMedida,
                                QuantidadeFornecida = alimento.quantidadeAtual
                            };

                            _fornecimentosRepositorio.Adicionar(fornecimentos);

                            // Cadastro do log
                            LogsModel log = new LogsModel();
                            log.IdAlimento = alimento.Id; // Supondo que o ID do alimento seja gerado automaticamente após o cadastro
                            log.NomeAlimeto = alimento.nomeAlimento;
                            log.DataCadastro = DateTime.Now;
                            log.UsuarioCadastrou = usuarioLogado.NomeUsuario;
                            log.QuantidadeAlimento = alimento.quantidadeRetirada;
                            log.IdUsuario = usuarioLogado.Id;
                            _logRepositorio.LogCadastro(log);

                            transaction.Commit(); // Confirma a transação se tudo foi bem-sucedido

                            TempData["SUCESSO"] = "Alimento cadastrado com sucesso!";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // Recarregar a lista de fornecedores se o modelo for inválido
                            var fornecedores = _fornecedorRepositorio.ObterTodos();
                            var fornecedorSelectList = fornecedores.Select(f => new SelectListItem
                            {
                                Value = f.Id.ToString(),
                                Text = f.nomeFornecedor
                            }).ToList();
                            ViewBag.Alimentos = fornecedorSelectList;
                            transaction.Rollback(); // Reverte a transação em caso de erro
                            TempData["ERRO"] = "Não foi possível cadastrar. Lembre-se de preencher todos os campos.";
                            return RedirectToAction("Index");
                        }
                      
                    }
                    return RedirectToAction("Index");
                }
                catch (System.Exception erro)
                {
                    transaction.Rollback(); // Reverte a transação em caso de erro
                    TempData["ERRO"] = $"Não foi possível cadastrar o alimento. Detalhes do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public IActionResult SaidaDeAlimento(AlimentoModel alimento)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (alimento.quantidadeRetirada < 1 || alimento.nomeAlimento == null)
                        {
                            TempData["ERRO"] = "Você não pode gerar saida quantidades menores que zero!";
                            return RedirectToAction("Index");
                        }
                        if (alimento.quantidadeRetirada > alimento.quantidadeAtual)
                        {
                            TempData["ERRO"] = "Você não pode fazer uma retirada que seja maior que a quantidade atual do alimento no estoque!";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            UsuarioModel usuarioLogago = _sessao.BuscarSessaoDoUsuario();
                            
                            string obs = alimento.obsDeSaida;
                            alimento = _alimentoRepositorio.gerarSaidaAlimento(alimento);

                            
                            // Cadastro do log
                            LogsModel log = new LogsModel();
                            log.IdAlimento = alimento.Id; // Supondo que o ID do alimento seja gerado automaticamente após o cadastro
                            log.NomeAlimeto = alimento.nomeAlimento;
                            log.UsuarioRetirou = usuarioLogago.NomeUsuario;
                            log.DataRetira = DateTime.Now;
                            log.QuantidadeAlimento = alimento.quantidadeRetirada;
                            log.obsDeSaida = obs;
                            _logRepositorio.LogRetirada(log);

                            transaction.Commit(); // Confirma a transação se tudo foi bem-sucedido

                            TempData["SUCESSO"] = "Saida gerada com Sucesso!";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["ERRO"] = "Não foi possivel gerar a saida deste alimento! Deixe todos os campos preenchidos";
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Exception erro)
                {
                    transaction.Rollback(); // Reverte a transação em caso de erro
                    TempData["ERRO"] = $"Não foi possivel gerar a saida deste alimento! tetalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
                
        }

        [HttpPost]
        public IActionResult DevolveDeAlimento(AlimentoModel alimento)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        UsuarioModel usuarioLogago = _sessao.BuscarSessaoDoUsuario();
                        
                        string obs = alimento.obsDeDevolucao;
                        double? qtdDevolve = alimento.quantidadeDevolvida;
                        alimento = _alimentoRepositorio.gerarDevolveAlimento(alimento);

                        // Cadastro do log
                        LogsModel log = new LogsModel();
                        log.IdAlimento = alimento.Id; // Supondo que o ID do alimento seja gerado automaticamente após o cadastro
                        log.NomeAlimeto = alimento.nomeAlimento;
                        log.UsuarioDevolvel = usuarioLogago.NomeUsuario;
                        log.DataDevolve = DateTime.Now;
                        log.QuantidadeAlimento = qtdDevolve;
                        log.obsDeDevolucao = obs;
                        _logRepositorio.LogRetirada(log);

                        transaction.Commit(); // Confirma a transação se tudo foi bem-sucedido

                        TempData["SUCESSO"] = "Devolução gerada com Sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ERRO"] = "Não foi possivel gerar a Devolução deste alimento! Deixe todos os campos preenchidos";
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Exception erro)
                {
                    transaction.Rollback(); // Reverte a transação em caso de erro
                    TempData["ERRO"] = $"Não foi possivel gerar a Devolução deste alimento! tetalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
                
        }

        [HttpPost]
        public IActionResult EditarAlimento(AlimentoModel alimento)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (alimento.quantidadeAtual < 1 || alimento.quantidadeMaxima < 1 || alimento.quantidadeMinima < 1)
                        {
                            TempData["ERRO"] = "Você não pode cadastrar quantidades menores que zero!";
                            return RedirectToAction("Index");
                        }
                        if (alimento.quantidadeAtual > alimento.quantidadeMaxima)
                        {
                            TempData["ERRO"] = "Você não pode cadastrar quantidades maior que a quantidade maxima!";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            UsuarioModel usuarioLogago = _sessao.BuscarSessaoDoUsuario();
                           
                            double? qtdDevolve = alimento.quantidadeAtual;
                            alimento = _alimentoRepositorio.editarAlimento(alimento);

                            //editando o fornecimento pois não é possivel faze em cascata como o delete
                            FornecimentosModel fornecimentos = new FornecimentosModel
                            {
                                IdAlimento = alimento.Id,
                                NomeAlimento = alimento.nomeAlimento,
                                DataVencimento = alimento.dataVencimento,
                                UnidadeMedida = alimento.unidadeMedida,
                                QuantidadeFornecida = alimento.quantidadeAtual
                            };

                            _fornecimentosRepositorio.Atualizar(fornecimentos);

                            // Cadastro do log
                            LogsModel log = new LogsModel();
                            log.IdAlimento = alimento.Id; // Supondo que o ID do alimento seja gerado automaticamente após o cadastro
                            log.NomeAlimeto = alimento.nomeAlimento;
                            log.UsuarioEditou = usuarioLogago.NomeUsuario;
                            log.DataAtualizacao = DateTime.Now;
                            log.QuantidadeAlimento = qtdDevolve;
                            _logRepositorio.LogRetirada(log);

                            transaction.Commit(); // Confirma a transação se tudo foi bem-sucedido

                            TempData["SUCESSO"] = "Alimento editado com sucesso!";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        transaction.Rollback(); // Reverte a transação em caso de erro
                        TempData["ERRO"] = "Não foi possivel editar este alimento! Deixe todos os campos preenchidos";
                        return RedirectToAction("Index");
                    }
                }
                catch (System.Exception erro)
                {
                    TempData["ERRO"] = $"Não foi possivel editar este alimento! tetalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }
        }

        public IActionResult DeletarAlimento(int id, string nome, double qtd)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            {
                try
                {

                    UsuarioModel usuarioLogago = _sessao.BuscarSessaoDoUsuario();
                    int IDusuario = usuarioLogago.Id;

                    int idexclucao = id;
                    string NomeAli = nome;
                    double qtdAli = qtd;

                    // Cadastro do log
                    LogsModel log = new LogsModel();
                    log.IdAlimento = idexclucao; // Supondo que o ID do alimento seja gerado automaticamente após o cadastro
                    log.NomeAlimeto = NomeAli;
                    log.UsuarioRemovel = usuarioLogago.NomeUsuario;
                    log.QuantidadeAlimento = qtdAli;
                    log.DataRemovel = DateTime.Now;
                    log.IdUsuario = usuarioLogago.Id;
                    _logRepositorio.LogRetirada(log);


                    bool alimentoRetur = _alimentoRepositorio.excluirAlimento(id);

                    transaction.Commit(); // Confirma a transação se tudo foi bem-sucedido

                    if (alimentoRetur)
                    {
                        TempData["SUCESSO"] = "Alimento Excluido com sucesso!";
                    }
                    else
                    {
                        transaction.Rollback(); // Reverte a transação em caso de erro
                        TempData["ERRO"] = "Não foi possivel Excluir este alimento! Deixe todos os campos preenchidos";
                    }
                    return RedirectToAction("Index");
                }
                catch (System.Exception erro)
                {
                    transaction.Rollback(); // Reverte a transação em caso de erro
                    TempData["ERRO"] = $"Não foi possivel Excluir este alimento! Detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
                }
            }

        }
    }
}
