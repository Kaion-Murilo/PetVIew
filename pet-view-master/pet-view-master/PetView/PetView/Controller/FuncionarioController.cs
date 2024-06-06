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
        // Método para inserir um funcionário
        public static void Insert(Funcionario funcionario)
        {
            FuncionarioDAL.Insert(funcionario);
        }

        // Método para atualizar um funcionário
        public static void Update(int id, string nomeFunc,
            string rgFunc,
            string celular, string cargoFunc,
            string endereco, string complemento,
            string cidade, string cep, string emailFunc,
            string cpf,
            string telefone, double salario, int numero,
            string bairro, string uf)
        {
            // Atualiza o endereço do funcionário
            EnderecoDAL.Update(cep, numero, endereco, bairro, complemento, cidade, uf);

            // Atualiza os dados do funcionário
            FuncionarioDAL.Update(id, endereco, cep,
                numero, bairro, complemento,
                cidade, uf, nomeFunc, cpf,
                rgFunc, telefone, celular, emailFunc, cargoFunc,
                salario);
        }

        // Método para obter os dados de um funcionário pelo ID
        public static DataTable Get(int id)
        {
            DataTable dt = new DataTable();
            dt = FuncionarioDAL.DadosFunc(id);
            return dt;
        }

        // Método para excluir um funcionário pelo ID
        public static void Delete(int id)
        {
            FuncionarioDAL.Delete(id);
        }
    }
}
