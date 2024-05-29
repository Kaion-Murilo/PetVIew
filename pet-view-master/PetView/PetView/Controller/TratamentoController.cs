using System.Data;
using PetView.Models;
using PetView.DAL;

namespace PetView.Controllers
{
    public class TratamentoController
    {
        private readonly TratamentoDAL _tratamentoDal;

        public TratamentoController()
        {
            _tratamentoDal = new TratamentoDAL();
        }

        public static void Insert(Tratamento tratamento)
        {
            TratamentoDAL.Insert(tratamento);
        }

        public DataTable GetTratamentos(string type, string value)
        {
            return TratamentoDAL.Select(type, value);
        }

        public static void Update(Tratamento tratamento)
        {
            TratamentoDAL.Update(tratamento);
        }

        public void DeleteTratamento(int codigoTratamento)
        {
            _tratamentoDal.Delete(codigoTratamento);
        }
    }
}
