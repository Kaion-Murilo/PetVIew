using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent(); // Inicializa os componentes do formulário
        }

        void LoginSQL()
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                try
                {
                    // Verifica se os campos de usuário e senha estão preenchidos
                    if ((txtUsuario.Text == "") || (txtSenha.Text == ""))
                    {
                        MessageBox.Show("Digite valores válidos nos campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Cria um comando para executar a stored procedure "sp_logar_usuario"
                        SqlCommand scmd = new SqlCommand("sp_logar_usuario", con);
                        scmd.CommandType = CommandType.StoredProcedure;

                        // Adiciona parâmetros ao comando
                        scmd.Parameters.Add("@nome_usuario", SqlDbType.NVarChar).Value = txtUsuario.Text;
                        scmd.Parameters.Add("@senha_usuario", SqlDbType.NVarChar).Value = txtSenha.Text;
                        con.Open();

                        // Executa o comando e verifica o resultado
                        int a = scmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            // Se o login for bem-sucedido, abre a tela principal do sistema
                            Estrutura estrutura = new Estrutura();
                            estrutura.Show();
                            this.Hide(); // Esconde o formulário de login
                            con.Close(); // Fecha a conexão com o banco de dados
                        }
                        else
                        {
                            // Exibe mensagem de erro se o login falhar
                            MessageBox.Show("Não foi possível logar! Verifique o login e a senha.", "Erro ao logar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close(); // Fecha a conexão com o banco de dados
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Exibe mensagem de erro em caso de exceção
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close(); // Garante que a conexão será fechada
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginSQL(); // Chama o método para realizar o login quando o botão é clicado
        }
    }
}