$(document).ready(function () {
    const $selectResponsables = $('#selectResponsables');
    const $formulario = $('#formulario-crear-tarea');

    $selectResponsables.select2({
        theme: "bootstrap-5",
        width: '100%',
        placeholder: "Escribe para buscar y seleccionar responsables...",
        allowClear: true,
        closeOnSelect: false,
        minimumInputLength: 0
    });

    function limpiarError(element) {
        element.nextAll('.text-danger.small').first().empty();
        element.removeClass('is-invalid');
        element.siblings('small[id^="error-"]').hide();
    }

    function mostrarError(element, errorId) {
        element.addClass('is-invalid');
        $(errorId).show();
    }

    $('#txtTitulo').on('input blur', function () {
        let val = $(this).val().trim();
        const maxLength = 100;
        limpiarError($(this));

        if (val === "") {
            mostrarError($(this), '#error-titulo-requerido');
        } else if (val.length > maxLength) {
            mostrarError($(this), '#error-titulo-largo');
        }
    });

    $('#txtDescripcion').on('input blur', function () {
        let val = $(this).val().trim();
        const maxLength = 1000;
        limpiarError($(this));

        if (val.length > maxLength) {
            mostrarError($(this), '#error-descripcion-largo');
        }
    });

    $selectResponsables.on('change', function () {
        const valores = $(this).val();
        limpiarError($(this));

        if (!valores || valores.length === 0) {
            mostrarError($(this), '#error-responsables-requeridos');
        }
    });

    $('#dtFechaInicio').on('input blur', function () {
        let val = $(this).val().trim();
        limpiarError($(this));

        if (val === "") {
            mostrarError($(this), '#error-fecha-requerida');
        }
    });

    $('#selectPrioridad').on('change blur', function () {
        let val = $(this).val();
        limpiarError($(this));

        if (val === null || val === "") {
            mostrarError($(this), '#error-prioridad-requerida');
        }
    });

    $('#txtEstimacionDias').on('input blur', function () {
        let val = $(this).val();
        let numVal = parseInt(val);
        limpiarError($(this));

        if (val === "") {
            mostrarError($(this), '#error-tiempo-requerido');
        } else if (isNaN(numVal) || numVal < 1 || numVal > 365) {
            mostrarError($(this), '#error-tiempo-valido');
        }
    });
});