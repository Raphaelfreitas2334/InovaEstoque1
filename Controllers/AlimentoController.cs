﻿using ControleContatos.Repositorio;
using ControleDeContatos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public AlimentoController(IAlimentoRepositorio alimento,
                                  ISessao sessao,
                                  IFornecedorRepositorio fornecedor) 
        {
            _alimentoRepositorio = alimento;
            _fornecedorRepositorio = fornecedor;
            _sessao = sessao;
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
            ViewBag.Alimentos = new SelectList(_fornecedorRepositorio.ObterTodos(), "nomeFornecedor", "nomeFornecedor");
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

        public IActionResult viewEstoque()
        {
            List<AlimentoModel> alimentosEstoque = _alimentoRepositorio.BuscarAlimentos();
            return PartialView(alimentosEstoque);
        }


        //os metodos listados abaixo, serão usados para operações dentro do banco
        [HttpPost]
        public IActionResult CadastrarAlimento(AlimentoModel alimento)
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
                        TempData["ERRO"] = "Você não pode cadastrar uma quantidades menor que a quantidade minina!";
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

                        alimento.FornecedorNome = alimento.FornecedorNome;
                        alimento.IDusuario = usuarioLogago.Id;
                        alimento.UsuarioNome = usuarioLogago.NomeUsuario;
                        alimento = _alimentoRepositorio.AdicionarAlimento(alimento);
                        TempData["SUCESSO"] = "Alimento Cadastrado com sucesso!";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["ERRO"] = "Não foi possivel cadastra, Lenbre-se cadastre todos campos";
                    return RedirectToAction("Index");
                }

            }
            catch (System.Exception erro)
            {
                TempData["ERRO"] = $"Alimento cadastrado com sucesso! tetalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult SaidaDeAlimento(AlimentoModel alimento)
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
                        alimento.IDusuario = usuarioLogago.Id;
                        alimento.UsuarioNome = usuarioLogago.NomeUsuario;
                        alimento = _alimentoRepositorio.gerarSaidaAlimento(alimento);
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
                TempData["ERRO"] = $"Não foi possivel gerar a saida deste alimento! tetalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarAlimento(AlimentoModel alimento)
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
                        alimento.IDusuario = usuarioLogago.Id;
                        alimento.UsuarioNome = usuarioLogago.NomeUsuario;
                        alimento = _alimentoRepositorio.editarAlimento(alimento);
                        TempData["SUCESSO"] = "Alimento editado com sucesso!";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
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

        public IActionResult DeletarAlimento(int id)
        {
            try
            {
                bool alimentoRetur = _alimentoRepositorio.excluirAlimento(id);
                if (alimentoRetur)
                {
                    TempData["SUCESSO"] = "Alimento Excluido com sucesso!";
                }
                else
                {
                    TempData["ERRO"] = "Não foi possivel Excluir este alimento! Deixe todos os campos preenchidos";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["ERRO"] = $"Não foi possivel Excluir este alimento! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }   
        }
    }
}
