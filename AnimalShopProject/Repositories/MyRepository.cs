using AnimalShopProject.Data;
using AnimalShopProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalShopProject.Repositories
{
    public class MyRepository : IRepository
    {
        private AnimalContext _context;

        public MyRepository(AnimalContext context)
        {
            _context = context;
        }

        public AnimalContext GetAnimal()
        {
            return _context;
        }

        public List<Animal> GetTopAnimals()
        {
            return _context.Animals!.Include(c => c.Comments).OrderByDescending(c => c.Comments!.Count).Take(2).ToList();
        }

        public List<Animal> FilterByCategory(string category)
        {
            if (category == null)
            {
                return _context.Animals!.ToList();
            } else
            {
                return _context.Animals!.Include(c => c.Category).ThenInclude(c => c!.Animals!).ThenInclude(c => c.Comments!).Where(c => c.Category!.Name == category).ToList();
            }
        }

        public Animal ShowAnimalById(int animalId)
        {
            var categories = _context.Animals!.Include(c => c.Category).ThenInclude(c => c!.Animals!).ThenInclude(c => c.Comments!);
            var animal = categories!.Single(m => m.Id == animalId);
            return animal;
        }

        public Animal AddComment(int animalId, string comment)
        {
            _context.Animals!.Include(c => c.Category!).ThenInclude(c => c.Animals!).ThenInclude(c => c.Comments!).Single(c => c.Id! == animalId).Comments!.Add(new Comment { Text = comment });
            _context.SaveChanges();
            return _context.Animals!.Include(c => c.Comments!).Single(c => c.Id! == animalId);
        }

        public void InsertAnimal(string name, int age, string description, string pictureName, int categoryID)
        {
            var animalList = GetAnimal().Animals!.ToArray();
            int id = animalList[animalList.Length-1].Id + 1;
            _context.Add(new Animal { Id = id, CategoryID = categoryID, Age = age, Name = name, Description = description, PictureName = pictureName});
            _context.SaveChanges();
        }

        public void UpdateAnimal(int id, Animal animal, int categoryID)
        {
            var animalInDb = _context.Animals!.SingleOrDefault(m => m.Id == id);
            animalInDb!.CategoryID = categoryID;
            _context.Animals!.Update(animalInDb!);
            animalInDb!.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.PictureName = animal.PictureName;
            animalInDb.Description = animal.Description;
            animalInDb.Category = animal.Category;
            _context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animal = _context.Animals!.SingleOrDefault(m => m.Id == id);
            _context.Remove(animal!);
            _context.SaveChanges();
        }
    }

   
}
