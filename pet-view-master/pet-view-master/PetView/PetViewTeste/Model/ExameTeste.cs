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
    // Classe de testes para a classe Exame
    public class ExameTests
    {
        // Teste para verificar o construtor de Exame com consulta
        [Fact]
        public void TestExameConstructorWithConsulta()
        {
            // Arrange - Configuração inicial
            string observacao = "Observação do exame";
            double custo = 100.0;
            string tipoExame = "Hemograma";
            string dataExame = "2024-06-03";
            int codAnimal = 1;
            int codMedico = 1;
            int codConsulta = 1;

            // Act - Ação (chamada do construtor)
            Exame exame = new Exame(observacao, custo, tipoExame, dataExame, codAnimal, codMedico, codConsulta);

            // Assert - Verificação dos resultados esperados
            Assert.True(exame.Observacao == observacao);
            Assert.True(exame.Custo == custo);
            Assert.True(exame.TipoExame == tipoExame);
            Assert.True(exame.DataExame == dataExame);
            Assert.True(exame.animal.CodigoAnimal == codAnimal);
            Assert.True(exame.medico.CodigoMedico == codMedico);
            Assert.True(exame.Consulta.CodConsulta == codConsulta);
        }

        // Teste para verificar o construtor de Exame sem consulta
        [Fact]
        public void TestExameConstructorWithoutConsulta()
        {
            // Arrange - Configuração inicial
            int codExame = 1;
            string observacao = "Observação do exame";

            // Act - Ação (chamada do construtor)
            Exame exame = new Exame(codExame, observacao);

            // Assert - Verificação dos resultados esperados
            Assert.True(exame.CodExame == codExame);
            Assert.True(exame.Observacao == observacao);
            Assert.Null(exame.medico);
            Assert.Null(exame.animal);
            Assert.Null(exame.Consulta);
        }
    }
}
