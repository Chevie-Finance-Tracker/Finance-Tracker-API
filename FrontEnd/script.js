document.getElementById('registrationForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevents the browser from reloading the page

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const messageDiv = document.getElementById('message');

     // The specific API endpoint from your running C# backend
    const API_URL = 'http://localhost:5018/register';
});