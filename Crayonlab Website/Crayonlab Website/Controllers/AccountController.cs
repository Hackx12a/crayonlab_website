using Microsoft.AspNetCore.Mvc;
using Crayonlab.Services; // Ensure this namespace is correct
using Crayonlab.Models; // Ensure this namespace is correct
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic; // Ensure this is included for List<T>
using BCrypt.Net; // Add this for password hashing

[Route("Admin")] // Base route for the controller
public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("Login")] // Route for the Login action
    public IActionResult Login()
    {
        return View("~/Views/Admin/Login.cshtml"); // Explicitly specify the view path
    }

    [HttpPost("Login")] // Route for the Login POST action
    [ValidateAntiForgeryToken] // Protect against CSRF attacks
    public async Task<IActionResult> Login(string username, string password)
    {
        // Check the database for the user
        var user = _context.Accounts.FirstOrDefault(u => u.Username == username);

        if (user != null) // User found
        {
            // Verify the password using a secure hash comparison
            if (VerifyPassword(password, user.Password))
            {
                // Create a claims identity for the user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User") // Assign role based on user's admin status
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign in the user
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home"); // Redirect to the home page on successful login
            }
        }

        // If validation fails, return the view with an error message
        ModelState.AddModelError(string.Empty, "Invalid username or password");
        return View("~/Views/Admin/Login.cshtml"); // Explicitly specify the view path
    }

    [HttpPost("Logout")] // Route for the Logout action
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login"); // Redirect to the login page after logout
    }

    // Helper method to verify the password using BCrypt
    private bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword); // Use BCrypt to verify hashed password
    }
}
