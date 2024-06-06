using PetView.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PetView.Controller
{
    internal class ControllerDono
    {
        // Método para inserir um novo dono
        public static void insert(Dono dono)
        {
            DonoDAL.Insert(dono);
        }

        // Método para excluir um dono pelo ID
        public static void Delete(int id)
        {
            DonoDAL.Delete(id);
        }

        // Método para obter dados de um dono pelo ID
        public static DataTable Get(int id)
        {
            DataTable dt = new DataTable();
            dt = DonoDAL.GetDadosDono(id);
            return dt;
        }

        // Método para atualizar dados de um dono
        public static void UpdateDono(
            int codDono, string cep, int numero,
            string rua, string bairro, string complemento,
            string cidade, string uf,
            string nomeDono, string cpfDono, string rgDono,
            string telDono, string celDono, string emailDono)
        {
            // Imprimindo os valores recebidos para atualização do endereço no console
            Console.WriteLine($"Entrou em Controller");
            Console.WriteLine("Valores recebidos para atualização do endereço:");
            Console.WriteLine($"CEP: {cep}");
            Console.WriteLine($"Número: {numero}");
            Console.WriteLine($"Rua: {rua}");
            Console.WriteLine($"Bairro: {bairro}");
            Console.WriteLine($"Complemento: {complemento}");
            Console.WriteLine($"Cidade: {cidade}");
            Console.WriteLine($"UF: {uf}");
            Console.WriteLine("----------------------------");

            // Chamando os métodos de atualização de endereço e dono das respectivas classes DAL
            EnderecoDAL.Update(cep, numero, rua, bairro, complemento, cidade, uf);
            DonoDAL.Update(
                codDono, cep, numero, rua, bairro, complemento, cidade, uf,
                nomeDono, cpfDono, rgDono, telDono, celDono, emailDono);
        }
    }
}
