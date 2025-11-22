$(document).ready(function () {
    const $selectMiembros = $('#selectMiembros');

    $selectMiembros.select2({
        theme: "bootstrap-5",
        width: '100%',
        placeholder: "Escribe para buscar y seleccionar miembros...",
        allowClear: true,
        closeOnSelect: false,
        minimumInputLength: 1
    });

    $('#txtNombre').on('input blur', function () {
        let val = $(this).val().trim();
        const maxLength = 50;

        $(this).nextAll('.text-danger.small').first().empty();

        $('#error-nombre-requerido').hide();
        $('#error-nombre-largo').hide();
        $(this).removeClass('is-invalid');

        if (val === "") {
            $('#error-nombre-requerido').show();
            $(this).addClass('is-invalid');
        } else if (val.length > maxLength) {
            $('#error-nombre-largo').show();
            $(this).addClass('is-invalid');
        }
    });

    $('#txtDescripcion').on('input blur', function () {
        let val = $(this).val().trim();
        const maxLength = 100;

        $(this).nextAll('.text-danger.small').first().empty();

        $('#error-descripcion-requerida').hide();
        $('#error-descripcion-largo').hide();
        $(this).removeClass('is-invalid');

        if (val === "") {
            $('#error-descripcion-requerida').show();
            $(this).addClass('is-invalid');
        } else if (val.length > maxLength) {
            $('#error-descripcion-largo').show();
            $(this).addClass('is-invalid');
        }
    });

    $selectMiembros.on('change', function () {
        const valores = $(this).val();

        $(this).nextAll('.text-danger.small').first().empty();

        $('#error-miembros-requeridos').hide();

        if (!valores || valores.length === 0) {
            $('#error-miembros-requeridos').show();
        }
    });
});