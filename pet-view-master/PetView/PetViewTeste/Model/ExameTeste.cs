using PetView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PetViewTeste.Model
{
    public class ExameTests
    {
        [Fact]
        public void TestExameConstructorWithConsulta()
        {
            // Arrange
            string observacao = "Observação do exame";
            double custo = 100.0;
            string tipoExame = "Hemograma";
            string dataExame = "2024-06-03";
            int codAnimal = 1;
            int codMedico = 1;
            int codConsulta = 1;

            // Act
            Exame exame = new Exame(observacao, custo, tipoExame, dataExame, codAnimal, codMedico, codConsulta);

            // Assert
            Assert.True(exame.Observacao == observacao);
            Assert.True(exame.Custo == custo);
            Assert.True(exame.TipoExame == tipoExame);
            Assert.True(exame.DataExame == dataExame);
            Assert.True(exame.animal.CodigoAnimal == codAnimal);
            Assert.True(exame.medico.CodigoMedico == codMedico);
            Assert.True(exame.Consulta.CodConsulta == codConsulta);
        }

        [Fact]
        public void TestExameConstructorWithoutConsulta()
        {
            // Arrange
            int codExame = 1;
            string observacao = "Observação do exame";

            // Act
            Exame exame = new Exame(codExame, observacao);

            // Assert
            Assert.True(exame.CodExame == codExame);
            Assert.True(exame.Observacao == observacao);
            Assert.Null(exame.medico);
            Assert.Null(exame.animal);
            Assert.Null(exame.Consulta);
        }
    }
}
