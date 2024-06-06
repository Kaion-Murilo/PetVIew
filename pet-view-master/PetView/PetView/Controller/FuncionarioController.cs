using PetView.Data;
using PetView.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography;
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
        public static void Update(int id,string nomeFunc, 
            string rgFunc, 
            string celular, string cargoFunc, 
            string endereco, string complemento,
            string cidade, string cep, string emailFunc,
            string cpf, 
            string telefone, double salario, int numero, 
            string bairro, string uf)
        {
            EnderecoDAL.Update(cep, numero,endereco, bairro, complemento, cidade, uf);
            FuncionarioDAL.Update(id, endereco, cep,
                numero, bairro, complemento, 
                cidade, uf, nomeFunc, cpf, 
                rgFunc, telefone, celular, emailFunc, cargoFunc,
                salario);
        }
        public static DataTable Get(int id)
        {
            DataTable dt = new DataTable();
            dt = FuncionarioDAL.DadosFunc(id);
            return dt;
        }
        public static void Delete(int id)
        {
            FuncionarioDAL.Delete(id);
        }
    }
}
