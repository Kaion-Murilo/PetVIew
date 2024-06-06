using System;
using System.Data;
using static PetView.Models.ConsultaModel;

namespace PetView.Models
{
    // Classe que representa um exame
    public class Exame
    {
        // Código do exame
        public int CodExame { get; set; }
        // Médico responsável pelo exame
        public Medico medico { get; set; }
        // Animal que será examinado
        public Animal animal { get; set; }
        // Consulta relacionada ao exame
        public ConsultaModel consulta { get; set; }
        // Detalhes da consulta
        public ConsultaModel.Consulta Consulta { get; set; }
        // Observações sobre o exame
        public string Observacao { get; set; }
        // Custo do exame
        public double Custo { get; set; }
        // Tipo do exame
        public string TipoExame { get; set; }
        // Data do exame
        public string DataExame { get; set; }

        // Construtor para criar um novo exame com detalhes completos
        public Exame(string observacao, double custo, string tipoExame, string dataExame, int codAnimal, int codMed, int codConsulta)
        {
            // Inicializa o médico com o código fornecido
            medico = new Medico { CodigoMedico = codMed };
            // Inicializa o animal com o código fornecido
            animal = new Animal { CodigoAnimal = codAnimal };
            // Inicializa a consulta com o código fornecido
            Consulta = new Consulta { CodConsulta = codConsulta };
            // Define a observação do exame
            Observacao = observacao;
            // Define o custo do exame
            Custo = custo;
            // Define o tipo do exame
            TipoExame = tipoExame;
            // Define a data do exame
            DataExame = dataExame;
        }

        // Construtor para criar um novo exame com código e observação
        public Exame(int codExame, string observacao)
        {
            // Define o código do exame
            CodExame = codExame;
            // Define a observação do exame
            Observacao = observacao;
        }
    }
}
