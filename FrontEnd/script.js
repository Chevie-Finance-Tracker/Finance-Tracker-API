document.getElementById('registrationForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevents the browser from reloading the page

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const messageDiv = document.getElementById('message');
});