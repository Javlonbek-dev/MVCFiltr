using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Models.Car;

namespace Task1.Controllers
{
    public class CarController : Controller
    {
        private readonly CarDbContext dbContext;

        public CarController(CarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var car = await dbContext.Cars.ToListAsync();
            
            return View(car);
        }

        [HttpGet]
        public IActionResult Sort1()
        {
            var car = dbContext.Cars.Where(x => x.Color == "Oq" || x.Color == "Qora").ToList();

            return View(car);
        }

        [HttpGet]
        public IActionResult Sort()
        {
            var car = dbContext.Cars.Where(x => x.Price >= 10000 && x.Price <= 120000).ToList();

            return View(car);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {
            var cars = new Car
            {
                CarId = Guid.NewGuid(),
                Manufacturer = car.Manufacturer,
                Model = car.Model,
                Color = car.Color,
                Price = car.Price
            };

            await dbContext.Cars.AddAsync(cars);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
