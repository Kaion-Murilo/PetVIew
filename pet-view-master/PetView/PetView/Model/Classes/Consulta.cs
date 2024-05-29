using System;
using System.Data;
using PetView.DAL;
using PetView.Data;

namespace PetView.Models
{
    public class ConsultaModel
    {
        public class Consulta
        {
            public int CodConsulta { get; set; }
            public Medico medico { get; set; }
            public Animal animal { get; set; }
            public String Sintomas { get; set; }
            public String Diagnostico { get; set; }
            public String Observacao { get; set; }
            public double Custo { get; set; }
            public String TipoConsulta { get; set; }
            public String DataConsulta { get; set; }

            public Consulta() { }

            //FUNCIONÁRIO

            public  Consulta(string observacao, double custo, string tipoConsulta, string dataConsulta, int codMedico, int codAnimal)
            {
                medico = new Medico();
                animal = new Animal();
                this.Observacao = observacao;
                this.Custo = custo;
                this.TipoConsulta = tipoConsulta;
                this.DataConsulta = dataConsulta;
                medico.CodigoMedico = codMedico;
                animal.CodigoAnimal = codAnimal;
            }

            //MÉDICO

            public  Consulta(int codConsulta, string sintomas, string diagnostico, string observacao)
            {
                this.CodConsulta = codConsulta;
                this.Sintomas = sintomas;
                this.Diagnostico = diagnostico;
                this.Observacao = observacao;
            }
            private ConsultaDAL _consultaDAL;

            public void ConsultaModel()
            {
                _consultaDAL = new ConsultaDAL();
            }

            public DataTable Select(String type, String value)
            {
                return AnimalDAL.Select(type, value);
            }

            public void Insert(Consulta consulta)
            {
                consulta.Insert(consulta);
            }

            public void Update(Consulta consulta)
            {
                consulta.Update(consulta);
            }

            public void Delete(Consulta consulta)
            {
                consulta.Delete(consulta);
            }
        }
    }
}

