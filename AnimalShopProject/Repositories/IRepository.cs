using AnimalShopProject.Data;
using AnimalShopProject.Models;

namespace AnimalShopProject.Repositories
{
    public interface IRepository
    {
        AnimalContext GetAnimal();
        void InsertAnimal(Animal animal);
        void UpdateAnimal(int id, Animal animal);
        void DeleteAnimal(int id);
    }
}
