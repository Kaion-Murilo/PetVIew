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
        // Método para obter um endereço pelo CEP e número
        public static DataTable GetEndereco(string cep, int numero)
        {
            // Criação de um DataTable para armazenar os dados do endereço
            DataTable dt = new DataTable();

            // Imprime os valores recebidos para busca do endereço no console
            Console.WriteLine($"Foi esses valores CEP:{cep}, numero:{numero}");

            // Chama o método GetEndereco da classe EnderecoDAL para obter os dados do endereço
            dt = EnderecoDAL.GetEndereco(cep, numero);

            // Retorna o DataTable com os dados do endereço
            return dt;
        }
    }
}
