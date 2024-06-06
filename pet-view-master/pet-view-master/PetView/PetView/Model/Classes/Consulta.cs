using System;
using System.Data;
using PetView.DAL;
using PetView.Data;

// Define o namespace do projeto
namespace PetView.Models
{
    // Classe ConsultaModel que representa uma consulta no sistema
    public class ConsultaModel
    {
        // Classe Consulta que representa uma consulta individual
        public class Consulta
        {
            // Propriedades da classe Consulta
            public int CodConsulta { get; set; } // Código único da consulta
            public Medico medico { get; set; } // Objeto Medico que representa o médico da consulta
            public Animal animal { get; set; } // Objeto Animal que representa o animal da consulta
            public String Sintomas { get; set; } // Sintomas apresentados pelo animal
            public String Diagnostico { get; set; } // Diagnóstico da consulta
            public String Observacao { get; set; } // Observações adicionais sobre a consulta
            public double Custo { get; set; } // Custo da consulta
            public String TipoConsulta { get; set; } // Tipo da consulta (ex: Tratamento, emergência)
            public String DataConsulta { get; set; } // Data da consulta

            // Construtor padrão
            public Consulta() { }

            // Construtor para criação de uma consulta por um funcionário
            public Consulta(string observacao, double custo, string tipoConsulta, string dataConsulta, int codMedico, int codAnimal)
            {
                medico = new Medico(); // Cria um novo objeto Medico
                animal = new Animal(); // Cria um novo objeto Animal
                this.Observacao = observacao; // Inicializa a observação da consulta
                this.Custo = custo; // Inicializa o custo da consulta
                this.TipoConsulta = tipoConsulta; // Inicializa o tipo da consulta
                this.DataConsulta = dataConsulta; // Inicializa a data da consulta
                medico.CodigoMedico = codMedico; // Inicializa o código do médico da consulta
                animal.CodigoAnimal = codAnimal; // Inicializa o código do animal da consulta
            }

            // Construtor para atualização de uma consulta por um médico
            public Consulta(int codConsulta, string sintomas, string diagnostico, string observacao)
            {
                this.CodConsulta = codConsulta; // Inicializa o código da consulta
                this.Sintomas = sintomas; // Inicializa os sintomas da consulta
                this.Diagnostico = diagnostico; // Inicializa o diagnóstico da consulta
                this.Observacao = observacao; // Inicializa a observação da consulta
            }

            // Instância da classe ConsultaDAL para interação com o banco de dados
            private ConsultaDAL _consultaDAL;

            // Método para inicializar a instância da classe ConsultaDAL
            public void ConsultaModel()
            {
                _consultaDAL = new ConsultaDAL();
            }

            // Método para selecionar consultas do banco de dados
            public DataTable Select(String type, String value)
            {
                return AnimalDAL.Select(type, value);
            }

            // Método para inserir uma nova consulta no banco de dados
            public void Insert(Consulta consulta)
            {
                consulta.Insert(consulta);
            }

            // Método para atualizar uma consulta existente no banco de dados
            public void Update(Consulta consulta)
            {
                consulta.Update(consulta);
            }

            // Método para deletar uma consulta do banco de dados
            public void Delete(Consulta consulta)
            {
                consulta.Delete(consulta);
            }
        }
    }
}
