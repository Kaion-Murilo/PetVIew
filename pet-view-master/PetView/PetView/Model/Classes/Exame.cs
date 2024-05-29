using System;
using System.Data;
using static PetView.Models.ConsultaModel;

namespace PetView.Models
{
    public class Exame
    {
        public int CodExame { get; set; }
        public Medico medico { get; set; }
        public Animal animal { get; set; }
        public ConsultaModel consulta { get; set; }
        public ConsultaModel.Consulta Consulta { get; set; }
        public string Observacao { get; set; }
        public double Custo { get; set; }
        public string TipoExame { get; set; }
        public string DataExame { get; set; }

        // Construtores
        public Exame(string observacao, double custo, string tipoExame, string dataExame, int codAnimal, int codMed, int codConsulta)
        {
            medico = new Medico { CodigoMedico = codMed };
            animal = new Animal { CodigoAnimal = codAnimal };
            Consulta = new Consulta { CodConsulta = codConsulta };
            Observacao = observacao;
            Custo = custo;
            TipoExame = tipoExame;
            DataExame = dataExame;
        
         }

        public Exame(int codExame, string observacao)
        {
            CodExame = codExame;
            Observacao = observacao;
        }

        // Métodos de CRUD
       
    }
}



