using AnimalShopProject.Data;
using AnimalShopProject.Models;
using AnimalShopProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AnimalShopProject.Controllers
{
    public class HomeController : Controller
    {

        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAnimal().Animals!.Include(c => c.Comments!));
                
        }


    }
}