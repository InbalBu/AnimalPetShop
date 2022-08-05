using AnimalShopProject.Data;
using AnimalShopProject.Models;

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

        public void InsertAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            var animalInDb = _context.Animals!.SingleOrDefault(m => m.Id == id);
            animalInDb!.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.PictureName = animal.PictureName;
            animalInDb.Description = animal.Description;
            animalInDb.CategoryID = animal.CategoryID;
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
