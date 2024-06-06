using PetView.Data;
using PetView.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView.Controller
{
    internal class ConsultaController
    {
        private ConsultaModel _consultaModel;

        public ConsultaController()
        {
            _consultaModel = new ConsultaModel();
        }

        public  static void Insert(ConsultaModel.Consulta consulta)
        {
            ConsultaDAL.Insert(consulta);
        }

        public static void Update(ConsultaModel.Consulta consulta)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_update_consulta", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = consulta.CodConsulta;
            if (string.IsNullOrWhiteSpace(consulta.Observacao))
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = consulta.Observacao;
            cmd.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = consulta.Sintomas;
            cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = consulta.Diagnostico;

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

        public static void DeletarConsulta(ConsultaModel consulta)
        {
            
        }
    }
}
