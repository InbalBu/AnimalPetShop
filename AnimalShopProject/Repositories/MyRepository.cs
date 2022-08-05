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
                return _context.Animals!.Include(c => c.Category).Where(c => c.Category!.Name == category).ToList();
            }
        }

        public Animal ShowAnimalById(int animalId)
        {
            return _context.Animals!.Include(c => c.Comments!).Single(c => c.Id! == animalId);
        }

        public Animal AddComment(int animalId, string comment)
        {
             _context.Animals!.Include(c => c.Comments!).Single(c => c.Id! == animalId).Comments!.Add(new Comment { Text = comment });
            _context.SaveChanges();
            return _context.Animals!.Include(c => c.Comments!).Single(c => c.Id! == animalId);
        }

        public void InsertAnimal(string name, int age, string description, string pictureName)
        {
             var animalList = GetAnimal().Animals!.ToList();
            _context.Animals!.Add(new Animal { Id = animalList.Count+1, CategoryID = 1, Age = age, Name = name, Description = description, PictureName = pictureName});
            _context.SaveChanges();
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            var animalInDb = _context.Animals!.SingleOrDefault(m => m.Id == id);
            _context.Animals!.Update(animalInDb!);
            animalInDb!.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.PictureName = animal.PictureName;
            animalInDb.Description = animal.Description;
            _context.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animal = _context.Animals!.SingleOrDefault(m => m.Id == id);
            _context.Animals!.Remove(animal!);
            _context.SaveChanges();
        }
    }

   
}
