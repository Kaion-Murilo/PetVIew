using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetView.Model.Classes.FactoryMethod;
using PetView;

namespace PetView.Model.Classes.FactoryMethod
{
    public class FacPessoaTeste
    {
        [Fact]
        public void TestCriarPessoa()
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
            FacPessoa dono = factory.CriarPessoa(nome, cpf, rg, cel, tel, email, cep, bairro, cidade, complemento, numcasa, rua, uf);

            // Assert
            Assert.True(dono.Nome == nome);
            Assert.True(dono.CPF == cpf);
            Assert.True(dono.RG == rg);
            Assert.True(dono.Cel == cel);
            Assert.True(((Dono)dono).TelDono == tel); // Casting to Dono to access Tel property
            Assert.True(dono.Email == email);
            Assert.True(((Dono)dono).Endereco.CEP == cep); // Casting to Dono to access CEP property
            Assert.True(((Dono)dono).Endereco.Bairro == bairro); // Casting to Dono to access Bairro property
            Assert.True(((Dono)dono).Endereco.Cidade == cidade); // Casting to Dono to access Cidade property
            Assert.True(((Dono)dono).Endereco.Complemento == complemento); // Casting to Dono to access Complemento property
            Assert.True(((Dono)dono).Endereco.NumCasa == numcasa); // Casting to Dono to access NumCasa property
            Assert.True(((Dono)dono).Endereco.Rua == rua); // Casting to Dono to access Rua property
            Assert.True(((Dono)dono).Endereco.UF == uf); // Casting to Dono to access UF property
        }
    }
}
