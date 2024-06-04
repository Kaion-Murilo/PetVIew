using PetView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetView.Models;
namespace PetViewTeste.Model { 
    public class ConsultaTeste
    {
        [Fact]
        public void TestConsultaConstructorFuncionario()
            {
                // Arrange
                string observacao = "Observação teste";
                double custo = 100.0;
                string tipoConsulta = "Rotina";
                string dataConsulta = "2024-06-01";
                int codMedico = 1;
                int codAnimal = 1;

                // Act
                var consulta = new ConsultaModel.Consulta(observacao, custo, tipoConsulta, dataConsulta, codMedico, codAnimal);

                // Assert
                Assert.True(consulta.Observacao == observacao);
                Assert.True(consulta.Custo == custo);
                Assert.True(consulta.TipoConsulta == tipoConsulta);
                Assert.True(consulta.DataConsulta == dataConsulta);
                Assert.True(consulta.medico.CodigoMedico == codMedico);
                Assert.True(consulta.animal.CodigoAnimal == codAnimal);
            }

        [Fact]
        public void TestConsultaConstructorMedico()
            {
                // Arrange
                int codConsulta = 1;
                string sintomas = "Sintomas teste";
                string diagnostico = "Diagnóstico teste";
                string observacao = "Observação teste";

                // Act
                var consulta = new ConsultaModel.Consulta(codConsulta, sintomas, diagnostico, observacao);

                // Assert
                Assert.True(consulta.CodConsulta == codConsulta);
                Assert.True(consulta.Sintomas == sintomas);
                Assert.True(consulta.Diagnostico == diagnostico);
                Assert.True(consulta.Observacao == observacao);
            }
        [Fact]
        public void TestConsultaDefaultConstructor()
            {
                // Act
            var consulta = new ConsultaModel.Consulta();

            // Assert
            Assert.NotNull(consulta);
             Assert.Null(consulta.Sintomas);
             Assert.Null(consulta.Diagnostico);
             Assert.Null(consulta.Observacao);
             Assert.True(consulta.CodConsulta == 0);
             Assert.True(consulta.Custo == 0);
             Assert.Null(consulta.TipoConsulta);
             Assert.Null(consulta.DataConsulta);
             //Assert.NotNull(consulta.medico);
             //Assert.NotNull(consulta.animal);
        }
    }
    }

