(function () {
    const form = document.getElementById('formRegistro');
    if (!form) return;

    const email = document.getElementById('email');
    const email2 = document.getElementById('email2');
    const pass = document.getElementById('pass');
    const pass2 = document.getElementById('pass2');

    const emailError = document.getElementById('emailError');
    const emailMatchError = document.getElementById('emailMatchError');
    const passMatchError = document.getElementById('passMatchError');

    const show = (el, on) => { if (el) el.style.display = on ? 'block' : 'none'; };

    function checkEmails() {
        const basicValid = email.checkValidity();
        show(emailError, !basicValid);
        show(emailMatchError, basicValid && email.value && email2.value && email.value !== email2.value);
        return basicValid && email.value === email2.value;
    }
    function checkPasswords() {
        show(passMatchError, pass.value && pass2.value && pass.value !== pass2.value);
        return pass.value === pass2.value && pass.checkValidity() && pass2.checkValidity();
    }

    ['input', 'blur'].forEach(evt => {
        email.addEventListener(evt, checkEmails);
        email2.addEventListener(evt, checkEmails);
        pass.addEventListener(evt, checkPasswords);
        pass2.addEventListener(evt, checkPasswords);
    });

    form.addEventListener('submit', (e) => {
        const ok = form.checkValidity() && checkEmails() && checkPasswords();
        if (!ok) e.preventDefault();  // front-only: no envía nada
    });
})();
