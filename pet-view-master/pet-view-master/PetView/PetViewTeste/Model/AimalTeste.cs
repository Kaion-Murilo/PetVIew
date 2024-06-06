using PetView;
using PetView.Models;
using PetView.Models;
using System.Security.Cryptography;

namespace PetViewTeste.Model
{
    public class AimalTeste
    {

        public class AnimalTests
        {
            [Fact]
            public void AnimalTesteDoTeste()
            {
                // Arrange
                const int rga = 123456789;
                const string nomeAnimal = "Fiado";
                const int idadeAnimal = 5;
                const string tempo = "Anos";
                const string especie = "Cachoro";
                const string raca = "Labrador";
                const string descricao = "Cachoro linfo";

                const int codDono = 1;
                // Act
                var animal = new Animal(rga, nomeAnimal, idadeAnimal, tempo, especie, raca, descricao, codDono);
                // Animal animal = new Animal(rga, nomeAnimal, idadeAnimal, tempo, especie, raca, descricao, codDono);
                Assert.NotNull(animal.RGA);
                Assert.NotNull(animal.NomeAnimal);
                Assert.True(animal.IdadeAnimal != 0);

                Assert.NotNull(animal.Tempo);
                Assert.NotNull(animal.Especie);
                Assert.NotNull(animal.Raca);
                Assert.NotNull(animal.Descricao);

                Assert.True(animal.dono.CodigoDono != 0);


            }
            [Fact]
            public void Constructor_ShouldHandleNullRGA()
            {
                // Arrange
                int? rga = null;
                string nomeAnimal = "Whiskers";
                int idadeAnimal = 3;
                string tempo = "Months";
                string especie = "Cat";
                string raca = "Siamese";
                string descricao = "A cute cat";
                int codDono = 2;

                // Act
                var animal = new Animal(rga, nomeAnimal, idadeAnimal, tempo, especie, raca, descricao, codDono);
                //Assert.NotNull(animal.RGA);
                Assert.NotNull(animal.NomeAnimal);
                Assert.True(animal.IdadeAnimal != 0);

                Assert.NotNull(animal.Tempo);
                Assert.NotNull(animal.Especie);
                Assert.NotNull(animal.Raca);
                Assert.NotNull(animal.Descricao);

                Assert.True(animal.dono.CodigoDono != 0);
                // Assert
            }

        }
    }
}