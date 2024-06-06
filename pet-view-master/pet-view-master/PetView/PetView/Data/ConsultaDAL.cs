using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Windows.Forms;
using PetView.Models;

namespace PetView.Data
{
        public class ConsultaDAL
        {
        public static void Insert(ConsultaModel.Consulta consulta)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_insert_consulta", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = consulta.animal.CodigoAnimal;
            cmd.Parameters.Add("@cod_medico", SqlDbType.Int).Value = consulta.medico.CodigoMedico;
            cmd.Parameters.Add("@custo_consulta", SqlDbType.Money).Value = consulta.Custo;
            if (string.IsNullOrWhiteSpace(consulta.Observacao))
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = consulta.Observacao;
            cmd.Parameters.Add("@tipo_consulta", SqlDbType.VarChar).Value = consulta.TipoConsulta;
            cmd.Parameters.Add("@data_consulta", SqlDbType.DateTime).Value = consulta.DataConsulta;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Consulta registrada com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_dono", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_dono", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("Nome".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("CPF".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cpf_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("RG".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@rg_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Telefone".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@tel_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Celular".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cel_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Email".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@email_dono", SqlDbType.VarChar).Value = value;
                }
                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public void Update() { }
        public void Delete() { }
    }
}


