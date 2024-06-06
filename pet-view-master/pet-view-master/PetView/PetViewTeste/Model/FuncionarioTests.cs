using PetView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetView.Models;

namespace PetViewTeste.Model
{
    public class FuncionarioTests
    {
        [Fact]
        public void TestFuncionarioConstructor()
        {
            // Arrange
            string nomeFunc = "João da Silva";
            string cpfFunc = "123.456.789-00";
            string rgFunc = "12.345.678-9";
            string celFunc = "(11) 98765-4321";
            string telFunc = "(11) 1234-5678";
            string emailFunc = "joao@example.com";
            string cargoFunc = "Veterinário";
            double salarioFunc = 2500.0;
            string cep = "12345-678";
            string bairro = "Centro";
            string cidade = "São Paulo";
            string complemento = "Apt 101";
            int numCasa = 123;
            string rua = "Rua Exemplo";
            string uf = "SP";

            // Act
            Funcionario funcionario = new Funcionario(nomeFunc, cpfFunc, rgFunc, celFunc, telFunc, emailFunc, cargoFunc, salarioFunc, cep, bairro, cidade, complemento, numCasa, rua, uf);

            // Assert
            Assert.True(funcionario.NomeFunc == nomeFunc);
            Assert.True(funcionario.CPFFunc == cpfFunc);
            Assert.True(funcionario.RGFunc == rgFunc);
            Assert.True(funcionario.CelFunc == celFunc);
            Assert.True(funcionario.TelFunc == telFunc);
            Assert.True(funcionario.EmailFunc == emailFunc);
            Assert.True(funcionario.CargoFunc == cargoFunc);
            Assert.True(funcionario.SalarioFunc == salarioFunc);
            Assert.NotNull(funcionario.endereco);
            Assert.True(funcionario.endereco.CEP == cep);
            Assert.True(funcionario.endereco.Bairro == bairro);
            Assert.True(funcionario.endereco.Cidade == cidade);
            Assert.True(funcionario.endereco.Complemento == complemento);
            Assert.True(funcionario.endereco.NumCasa == numCasa);
            Assert.True(funcionario.endereco.Rua == rua);
            Assert.True(funcionario.endereco.UF == uf);
        }
    }
}
