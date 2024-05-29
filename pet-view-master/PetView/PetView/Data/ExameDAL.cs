using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using PetView.Models;

namespace PetView.Data
{
    public class ExameDAL
    {
        public static void Insert(Exame exame)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_insert_exame", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = exame.animal.CodigoAnimal;
                cmd.Parameters.Add("@cod_medico", SqlDbType.Int).Value = exame.medico.CodigoMedico;
                cmd.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = exame.consulta;
                cmd.Parameters.Add("@tipo_exame", SqlDbType.VarChar).Value = exame.TipoExame;
                cmd.Parameters.Add("@observacao_exame", SqlDbType.VarChar).Value = string.IsNullOrWhiteSpace(exame.Observacao) ? SqlString.Null : (object)exame.Observacao;
                cmd.Parameters.Add("@custo_exame", SqlDbType.Money).Value = exame.Custo;
                cmd.Parameters.Add("@data_exame", SqlDbType.DateTime).Value = exame.DataExame;

                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Exame registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_exame", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                switch (type)
                {
                    case "Código":
                        cmd.SelectCommand.Parameters.Add("@cod_exame", SqlDbType.Int).Value = Convert.ToInt32(value);
                        break;
                    case "Nome do animal":
                        cmd.SelectCommand.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = value;
                        break;
                    case "Nome do médico":
                        cmd.SelectCommand.Parameters.Add("@nome_medico", SqlDbType.VarChar).Value = value;
                        break;
                    case "Nome do dono":
                        cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                        break;
                    case "Custo":
                        cmd.SelectCommand.Parameters.Add("@custo_exame", SqlDbType.Money).Value = Convert.ToDouble(value);
                        break;
                    case "Tipo":
                        cmd.SelectCommand.Parameters.Add("@tipo_exame", SqlDbType.VarChar).Value = value;
                        break;
                }

                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public static void Update(Exame exame)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_update_exame", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_exame", SqlDbType.Int).Value = exame.CodExame;
                cmd.Parameters.Add("@observacao", SqlDbType.VarChar).Value = string.IsNullOrWhiteSpace(exame.Observacao) ? SqlString.Null : (object)exame.Observacao;

                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Exame atualizado com sucesso!", "Atualização finalizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        public void Delete(int codExame)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_delete_exame", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_exame", SqlDbType.Int).Value = codExame;

                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Exame deletado com sucesso!", "Exclusão finalizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
        }
    }

