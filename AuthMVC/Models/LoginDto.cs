namespace AuthMVC.Models;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool KeepLoggedIn { get; set; }
}

