using PetView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetViewTeste.Model
{
    public class MedicoTests
    {
        [Fact]
        public void TestMedicoConstructor()
        {
            // Arrange
            string nomeMedico = "Dr. João";
            string crmvMedico = "12345";
            string cpfMedico = "123.456.789-00";
            string rgMedico = "12.345.678-9";
            string celMedico = "(11) 98765-4321";
            string telMedico = "(11) 1234-5678";
            string emailMedico = "joao@example.com";
            string funcaoMedico = "Veterinário";
            double salarioMedico = 5000.0;
            string cep = "12345-678";
            string bairro = "Centro";
            string cidade = "São Paulo";
            string complemento = "Apt 101";
            int numCasa = 123;
            string rua = "Rua Exemplo";
            string uf = "SP";

            // Act
            Medico medico = new Medico(nomeMedico, crmvMedico, cpfMedico, rgMedico, celMedico, telMedico, emailMedico, funcaoMedico, salarioMedico, cep, bairro, cidade, complemento, numCasa, rua, uf);

            // Assert
            Assert.True(medico.NomeMedico == nomeMedico);
            Assert.True(medico.CRMVMedico == crmvMedico);
            Assert.True(medico.CPFMedico == cpfMedico);
            Assert.True(medico.RGMedico == rgMedico);
            Assert.True(medico.CelMedico == celMedico);
            Assert.True(medico.TelMedico == telMedico);
            Assert.True(medico.EmailMedico == emailMedico);
            Assert.True(medico.FuncaoMedico == funcaoMedico);
            Assert.True(medico.SalarioMedico == salarioMedico);
            Assert.NotNull(medico.endereco);
            Assert.True(medico.endereco.CEP == cep);
            Assert.True(medico.endereco.Bairro == bairro);
            Assert.True(medico.endereco.Cidade == cidade);
            Assert.True(medico.endereco.Complemento == complemento);
            Assert.True(medico.endereco.NumCasa == numCasa);
            Assert.True(medico.endereco.Rua == rua);
            Assert.True(medico.endereco.UF == uf);
        }

        [Fact]
        public void TestMedicoFactory()
        {
            // Arrange
            string nomeMedico = "Dr. Maria";
            string crmvMedico = "54321";
            string cpfMedico = "987.654.321-00";
            string rgMedico = "98.765.432-1";
            string celMedico = "(11) 98765-4321";
            string telMedico = "(11) 1234-5678";
            string emailMedico = "maria@example.com";
            string funcaoMedico = "Veterinário";
            double salarioMedico = 6000.0;
            string cep = "54321-678";
            string bairro = "Periferia";
            string cidade = "Rio de Janeiro";
            string complemento = "Casa";
            int numCasa = 456;
            string rua = "Rua da Esquina";
            string uf = "RJ";

            Medico.MedicoFactory factory = new Medico.MedicoFactory();

            // Act
            Medico medico = factory.CreateMedico(nomeMedico, crmvMedico, cpfMedico, rgMedico, celMedico, telMedico, emailMedico, funcaoMedico, salarioMedico, cep, bairro, cidade, complemento, numCasa, rua, uf);

            // Assert
            Assert.True(medico.NomeMedico == nomeMedico);
            Assert.True(medico.CRMVMedico == crmvMedico);
            Assert.True(medico.CPFMedico == cpfMedico);
            Assert.True(medico.RGMedico == rgMedico);
            Assert.True(medico.CelMedico == celMedico);
            Assert.True(medico.TelMedico == telMedico);
            Assert.True(medico.EmailMedico == emailMedico);
            Assert.True(medico.FuncaoMedico == funcaoMedico);
            Assert.True(medico.SalarioMedico == salarioMedico);
            Assert.NotNull(medico.endereco);
            Assert.True(medico.endereco.CEP == cep);
            Assert.True(medico.endereco.Bairro == bairro);
            Assert.True(medico.endereco.Cidade == cidade);
            Assert.True(medico.endereco.Complemento == complemento);
            Assert.True(medico.endereco.NumCasa == numCasa);
            Assert.True(medico.endereco.Rua == rua);
            Assert.True(medico.endereco.UF == uf);
        }
    }
}
