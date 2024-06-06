using System.Data;
using PetView.Models;
using PetView.DAL;

namespace PetView.Controllers
{
    public class TratamentoController
    {
        private readonly TratamentoDAL _tratamentoDal;

        // Construtor da classe TratamentoController
        public TratamentoController()
        {
            // Inicializa o objeto _tratamentoDal com uma instância de TratamentoDAL
            _tratamentoDal = new TratamentoDAL();
        }

        // Método para inserir um tratamento
        public static void Insert(Tratamento tratamento)
        {
            TratamentoDAL.Insert(tratamento);
        }

        // Método para obter tratamentos com base em um tipo e valor de pesquisa
        public DataTable GetTratamentos(string type, string value)
        {
            return TratamentoDAL.Select(type, value);
        }

        // Método para atualizar um tratamento
        public static void Update(Tratamento tratamento)
        {
            TratamentoDAL.Update(tratamento);
        }

        // Método para excluir um tratamento pelo código do tratamento
        public void DeleteTratamento(int codigoTratamento)
        {
            _tratamentoDal.Delete(codigoTratamento);
        }
    }
}
