using System.Data;
using PetView.Models;
using PetView.Data;
using PetView.Controller;

namespace PetView.Controllers
{
    public class ExameController
    {
        private readonly ExameDAL _exameDal;

        // Construtor da classe ExameController
        public ExameController()
        {
            // Inicializa o objeto _exameDal com uma instância de ExameDAL
            _exameDal = new ExameDAL();
        }

        // Método para inserir um exame
        public static void Insert(Exame exame)
        {
            ExameDAL.Insert(exame);
        }

        // Método para obter exames com base em um tipo e valor de pesquisa
        public DataTable GetExames(string type, string value)
        {
            return ExameDAL.Select(type, value);
        }

        // Método para atualizar um exame
        public static void Update(Exame exame)
        {
            ExameDAL.Update(exame);
        }

        // Método para excluir um exame pelo código do exame
        public void DeleteExame(int codExame)
        {
            _exameDal.Delete(codExame);
        }
    }
}
