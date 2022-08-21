using AnimalShopProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShopProject.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _repository;
        public CatalogController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(string category)
        {
            return View(_repository.FilterByCategory(category));
        }
        public IActionResult AnimalCard(int animalId)
        {
            return View(_repository.ShowAnimalById(animalId));
        }
        public IActionResult AddComment(int animalId, string comment)
        {
            return View("AnimalCard", _repository.AddComment(animalId, comment));
        }
    }
}
