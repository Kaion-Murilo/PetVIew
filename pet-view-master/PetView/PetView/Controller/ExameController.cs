using System.Data;
using PetView.Models;
using PetView.Data;
using PetView.Controller;

namespace PetView.Controllers
{
    public class ExameController
    {
        private readonly ExameDAL _exameDal;

        public ExameController()
        {
            _exameDal = new ExameDAL();
        }

        public static void Insert (Exame exame)
        {
            ExameDAL.Insert(exame);
        }

        public DataTable GetExames(string type, string value)
        {
            return ExameDAL.Select(type, value);
        }

        public  static void Update(Exame exame)
        {
            ExameDAL.Update(exame);
        }

        public void DeleteExame(int codExame)
        {
            _exameDal.Delete(codExame);
        }
    }
}
