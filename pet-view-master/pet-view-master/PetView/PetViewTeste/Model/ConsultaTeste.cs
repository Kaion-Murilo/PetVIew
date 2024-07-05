// Importações de namespaces necessários
using PetView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; // Importa o framework de testes Xunit

namespace PetViewTeste.Model
{
    // Classe de testes para a classe Consulta
    public class ConsultaTeste
    {
        // Teste para verificar o construtor de Consulta com funcionário
        [Fact]
        public void TestConsultaConstructorFuncionario()
        {
            // Arrange - Configuração inicial
            string observacao = "Observação teste";
            double custo = 100.0;
            string tipoConsulta = "Rotina";
            string dataConsulta = "2024-06-01";
            int codMedico = 1;
            int codAnimal = 1;

            // Act - Ação (chamada do construtor)
            var consulta = new ConsultaModel.Consulta(observacao, custo, tipoConsulta, dataConsulta, codMedico, codAnimal);

            // Assert - Verificação dos resultados esperados
            Assert.True(consulta.Observacao == observacao);
            Assert.True(consulta.Custo == custo);
            Assert.True(consulta.TipoConsulta == tipoConsulta);
            Assert.True(consulta.DataConsulta == dataConsulta);
            Assert.True(consulta.medico.CodigoMedico == codMedico);
            Assert.True(consulta.animal.CodigoAnimal == codAnimal);
        }

        // Teste para verificar o construtor de Consulta com médico
        [Fact]
        public void TestConsultaConstructorMedico()
        {
            // Arrange - Configuração inicial
            int codConsulta = 1;
            string sintomas = "Sintomas teste";
            string diagnostico = "Diagnóstico teste";
            string observacao = "Observação teste";

            // Act - Ação (chamada do construtor)
            var consulta = new ConsultaModel.Consulta(codConsulta, sintomas, diagnostico, observacao);

            // Assert - Verificação dos resultados esperados
            Assert.True(consulta.CodConsulta == codConsulta);
            Assert.True(consulta.Sintomas == sintomas);
            Assert.True(consulta.Diagnostico == diagnostico);
            Assert.True(consulta.Observacao == observacao);
        }

        // Teste para verificar o construtor padrão de Consulta
        [Fact]
        public void TestConsultaDefaultConstructor()
        {
            // Act - Ação (chamada do construtor padrão)
            var consulta = new ConsultaModel.Consulta();

            // Assert - Verificação dos resultados esperados
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
