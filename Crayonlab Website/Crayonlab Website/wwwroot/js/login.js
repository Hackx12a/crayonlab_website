function togglePasswordVisibility() {
    const passwordInput = document.getElementById('password');
    const toggleButton = document.getElementById('togglePassword');

    // Toggle password visibility
    if (passwordInput.type === 'password') {
        passwordInput.type = 'text'; // Show password
        toggleButton.src = "/Content/assets/show.png"; // Change to eye open image
    } else {
        passwordInput.type = 'password'; // Hide password
        toggleButton.src = "/Content/assets/hidden.png"; // Change to eye closed image
    }
}
