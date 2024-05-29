using PetView.Data;
using PetView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView.Controller
{
    internal class FuncionarioController
    {
        public static void Insert(Funcionario funcionario)
        {
            FuncionarioDAL.Insert(funcionario);
        }
        public static void Update(Funcionario funcionario)
        {
            
        }
        public static void Delete(Funcionario funcionario)
        {
           
        }
    }
}
