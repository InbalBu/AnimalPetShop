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
        public IActionResult Index(string category)
        {
            return View("Index",_repository.FilterByCategory(category));
        }
        public IActionResult CreateForm()
        {
            return View("CreateAnimal");
        }
        public IActionResult Create(string name, int age, string description, string pictureName, int categoryID)
        {
            _repository.InsertAnimal(name, age, description, pictureName, categoryID);
            return View("Index", _repository.GetAnimal().Animals);
        }
        public IActionResult Edit(int id)
        {
            var animal = _repository.ShowAnimalById(id);
            return View("EditAnimal", animal);
        }
        public IActionResult Update(int id, Animal animal, int categoryID)
        {
            _repository.UpdateAnimal(id, animal, categoryID);
            return View("Index", _repository.GetAnimal().Animals);
        }
        public IActionResult Delete(int id)
        {
            _repository.DeleteAnimal(id);
            return View("Index", _repository.GetAnimal().Animals);
        }
       
    }
}
