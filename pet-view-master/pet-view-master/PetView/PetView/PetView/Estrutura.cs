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
    public partial class Estrutura : Form
    {
        public Estrutura()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Deslogar();
                Application.Exit();
            }
        }

        void AccessButtons()
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                try
                {
                    string sql = "exec sp_select_usuario_ativo";
                    con.Open();
                    SqlCommand scmd = new SqlCommand(sql, con);
                    SqlDataReader reader = scmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(1))
                        {
                            lblBemVindo.Text = "Bem vindo(a)!  \n \n" + reader["nome_func"].ToString();
                            reader.Close();
                            List<Button> list = new List<Button> { btnConsulta, btnExame, btnTratamento };
                            list.ForEach(item => item.Visible = false);
                        }
                        else
                        {
                            lblBemVindo.Text = "Bem vindo(a)! \n \n" + reader["nome_med"].ToString();
                            reader.Close();
                            List<Button> list = new List<Button> { btnAgendamento, btnCadastro, btnRegistros };
                            list.ForEach(item => item.Visible = false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        void HideAll()
        {
            List<UserControl> list = new List<UserControl> { agendamento1, formAnimal1, formDono1, formFuncionario1, formMedico1, registros1, formAgenda1 };
            list.ForEach(item => item.Visible = false);
        }

        void ClickButton(UserControl usercontrol, Button button)
        {
            List<Button> list = new List<Button> { btnConsulta, btnExame, btnTratamento, btnAgendamento, btnCadastro, btnAnimal, btnDono, btnFuncionario, btnMedico, btnRegistros, btnAgenda, btnLogOut };
            list.ForEach(item => item.Font = new Font(btnAgendamento.Font.Name, 14, FontStyle.Regular));
            button.Font = new Font(button.Font.Name, 14, FontStyle.Bold);
            usercontrol.Visible = true;
            usercontrol.BringToFront();
            usercontrol.Dock = DockStyle.Fill;
            pnlSeguidora.Visible = true;
            if (button != btnCadastro) { pnlSeguidora.Location = button.Location; }
            else { pnlSeguidora.Location = btnConsulta.Location; HideAll(); }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (!btnAnimal.Visible)
            {
                ClickButton(formAgenda1, btnCadastro);
                btnCadastro.Font = new Font(btnCadastro.Font.Name, 14, FontStyle.Bold);
                btnAnimal.Visible = true;
                btnDono.Visible = true;
                btnFuncionario.Visible = true;
                btnMedico.Visible = true;
            }
            else
            {
                List<Button> list = new List<Button> { btnAnimal, btnDono, btnFuncionario, btnMedico };
                list.ForEach(item => item.Visible = false);
                ClickButton(formAgenda1, btnCadastro);
                btnCadastro.Font = new Font(btnCadastro.Font.Name, 14, FontStyle.Bold);
                pnlSeguidora.Location = btnCadastro.Location;
            }
        }

        private void btnAgendamento_Click(object sender, EventArgs e)
        {
            ClickButton(agendamento1, btnAgendamento);
        }


        private void btnRegistros_Click(object sender, EventArgs e)
        {
            ClickButton(registros1, btnRegistros);
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            ClickButton(formAgenda1, btnAgenda);
        }

        private void btnAnimal_Click(object sender, EventArgs e)
        {
            ClickButton(formAnimal1, btnAnimal);
        }

        private void btnDono_Click(object sender, EventArgs e)
        {
            ClickButton(formDono1, btnDono);
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            ClickButton(formFuncionario1, btnFuncionario);
        }

        private void btnMedico_Click(object sender, EventArgs e)
        {
            ClickButton(formMedico1, btnMedico);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            ClickButton(formConsulta1, btnConsulta);
        }

        private void btnExame_Click(object sender, EventArgs e)
        {
            ClickButton(formExame1, btnExame);
        }

        private void btnTratamento_Click(object sender, EventArgs e)
        {
            ClickButton(formTratamento1, btnTratamento);
        }

        private void Estrutura_Load(object sender, EventArgs e)
        {
            AccessButtons();
        }

        void Deslogar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                try
                {
                    con.Open();
                    string deslogar = "update tbUsuario set ativacao_usuario = 0 where ativacao_usuario = 1;";
                    SqlCommand sair = new SqlCommand(deslogar, con);
                    sair.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja deslogar?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Deslogar();
                Application.Restart();
            }
        }

        private void lblBemVindo_Click(object sender, EventArgs e)
        {

        }
    }
}
