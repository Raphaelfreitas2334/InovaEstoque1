// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    getDatatable('#table-contatos');
    getDatatable('#usuario-table');
    getDatatable('#table-Fornecedor');
    getDatatable('#table-alimento');
    getDatatable('#table-Vencendo');

    //modais da tela de usuario <começo>

    $(document).on('click', '.btn-Modal-Editar-Usuario', function () {
        var usuarioid = $(this).attr('usuario-id');

        $.ajax({
            type: 'GET',
            url: '/Usuario/Editar/' + usuarioid,
            success: function (result) {
                $('#EditarUsuario').html(result);
                $('#ModalEditarUsuario').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Criar-Usuario', function () {

        $.ajax({
            type: 'GET',
            url: '/Usuario/Criar/',
            success: function (result) {
                $('#CriarUsuario').html(result);
                $('#ModalCriarUsuario').modal();
            }
        });
    });

    //modais da tela de usuario <Fim>

    //modais da tela de fornecedor <começo>
    $(document).on('click', '.btn-Modal-Criar-Fornecedor', function () {

        $.ajax({
            type: 'GET',
            url: '/Fornecedor/Criar/',
            success: function (result) {
                $('#CriaFornecedor').html(result);
                $('#ModalCriarFornecedor').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Editar-Fornecedor', function () {
        var fornecedorid = $(this).attr('fornecedor-id');

        $.ajax({
            type: 'GET',
            url: '/Fornecedor/EditarView/' + fornecedorid,
            success: function (result) {
                $('#EditarFornecedor').html(result);
                $('#ModalEditarFornecedor').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Apagar-Fornecedor', function () {
        var fornecedorid = $(this).attr('fornecedor-id');

        $.ajax({
            type: 'GET',
            url: '/Fornecedor/ApagarConfirmacao/' + fornecedorid,
            success: function (result) {
                $('#ApagarFornecedor').html(result);
                $('#ModalApagarFornecedor').modal();
            }
        });
    });

    //modais da tela de Fornecedor <Fim>

    //modais da tela de Alimentos <Começo>
    $(document).on('click', '.btn-Modal-Criar-Alimento', function () {

        $.ajax({
            type: 'GET',
            url: '/Alimento/viewCadastrarAlimento/',
            success: function (result) {
                $('#CriarAlimento').html(result);
                $('#ModalCriarAlimento').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Editar-Alimento', function () {
        var alimentoid = $(this).attr('alimento-id');

        $.ajax({
            type: 'GET',
            url: '/Alimento/viewEditarAlimento/' + alimentoid,
            success: function (result) {
                $('#EditarAlimento').html(result);
                $('#ModalEditarAlimento').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Apagar-Alimento', function () {
        var alimentoid = $(this).attr('alimento-id');

        $.ajax({
            type: 'GET',
            url: '/Alimento/viewExcluirAlimento/' + alimentoid,
            success: function (result) {
                $('#ApagarAlimento').html(result);
                $('#ModalApagarAlimento').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Listar-AlimentoAcabando', function () {

        $.ajax({
            type: 'GET',
            url: '/Alimento/viewListarAlimentoAcabando/',
            success: function (result) {
                $('#ListarAlimentoAcabando').html(result);
                $('#ModalListarAlimentoAcabando').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Listar-AlimentoVencendo', function () {

        $.ajax({
            type: 'GET',
            url: '/Alimento/viewListarAlimentoVencendo/',
            success: function (result) {
                $('#ListarAlimentoVencendo').html(result);
                $('#ModalListarAlimentoVencendo').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-Saida-Alimento', function () {
        var alimentoid = $(this).attr('alimento-id');
        $.ajax({
            type: 'GET',
            url: '/Alimento/viewSaidaAlimento/' + alimentoid,
            success: function (result) {
                $('#SaidaDeAlimento').html(result);
                $('#ModalSaidaDeAlimento').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-LogCadastro-Alimento', function () {
        var alimentoid = $(this).attr('alimento-id');
        $.ajax({
            type: 'GET',
            url: '/Alimento/viewLogDeCadastro/' + alimentoid,
            success: function (result) {
                $('#LogsCadastroAlimentos').html(result);
                $('#ModalLogsCadastroAlimentos').modal();
            }
        });
    });

    $(document).on('click', '.btn-Modal-LogRetirada-Alimento', function () {
        var alimentoid = $(this).attr('alimento-id');
        $.ajax({
            type: 'GET',
            url: '/Alimento/viewLogDeRetidada/' + alimentoid,
            success: function (result) {
                $('#LogsRetiradaAlimentos').html(result);
                $('#ModalLogsRetiradaAlimentos').modal();
            }
        });
    });
    $(document).on('click', '.btn-Modal-Devolve-Alimento', function () {
        var alimentoid = $(this).attr('alimento-id');
        $.ajax({
            type: 'GET',
            url: '/Alimento/viewDevolveAlimento/' + alimentoid,
            success: function (result) {
                $('#DevolveAlimentos').html(result);
                $('#ModalDevelveAlimentos').modal();
            }
        });
    });

    //modais da tela de Alimentos <Começo>
})

function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});
