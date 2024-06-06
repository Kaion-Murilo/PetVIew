using static PetView.Models.ConsultaModel;

namespace PetView.Models
{
    // Classe Tratamento representa um tratamento médico para um animal em uma clínica veterinária
    public class Tratamento
    {
        // Propriedades da classe Tratamento
        public int CodTratamento { get; set; } // Código único para cada tratamento
        public Medico medico { get; set; } // Objeto Medico associado ao tratamento
        public Animal animal { get; set; } // Objeto Animal que está recebendo o tratamento
        public ConsultaModel consulta { get; set; } // Objeto Consulta associado ao tratamento
        public string Observacao { get; set; } // Observações sobre o tratamento
        public double Custo { get; set; } // Custo do tratamento
        public string TipoTratamento { get; set; } // Tipo do tratamento (por exemplo, cirurgia, fisioterapia, etc.)
        public string DataTratamento { get; set; } // Data do tratamento
        public int CodConsulta { get; } // Código da consulta associada ao tratamento

        // Construtor padrão
        public Tratamento() { }

        // Construtor para inicializar um novo tratamento com detalhes completos
        public Tratamento(string observacao, double custo, string tipoTratamento, string dataTratamento, int codMedico, int codAnimal, int codConsulta)
        {
            medico = new Medico(); // Inicializa um novo objeto Medico
            animal = new Animal(); // Inicializa um novo objeto Animal
            consulta = new ConsultaModel(); // Inicializa um novo objeto ConsultaModel

            // Atribui valores às propriedades
            Observacao = observacao;
            Custo = custo;
            TipoTratamento = tipoTratamento;
            DataTratamento = dataTratamento;
            medico.CodigoMedico = codMedico;
            animal.CodigoAnimal = codAnimal;
            CodConsulta = codConsulta;
        }

        // Construtor para inicializar um novo tratamento com código e observações
        public Tratamento(int codTratamento, string observacoes)
        {
            CodTratamento = codTratamento; // Atribui valor à propriedade CodTratamento
            Observacao = observacoes; // Atribui valor à propriedade Observacao
        }
    }
}
