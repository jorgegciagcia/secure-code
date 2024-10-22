using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TestContext _context;

    public UserController(ILogger<HomeController> logger, TestContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create ()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string username, string password,string moreInfo)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ModelState.AddModelError(string.Empty, "Username and password are required.");
            return View("Index");
        }
        // Authentication logic here (e.g., setting cookies, session, etc.)

        _context.Add(new User { Username = username, Password = password , MoreInfo = moreInfo});
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet("User/Info/{username}")]
    public IActionResult Info(string username)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

}
