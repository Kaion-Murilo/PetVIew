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
            InitializeComponent();
        }


        void LoginSQL()
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                try
                {
                    if ((txtUsuario.Text == "") || (txtSenha.Text == ""))
                    {
                        MessageBox.Show("Digite valores válidos nos campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlCommand scmd = new SqlCommand("sp_logar_usuario", con);
                        scmd.CommandType = CommandType.StoredProcedure;

                        scmd.Parameters.Add("@nome_usuario", SqlDbType.NVarChar).Value = txtUsuario.Text;
                        scmd.Parameters.Add("@senha_usuario", SqlDbType.NVarChar).Value = txtSenha.Text;
                        con.Open();

                        int a = scmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            Estrutura estrutura = new Estrutura();
                            estrutura.Show();
                            this.Hide();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível logar! Verifique o login e a senha.", "Erro ao logar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginSQL();
        }
    }
}
