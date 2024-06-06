using PetView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetViewTeste.Model
{
    public class TratamentoTests
    {
        [Fact]
        public void TestTratamentoConstructorWithConsulta()
        {
            // Arrange
            string observacao = "Observação do tratamento";
            double custo = 150.0;
            string tipoTratamento = "Cirurgia";
            string dataTratamento = "2024-06-03";
            int codMedico = 1;
            int codAnimal = 1;
            int codConsulta = 1;

            // Act
            Tratamento tratamento = new Tratamento(observacao, custo, tipoTratamento, dataTratamento, codMedico, codAnimal, codConsulta);

            // Assert
            Assert.True(tratamento.Observacao == observacao);
            Assert.True(tratamento.Custo == custo);
            Assert.True(tratamento.TipoTratamento == tipoTratamento);
            Assert.True(tratamento.DataTratamento == dataTratamento);
            Assert.True(tratamento.medico.CodigoMedico == codMedico);
            Assert.True(tratamento.animal.CodigoAnimal == codAnimal);
            Assert.True(tratamento.CodConsulta == codConsulta);
        }

        [Fact]
        public void TestTratamentoConstructorWithoutConsulta()
        {
            // Arrange
            int codTratamento = 1;
            string observacao = "Observação do tratamento";

            // Act
            Tratamento tratamento = new Tratamento(codTratamento, observacao);

            // Assert
            Assert.True(tratamento.CodTratamento == codTratamento);
            Assert.True(tratamento.Observacao == observacao);
            Assert.Null(tratamento.medico);
            Assert.Null(tratamento.animal);
            Assert.Null(tratamento.consulta);
        }
    }
}
