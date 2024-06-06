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
            Console.WriteLine("CEP: " + cep);
            Console.WriteLine("Numero: " + numero);
            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                string sql = "SELECT * " +
                    "FROM tbEndereco  WHERE cep =" + cep + " AND numero = " + numero;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (DataColumn col in dataTable.Columns)
                            {
                                Console.WriteLine($"{col.ColumnName}: {row[col]}");
                            }
                            Console.WriteLine(); // Adiciona uma linha em branco entre as linhas para melhor legibilidade
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
        public static void Update(
    string cep, int numero, string rua, string bairro, string complemento,
    string cidade, string uf)
        {
            string connectionString = StringConexao.connectionString;
            Console.WriteLine("Valores recebidos para atualização do endereço:");
            Console.WriteLine($"CEP: {cep}");
            Console.WriteLine($"Número: {numero}");
            Console.WriteLine($"Rua: {rua}");
            Console.WriteLine($"Bairro: {bairro}");
            Console.WriteLine($"Complemento: {complemento}");
            Console.WriteLine($"Cidade: {cidade}");
            Console.WriteLine($"UF: {uf}");
            string sql = @"
        -- Verifica se o endereço existe, se não existir, insere-o
        IF NOT EXISTS (SELECT 1 FROM tbEndereco WHERE cep = @cep AND numero = @numero)
        BEGIN
            INSERT INTO tbEndereco (cep, numero, rua, bairro, complemento, cidade, uf)
            VALUES (@cep, @numero, @rua, @bairro, @complemento, @cidade, @uf);
        END
        ELSE
        BEGIN
            -- Atualiza o endereço se ele já existir
            UPDATE tbEndereco
            SET rua = @rua, bairro = @bairro, complemento = @complemento,
                cidade = @cidade, uf = @uf
            WHERE cep = @cep AND numero = @numero;
        END;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    // Adiciona parâmetros
                    command.Parameters.AddWithValue("@cep", cep);
                    command.Parameters.AddWithValue("@numero", numero);
                    command.Parameters.AddWithValue("@rua", rua);
                    command.Parameters.AddWithValue("@bairro", bairro);
                    command.Parameters.AddWithValue("@complemento", complemento);
                    command.Parameters.AddWithValue("@cidade", cidade);
                    command.Parameters.AddWithValue("@uf", uf);

                    try
                    {
                        connection.Open();
                        // Executa a transação
                        command.ExecuteNonQuery();
                        Console.WriteLine("Endereço atualizado com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log the error)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

        }
    }
}


