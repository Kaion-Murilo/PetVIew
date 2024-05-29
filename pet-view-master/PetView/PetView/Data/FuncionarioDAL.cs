using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetView.Models;

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

        public static void Update(Funcionario funcionario) { }
      

    }
}


