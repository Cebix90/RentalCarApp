using Microsoft.AspNetCore.Mvc;
using RentalCarApp.Models;

namespace RentalCarApp.Controllers;

public class CarController : Controller
{
    // GET
    private static IList<Car> cars = new List<Car>
    {
        new Car { Id = 1, Model = "Fiat Croma", Description = "Description 1", Price = 100 },
        new Car { Id = 1, Model = "Audi A4", Description = "Description 2", Price = 150 },
        new Car { Id = 1, Model = "Tesla X", Description = "Description 3", Price = 200 }
        
    };

    private readonly ILogger<CarController> _logger;

    public CarController(ILogger<CarController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(cars);
    }

    // GET: FilmController/Details/5
    public ActionResult Details(int id)
    {
        return View(cars.FirstOrDefault(c => c.Id == id));
    }

    // GET: FilmController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: FilmController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Car car)
    {

        car.Id = cars.Count + 1;
        cars.Add(car);
        return RedirectToAction("Index");
    }

    // GET: FilmController/Edit/5
    public ActionResult Edit(int id)
    {
        return View(cars.FirstOrDefault(c => c.Id == id));
    }

    // POST: FilmController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Car car)
    {
        Car carToEdit = cars.FirstOrDefault(c => c.Id == id);

        carToEdit.Model = car.Model;
        carToEdit.Description = car.Description;
        carToEdit.Price = car.Price;

        return RedirectToAction("Index");
    }

    // GET: FilmController/Delete/5
    public ActionResult Delete(int id)
    {
        return View(cars.FirstOrDefault(c => c.Id == id));
    }

    // POST: FilmController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Car car, int id)
    {
        Car carToRemove = cars.FirstOrDefault(c => c.Id == id);
        cars.Remove(carToRemove);
        return RedirectToAction("Index");
    }
}