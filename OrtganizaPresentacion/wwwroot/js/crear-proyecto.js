$(document).ready(function () {
    const $selectMiembros = $('select[asp-for="ProyectoModel.MiembrosIds"]');
    $selectMiembros.select2({
        theme: "bootstrap-5",
        width: '100%',
        placeholder: "Escribe para buscar y seleccionar miembros...",
        allowClear: true,
        closeOnSelect: false,
        minimumInputLength: 1
    });

    $selectMiembros.on('select2:opening select2:closing', function (event) {
        const $searchfield = $(this).parent().find('.select2-search__field');
        $searchfield.prop('disabled', true);
    });
});