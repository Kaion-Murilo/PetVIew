using PetView.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView.Controller
{
    internal class ControllerEndereco
    {
        public static DataTable GetEndereco(string cep, int numero)
        {
            DataTable dt = new DataTable();
            Console.WriteLine($"Foi esses valores CEP:{cep} ,numero:{numero}");
            dt = EnderecoDAL.GetEndereco(cep, numero);
            
            return dt;
        }

    }
}
