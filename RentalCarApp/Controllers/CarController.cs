using Microsoft.AspNetCore.Mvc;

namespace RentalCarApp.Controllers;

public class CarController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}