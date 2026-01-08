document.getElementById('registrationForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevents the browser from reloading the page

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const messageDiv = document.getElementById('message');

     //specific API endpoint
    const API_URL = 'http://localhost:5018/register';

    fetch(API_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ // Create JSON matching the image's structure
            email: email,
            password: password
        }),
    })
    .then(async response => {
        // If the request fails (e.g., 400 Bad Request, like in the image)
        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Unknown server error (O_O)');
        }
        // If the request succeeds (e.g., 200 OK, 201 Created)
        messageDiv.className = 'success';
        messageDiv.textContent = 'Registration successful!';
        document.getElementById('registrationForm').reset();
    })
    .catch(error => {
        // Handle errors like network issues or the "already taken" message
        messageDiv.className = 'error';
        messageDiv.textContent = 'Error::: ' + error.message;
    });
});