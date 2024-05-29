using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView.Data
{
    internal class EnderecoDAL
    {
        public static DataTable GetEndereco(string cep, int numero)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_get_endereco", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cep", cep);
                    command.Parameters.AddWithValue("@numero", numero);

                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                        Console.WriteLine("Consulta de endereço realizada com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log the error)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return dataTable;
        }


    }

}

