using System.Data;
using PetView.Models;
using PetView.DAL;

namespace PetView.Controllers
{
    public class AnimalController
    {
        private readonly AnimalDAL _animalDal;

        public AnimalController()
        {
            _animalDal = new AnimalDAL();
        }

        public static void Insert(Animal animal)
        {
            AnimalDAL.Insert(animal);
        }

        public DataTable GetAnimals(string type, string value)
        {
            return AnimalDAL.Select(type, value);
        }

        public void UpdateAnimal(Animal animal)
        {
            AnimalDAL.Update(animal);
        }

        public void DeleteAnimal(int codigoAnimal)
        {
            _animalDal.Delete(codigoAnimal);
        }
    }
}
