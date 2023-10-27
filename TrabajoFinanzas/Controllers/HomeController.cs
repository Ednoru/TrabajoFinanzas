using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinanzas.Models;

namespace TrabajoFinanzas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult PlanDePagos()
    {
        return View();
    }
    
    public IActionResult Desarrolladores()
    {
        return View();
    }
    
    public IActionResult Somos()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}