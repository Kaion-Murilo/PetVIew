using System.Data;
using PetView.Models;
using PetView.DAL;

namespace PetView.Controllers
{
    public class AnimalController
    {

        public static void Insert(Animal animal)
        {
            
            AnimalDAL.Insert(animal);
        }

        public DataTable GetAnimals(string type, string value)
        {
            return AnimalDAL.Select(type, value);
        }
        public static DataTable Get(int id)
        {
            return AnimalDAL.Get(id);
        }

        public void UpdateAnimal(Animal animal)
        {
            AnimalDAL.Update(animal);
        }

        public void DeleteAnimal(int codigoAnimal)
        {
         
        }
    }
}
