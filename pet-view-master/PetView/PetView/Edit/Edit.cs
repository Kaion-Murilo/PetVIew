using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView.Edit
{
    internal class Edit
    {
        public static DataTable Update1(int id)
        {
            int cod_usuario = id;
            Console.WriteLine($"Codigo dono: {id}");

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_dados_dono", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cod_dono", cod_usuario);

                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                        Console.WriteLine("Deu certo");
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
