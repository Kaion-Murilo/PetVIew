using PetView.Controllers;
using PetView.Models;
using System.Data;
using System;
using System.Data.SqlClient;

namespace PetViewTeste.Controller
{
    public class AnimalControllerTests
    {
        /* 
        [Fact]
        public void TestInsertAnimal()
        {
            int rga = 123456789;
            string nomeAnimal = "teste";
            int idadeAnimal = 5;
            string tempo = "Anos";
            string especie = "Rato";
            string raca = "12";
            string descricao = "Rato lindo";
            int codDono = 1;
            var animal = new Animal(rga, nomeAnimal, idadeAnimal, tempo, especie, raca, descricao, codDono);
            AnimalController.Insert(animal);
           
        }
        }
/* 
        [Fact]
        
        public void TestGetAnimals()
        {
            // Arrange
            string type = "Tipo";
            string value = "Cachorro";

            // Act
            AnimalController animalController = new AnimalController();
            DataTable result = animalController.GetAnimals(type, value);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Rows.Count > 0);
        }*/
        /* 
        [Fact]
        public void TestUpdateAnimal()
        {
            // Arrange
            int rga = 123456789;
            string nomeAnimal = "Fiado";
            int idadeAnimal = 5;
            string tempo = "Anos";
            string especie = "Cachoro";
            string raca = "Labrador";
            string descricao = "Cachoro linfo";

            int codDono = 1;
            // Act
            var animal = new Animal(rga, nomeAnimal, idadeAnimal, tempo, especie, raca, descricao, codDono);

            // Act
            AnimalController animalController = new AnimalController();
            animalController.UpdateAnimal(animal);

            // Assert
            // It's difficult to directly test update operations without knowing the database state
            // So, you may need to manually verify if the update was successful in the database
        }*/
        /* 
        [Fact]
        public void TestDeleteAnimal()
        {
          // Arrange
          int codigoAnimal = 1;

          // Act
          AnimalController animalController = new AnimalController();
          animalController.DeleteAnimal(codigoAnimal);

          // Assert
          // It's difficult to directly test delete operations without knowing the database state
          // So, you may need to manually verify if the deletion was successful in the database
        }*/
    }
}
