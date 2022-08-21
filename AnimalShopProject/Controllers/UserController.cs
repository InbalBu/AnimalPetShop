using AnimalShopProject.Models;
using AnimalShopProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShopProject.Controllers
{
    public class UserController : Controller
    {
        private IRepository _repository;
        public UserController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(string category)
        {
            return View("Index", _repository.FilterByCategory(category));
        }
        public IActionResult LoginForm()
        {
            return View("Login");
        }
        public List<User> PutValue()
        {
            var users = new List<User>
            {
                new User{Id = 1, UserName = "inbal499", Password = "123"}
            };
            return users;
        }
        public IActionResult Login(User user)
        {
            var u = PutValue();

            var ue = u.Where(u => u.UserName!.Equals(user.UserName));
            var up = ue.Where(p => p.Password!.Equals(user.Password));

            if (up.Count() == 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid UserName or Password.");
                return View("Login");
            }
            else
            {
                return View("Index", _repository.GetAnimal().Animals);
            }
        }
    }
}
