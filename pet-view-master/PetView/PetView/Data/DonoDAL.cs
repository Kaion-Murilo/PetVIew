using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PetView.Data
    {
    public class DonoDAL
    {
        private readonly string _connectionString;

        public DonoDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static void Insert(Dono dono)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_insert_dono", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cep", SqlDbType.Char).Value = dono.Endereco.CEP;
            cmd.Parameters.Add("@numero", SqlDbType.Int).Value = dono.Endereco.NumCasa;
            cmd.Parameters.Add("@rua", SqlDbType.VarChar).Value = dono.Endereco.Rua;
            cmd.Parameters.Add("@bairro", SqlDbType.VarChar).Value = dono.Endereco.Bairro;
            cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = string.IsNullOrWhiteSpace(dono.Endereco.Complemento) ? DBNull.Value : (object)dono.Endereco.Complemento;
            cmd.Parameters.Add("@cidade", SqlDbType.VarChar).Value = dono.Endereco.Cidade;
            cmd.Parameters.Add("@uf", SqlDbType.Char).Value = dono.Endereco.UF;
            cmd.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = dono.Nome;
            cmd.Parameters.Add("@cpf_dono", SqlDbType.Char).Value = dono.CPF;
            cmd.Parameters.Add("@rg_dono", SqlDbType.Char).Value = dono.RG;
            cmd.Parameters.Add("@tel_dono", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(dono.TelDono) ? SqlString.Null : (object)dono.TelDono;
            cmd.Parameters.Add("@cel_dono", SqlDbType.Char).Value = dono.Cel;
            cmd.Parameters.Add("@email_dono", SqlDbType.VarChar).Value = string.IsNullOrWhiteSpace(dono.Email) ? SqlString.Null : (object)dono.Email;
            Console.WriteLine($"FEz o inster dono");
            con.Open();
            cmd.ExecuteNonQuery();

            try
            {


                MessageBox.Show("Dono registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Erro: " + e.ToString());
            }
            finally
            {
                con.Close();
            }

        }

        public static DataTable Select(string type, string value)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlDataAdapter cmd = new SqlDataAdapter("sp_select_dono", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

            switch (type)
            {
                case "Código":
                    cmd.SelectCommand.Parameters.Add("@cod_dono", SqlDbType.Int).Value = Convert.ToInt32(value);
                    break;
                case "Nome":
                    cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                    break;
                case "CPF":
                    cmd.SelectCommand.Parameters.Add("@cpf_dono", SqlDbType.VarChar).Value = value;
                    break;
                case "RG":
                    cmd.SelectCommand.Parameters.Add("@rg_dono", SqlDbType.VarChar).Value = value;
                    break;
                case "Telefone":
                    cmd.SelectCommand.Parameters.Add("@tel_dono", SqlDbType.VarChar).Value = value;
                    break;
                case "Celular":
                    cmd.SelectCommand.Parameters.Add("@cel_dono", SqlDbType.VarChar).Value = value;
                    break;
                case "Email":
                    cmd.SelectCommand.Parameters.Add("@email_dono", SqlDbType.VarChar).Value = value;
                    break;
            }

            DataTable dtbl = new DataTable();
            cmd.Fill(dtbl);
            return dtbl;

        }

        public void Update(Dono dono)
        {
            // Implementar a lógica de atualização de dados
        }

        public static void Delete(int id)
        {
            int cod_usuario = id;
            Console.WriteLine($"Codigo dono: {id}");

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_delete_dono", connection))
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
        }

        public static DataTable GetDadosDono(int id)
        {
            int cod_usuario = id;
            Console.WriteLine($"Codigo dono GET: {id}");

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
                        Console.WriteLine("Deu certo o GET ma ta estrano");
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
                int codDono, string cep, int numero, string rua, string bairro, string complemento,
                string cidade, string uf, string nomeDono, string cpfDono, string rgDono,
                string telDono, string celDono, string emailDono)
        {
            Console.WriteLine($"Entrou em DAL");
            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_update_dono", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@cod_dono", codDono);
                    command.Parameters.AddWithValue("@cep", cep);
                    command.Parameters.AddWithValue("@numero", numero);
                    command.Parameters.AddWithValue("@rua", rua);
                    command.Parameters.AddWithValue("@bairro", bairro);
                    command.Parameters.AddWithValue("@complemento", complemento);
                    command.Parameters.AddWithValue("@cidade", cidade);
                    command.Parameters.AddWithValue("@uf", uf);
                    command.Parameters.AddWithValue("@nome_dono", nomeDono);
                    command.Parameters.AddWithValue("@cpf_dono", cpfDono);
                    command.Parameters.AddWithValue("@rg_dono", rgDono);
                    command.Parameters.AddWithValue("@tel_dono", telDono);
                    command.Parameters.AddWithValue("@cel_dono", celDono);
                    command.Parameters.AddWithValue("@email_dono", emailDono);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Dados do dono atualizados com sucesso.");
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
