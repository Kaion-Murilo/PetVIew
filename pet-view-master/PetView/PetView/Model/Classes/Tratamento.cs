using static PetView.Models.ConsultaModel;

namespace PetView.Models
{
    public class Tratamento
    {
        public int CodTratamento { get; set; }
        public Medico medico { get; set; }
        public Animal animal { get; set; }
        public ConsultaModel consulta { get; set; }
        public string Observacao { get; set; }
        public double Custo { get; set; }
        public string TipoTratamento { get; set; }
        public string DataTratamento { get; set; }
        public int CodConsulta { get; }

        public Tratamento() { }

        public Tratamento(string observacao, double custo, string tipoTratamento, string dataTratamento, int codMedico, int codAnimal, int codConsulta)
        {
            medico = new Medico();
            animal = new Animal();
            consulta = new ConsultaModel        (); // Aqui, inicializamos uma instância de Consulta, não de ConsultaModel

            Observacao = observacao;
            Custo = custo;
            TipoTratamento = tipoTratamento;
            DataTratamento = dataTratamento;
            medico.CodigoMedico = codMedico;
            animal.CodigoAnimal = codAnimal;
            CodConsulta = codConsulta;
        }


        public Tratamento(int codTratamento, string observacoes)
        {
            CodTratamento = codTratamento;
            Observacao = observacoes;
        }
    }
}
