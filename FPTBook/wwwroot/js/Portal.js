const PortalFormWarp = document.querySelector('.portal-form-wrap');
const LoginLink = document.querySelector('.login-link');
const RegisterLink = document.querySelector('.register-link');

RegisterLink.addEventListener('click', () => {
    PortalFormWarp.classList.add('active');
});

LoginLink.addEventListener('click', () => {
    PortalFormWarp.classList.remove('active');
});