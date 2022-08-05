using AnimalShopProject.Models;
using AnimalShopProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShopProject.Controllers
{
    public class AdminController : Controller
    {

        private IRepository _repository;

        public AdminController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            Animal animal = new Animal { Id = 4, Name = "Labrador", Age = 6, PictureName = "sdsa", Description = "dsad", CategoryID = 2 };
            _repository.InsertAnimal(animal);
            return Content("Animal was Added");
        }
        public IActionResult Edit()
        {
            Animal animal = new Animal { Id = 3, Name = "Labrador", Age = 8, PictureName = "sdsa", Description = "dsad", CategoryID = 2 };
            _repository.UpdateAnimal(2, animal);
            return Content("Anima was edited");
        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteAnimal(id);
            return Content("Anima was Deleted");

        }
    }
}
