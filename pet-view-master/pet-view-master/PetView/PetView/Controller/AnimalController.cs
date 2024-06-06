using System.Data;
using PetView.Models;
using PetView.DAL;

namespace PetView.Controllers
{
    public class AnimalController
    {

        // Método para inserir um novo animal
        public static void Insert(Animal animal)
        {
            // Chama o método de inserção da classe AnimalDAL
            AnimalDAL.Insert(animal);
        }

        // Método para obter uma lista de animais com base em critérios de pesquisa
        public DataTable GetAnimals(string type, string value)
        {
            // Chama o método de seleção da classe AnimalDAL
            return AnimalDAL.Select(type, value);
        }

        // Método para obter os detalhes de um animal específico
        public static DataTable Get(int id)
        {
            // Chama o método de obtenção de detalhes da classe AnimalDAL
            return AnimalDAL.Get(id);
        }

        // Método para atualizar as informações de um animal
        public void UpdateAnimal(Animal animal)
        {
            // Chama o método de atualização da classe AnimalDAL
            AnimalDAL.Update(animal);
        }

        // Método para excluir um animal
        public void DeleteAnimal(int codigoAnimal)
        {
            // A implementação deste método está ausente
        }
    }
}