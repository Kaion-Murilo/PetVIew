using PetView.Data;
using PetView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView.Controller
{
    internal class ConsultaController
    {
        private ConsultaModel _consultaModel;

        public ConsultaController()
        {
            _consultaModel = new ConsultaModel();
        }

        public  static void Insert(ConsultaModel.Consulta consulta)
        {
            ConsultaDAL.Insert(consulta);
        }

        public static void Update(ConsultaModel.Consulta consulta)
        {
     
        }

        public static void DeletarConsulta(ConsultaModel consulta)
        {
            
        }
    }
}
