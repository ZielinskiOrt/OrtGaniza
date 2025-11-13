$(document).ready(function () {

    const regexEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const regexCompleja = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).*$/;

    $('#txtEmail').on('input blur', function () {
        let val = $(this).val().trim();

        $('#error-email-requerido').hide();
        $('#error-email-formato').hide();

        if (val === "") {
            $('#error-email-requerido').show();
        } else if (!regexEmail.test(val)) {
            $('#error-email-formato').show();
        }

        $('#txtConfirmEmail').trigger('input');
    });

    $('#txtConfirmEmail').on('input blur', function () {
        let val = $(this).val().trim();
        let original = $('#txtEmail').val().trim();

        $('#error-confirmar-email-requerido').hide();
        $('#error-confirmar-email-coincidencia').hide();

        if (val === "") {
            $('#error-confirmar-email-requerido').show();
        } else if (val !== original) {
            $('#error-confirmar-email-coincidencia').show();
        }
    });

    $('#txtUsuario').on('input blur', function () {
        let val = $(this).val().trim();

        $('#error-usuario-requerido').hide();
        $('#error-usuario-largo').hide();
        $('#error-usuario-seguridad').hide();

        if (val === "") {
            $('#error-usuario-requerido').show();
        } else {
            if (val.length < 8) {
                $('#error-usuario-largo').show();
            }
            else if (!regexCompleja.test(val)) {
                $('#error-usuario-seguridad').show();
            }
        }
    });

    $('#txtNombre').on('input blur', function () {
        if ($(this).val().trim() === "") {
            $('#error-nombre-requerido').show();
        } else {
            $('#error-nombre-requerido').hide();
        }
    });

    $('#txtApellido').on('input blur', function () {
        if ($(this).val().trim() === "") {
            $('#error-apellido-requerido').show();
        } else {
            $('#error-apellido-requerido').hide();
        }
    });

    $('#txtPassword').on('input blur', function () {
        let val = $(this).val();

        $('#error-password-requerido').hide();
        $('#error-password-largo').hide();
        $('#error-password-seguridad').hide();

        if (val === "") {
            $('#error-password-requerido').show();
        } else {
            if (val.length < 8) {
                $('#error-password-largo').show();
            }
            else if (!regexCompleja.test(val)) {
                $('#error-password-seguridad').show();
            }
        }

        $('#txtConfirmPassword').trigger('input');
    });

    $('#txtConfirmPassword').on('input blur', function () {
        let val = $(this).val();
        let original = $('#txtPassword').val();

        $('#error-confirmar-password-requerido').hide();
        $('#error-confirmar-password-coincidencia').hide();

        if (val === "") {
            $('#error-confirmar-password-requerido').show();
        } else if (val !== original) {
            $('#error-confirmar-password-coincidencia').show();
        }
    });
});