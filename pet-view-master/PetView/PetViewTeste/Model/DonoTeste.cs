using PetView.Model.Classes.FactoryMethod;
using PetView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetViewTeste.Model
{
    public class DonoTeste
    {
        [Fact]
        public void TestDonoConstructor()
        {
            // Arrange
            string nomeDono = "João da Silva";
            string cPFDono = "123.456.789-00";
            string rGDono = "12.345.678-9";
            string celDono = "(11) 98765-4321";
            string telDono = "(11) 1234-5678";
            string emailDono = "joao@example.com";
            string cep = "12345-678";
            string bairro = "Centro";
            string cidade = "São Paulo";
            string complemento = "Apt 101";
            int numcasa = 123;
            string rua = "Rua Exemplo";
            string uf = "SP";

            // Act
            Dono dono = new Dono(nomeDono, cPFDono, rGDono, celDono, telDono, emailDono, cep, bairro, cidade, complemento, numcasa, rua, uf);

            // Assert
            Assert.True(dono.Nome == nomeDono);
            Assert.True(dono.CPF == cPFDono);
            Assert.True(dono.RG == rGDono);
            Assert.True(dono.Cel == celDono);
            Assert.True(dono.TelDono == telDono);
            Assert.True(dono.Email == emailDono);
            Assert.True(dono.Endereco.CEP == cep);
            Assert.True(dono.Endereco.Bairro == bairro);
            Assert.True(dono.Endereco.Cidade == cidade);
            Assert.True(dono.Endereco.Complemento == complemento);
            Assert.True(dono.Endereco.NumCasa == numcasa);
            Assert.True(dono.Endereco.Rua == rua);
            Assert.True(dono.Endereco.UF == uf);
        }

        [Fact]
        public void TestCriarDono()
        {
            // Arrange
            string nome = "João da Silva";
            string cpf = "123.456.789-00";
            string rg = "12.345.678-9";
            string cel = "(11) 98765-4321";
            string tel = "(11) 1234-5678";
            string email = "joao@example.com";
            string cep = "12345-678";
            string bairro = "Centro";
            string cidade = "São Paulo";
            string complemento = "Apt 101";
            int numcasa = 123;
            string rua = "Rua Exemplo";
            string uf = "SP";

            IPessoaFactory factory = new DonoFactory();

            // Act
            Dono dono = Dono.CriarDono(factory, nome, cpf, rg, cel, tel, email, cep, bairro, cidade, complemento, numcasa, rua, uf);

            // Assert
            Assert.True(dono.Nome == nome);
            Assert.True(dono.CPF == cpf);
            Assert.True(dono.RG == rg);
            Assert.True(dono.Cel == cel);
            Assert.True(dono.TelDono == tel);
            Assert.True(dono.Email == email);
            Assert.True(dono.Endereco.CEP == cep);
            Assert.True(dono.Endereco.Bairro == bairro);
            Assert.True(dono.Endereco.Cidade == cidade);
            Assert.True(dono.Endereco.Complemento == complemento);
            Assert.True(dono.Endereco.NumCasa == numcasa);
            Assert.True(dono.Endereco.Rua == rua);
            Assert.True(dono.Endereco.UF == uf);
        }
    }
}
