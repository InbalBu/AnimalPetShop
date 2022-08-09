using AnimalShopProject.Data;
using AnimalShopProject.Models;

namespace AnimalShopProject.Repositories
{
    public interface IRepository
    {
        public void InsertAnimal(string name, int age, string description, string pictureName, int categoryID);
        public Animal AddComment(int animalId, string comment);
        public Animal ShowAnimalById(int animalId);
        List<Animal> FilterByCategory(string category);
        List<Animal> GetTopAnimals();
        AnimalContext GetAnimal();
        void UpdateAnimal(int id, Animal animal, int CategoryID);
        void DeleteAnimal(int id);
    }
}
