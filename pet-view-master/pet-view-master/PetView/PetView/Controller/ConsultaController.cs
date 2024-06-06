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

        // Construtor da classe ConsultaController
        public ConsultaController()
        {
            _consultaModel = new ConsultaModel();
        }

        // Método estático para inserir uma consulta
        public static void Insert(ConsultaModel.Consulta consulta)
        {
            ConsultaDAL.Insert(consulta);
        }

        // Método estático para atualizar uma consulta
        public static void Update(ConsultaModel.Consulta consulta)
        {
            // Cria uma conexão com o banco de dados
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            // Define o comando SQL para atualizar uma consulta
            SqlCommand cmd = new SqlCommand("sp_update_consulta", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Adiciona os parâmetros ao comando SQL
            cmd.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = consulta.CodConsulta;
            if (string.IsNullOrWhiteSpace(consulta.Observacao))
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = consulta.Observacao;
            cmd.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = consulta.Sintomas;
            cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = consulta.Diagnostico;

            // Abre a conexão com o banco de dados
            con.Open();

            try
            {
                // Executa o comando SQL
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    // Exibe uma mensagem de sucesso caso a atualização seja realizada com sucesso
                    MessageBox.Show("Consulta registrada com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException e)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção durante a execução do comando SQL
                MessageBox.Show("Erro: " + e.ToString());
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        // Método estático para deletar uma consulta
        public static void DeletarConsulta(ConsultaModel consulta)
        {
            // Este método pode ser implementado conforme necessário para realizar a exclusão de uma consulta
        }
    }
}