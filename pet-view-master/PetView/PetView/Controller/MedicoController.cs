using PetView.Data;
using System.Data;

namespace PetView.Controllers
{
    public class MedicoController
    {
        public static DataTable Select(string type, string value)
        {
            return MedicoData.Select(type, value);
        }

        public static void Insert(Medico medico)
        {
            MedicoData.Insert(medico);
        }
    }
}
