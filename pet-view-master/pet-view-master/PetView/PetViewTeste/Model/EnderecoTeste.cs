using PetView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetViewTeste.Model
{
    public class EnderecoTeste
    {
        [Fact]
        public void TestEnderecoBuilder()
        {
            // Arrange
            string cep = "12345-678";
            int numCasa = 123;
            string rua = "Rua Exemplo";
            string bairro = "Centro";
            string complemento = "Apt 101";
            string cidade = "São Paulo";
            string uf = "SP";

            // Act
            Endereco endereco = new Endereco.EnderecoBuilder()
                                .ComCEP(cep)
                                .ComNumCasa(numCasa)
                                .NaRua(rua)
                                .NoBairro(bairro)
                                .ComComplemento(complemento)
                                .NaCidade(cidade)
                                .NoUF(uf)
                                .Construir();

            // Assert
            Assert.True(endereco.CEP == cep);
            Assert.True(endereco.NumCasa == numCasa);
            Assert.True(endereco.Rua == rua);
            Assert.True(endereco.Bairro == bairro);
            Assert.True(endereco.Complemento == complemento);
            Assert.True(endereco.Cidade == cidade);
            Assert.True(endereco.UF == uf);
        }

        [Fact]
        public void TestEnderecoBuilderWithPartialData()
        {
            // Arrange
            string cep = "12345-678";
            int numCasa = 123;
            string cidade = "São Paulo";
            string uf = "SP";

            // Act
            Endereco endereco = new Endereco.EnderecoBuilder()
                                .ComCEP(cep)
                                .ComNumCasa(numCasa)
                                .NaCidade(cidade)
                                .NoUF(uf)
                                .Construir();

            // Assert
            Assert.True(endereco.CEP == cep);
            Assert.True(endereco.NumCasa == numCasa);
            Assert.Null(endereco.Rua);
            Assert.Null(endereco.Bairro);
            Assert.Null(endereco.Complemento);
            Assert.True(endereco.Cidade == cidade);
            Assert.True(endereco.UF == uf);
        }   
    }
}
