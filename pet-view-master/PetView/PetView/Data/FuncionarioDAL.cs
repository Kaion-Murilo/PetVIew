using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetView.Models;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Deployment.Internal;

namespace PetView.Data
{
    public class FuncionarioDAL
    {
        public static DataTable Select(string type, string value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_func", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                switch (type)
                {
                    case "Código":
                        cmd.SelectCommand.Parameters.Add("@cod_funcionario", SqlDbType.Int).Value = Convert.ToInt32(value);
                        break;
                    case "Nome":
                        cmd.SelectCommand.Parameters.Add("@nome_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "CPF":
                        cmd.SelectCommand.Parameters.Add("@cpf_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "RG":
                        cmd.SelectCommand.Parameters.Add("@rg_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "Status":
                        cmd.SelectCommand.Parameters.Add("@status_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "Telefone":
                        cmd.SelectCommand.Parameters.Add("@tel_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "Celular":
                        cmd.SelectCommand.Parameters.Add("@cel_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "Email":
                        cmd.SelectCommand.Parameters.Add("@email_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "Cargo":
                        cmd.SelectCommand.Parameters.Add("@cargo_func", SqlDbType.VarChar).Value = value;
                        break;
                    case "Salário":
                        cmd.SelectCommand.Parameters.Add("@salario_func", SqlDbType.Money).Value = Convert.ToDouble(value);
                        break;
                    default:
                        break;
                }

                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public static void Insert(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_insert_func", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cep", SqlDbType.Char).Value = funcionario.endereco.CEP;
                cmd.Parameters.Add("@numero", SqlDbType.Int).Value = funcionario.endereco.NumCasa;
                cmd.Parameters.Add("@rua", SqlDbType.VarChar).Value = funcionario.endereco.Rua;
                cmd.Parameters.Add("@bairro", SqlDbType.VarChar).Value = funcionario.endereco.Bairro;
                if (string.IsNullOrWhiteSpace(funcionario.endereco.Complemento))
                    cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = funcionario.endereco.Complemento;
                cmd.Parameters.Add("@cidade", SqlDbType.VarChar).Value = funcionario.endereco.Cidade;
                cmd.Parameters.Add("@uf", SqlDbType.Char).Value = funcionario.endereco.UF;
                cmd.Parameters.Add("@nome_func", SqlDbType.VarChar).Value = funcionario.NomeFunc;
                cmd.Parameters.Add("@cargo_func", SqlDbType.VarChar).Value = funcionario.CargoFunc;
                cmd.Parameters.Add("@cpf_func", SqlDbType.Char).Value = funcionario.CPFFunc;
                cmd.Parameters.Add("@rg_func", SqlDbType.Char).Value = funcionario.RGFunc;
                if (string.IsNullOrWhiteSpace(funcionario.TelFunc))
                    cmd.Parameters.Add("@tel_func", SqlDbType.Char).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@tel_func", SqlDbType.Char).Value = funcionario.TelFunc;
                cmd.Parameters.Add("@cel_func", SqlDbType.Char).Value = funcionario.CelFunc;
                if (string.IsNullOrWhiteSpace(funcionario.EmailFunc))
                    cmd.Parameters.Add("@email_func", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@email_func", SqlDbType.VarChar).Value = funcionario.EmailFunc;
                cmd.Parameters.Add("@salario_func", SqlDbType.Money).Value = funcionario.SalarioFunc;

                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Funcionário registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Erro: " + e.ToString());
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }
        public static DataTable DadosFunc(int id)
        {

            DataTable dataTable = new DataTable();
            string sql = "SELECT * FROM tbFuncionario WHERE cod_funcionario = @id";

            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
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
    int codFuncionario, string rua, string cep, int numero,
    string bairro, string complemento,
    string cidade, string uf, string nomeFunc,
    string cpfFunc, string rgFunc,
    string telFunc, string celFunc,
    string emailFunc, string cargoFunc, double salarioFunc)
        {
            string connectionString = StringConexao.connectionString;
           
            string sql = @"
        -- Verifica se o endereço existe, se não existir, insere-o
        IF NOT EXISTS (SELECT 1 FROM tbEndereco WHERE cep = @cep AND numero = @numero)
        BEGIN
            INSERT INTO tbEndereco (cep, numero, rua, bairro, complemento, cidade, uf)
            VALUES (@cep, @numero, @rua, @bairro, @complemento, @cidade, @uf);
        END

        -- Atualiza os dados na tabela tbFuncionario
        UPDATE tbFuncionario 
        SET nome_func = @nome_func, cpf_func = @cpf_func, 
            rg_func = @rg_func, tel_func = @tel_func, 
            cel_func = @cel_func, email_func = @email_func, 
            cargo_func = @cargo_func, salario_func = @salario_func,
            cep_func = @cep, numcasa_func = @numero 
        WHERE cod_funcionario = @cod_funcionario;
    ";
          

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    // Adiciona parâmetros para tbEndereco
                    command.Parameters.AddWithValue("@cep", cep);
                    command.Parameters.AddWithValue("@numero", numero);
                    command.Parameters.AddWithValue("@rua", rua);
                    command.Parameters.AddWithValue("@bairro", bairro);
                    command.Parameters.AddWithValue("@complemento", complemento);
                    command.Parameters.AddWithValue("@cidade", cidade);
                    command.Parameters.AddWithValue("@uf", uf);

                    // Adiciona parâmetros para tbFuncionario
                    command.Parameters.AddWithValue("@cod_funcionario", codFuncionario);
                    command.Parameters.AddWithValue("@nome_func", nomeFunc);
                    command.Parameters.AddWithValue("@cpf_func", cpfFunc);
                    command.Parameters.AddWithValue("@rg_func", rgFunc);
                    command.Parameters.AddWithValue("@tel_func", telFunc);
                    command.Parameters.AddWithValue("@cel_func", celFunc);
                    command.Parameters.AddWithValue("@email_func", emailFunc);
                    command.Parameters.AddWithValue("@cargo_func", cargoFunc);
                    command.Parameters.AddWithValue("@salario_func", salarioFunc);

                    try
                    {
                        connection.Open();
                        // Execute a transação
                        command.ExecuteNonQuery();
                        Console.WriteLine("Dados do funcionário atualizados com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log the error)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }
        public static void Delete(int id)
        {
            int cod_usuario = id;
            

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                string sql = "DELETE FROM tbFuncionario WHERE cod_funcionario = " + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                      
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log the error)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }





    }    }


