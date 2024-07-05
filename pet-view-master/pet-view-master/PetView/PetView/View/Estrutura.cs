// Bibliotecas necessárias
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

        // Evento de clique no botão "Sair"
        private void btnSair_Click(object sender, EventArgs e)
        {
            // Exibe uma mensagem de confirmação ao usuário
            DialogResult result = MessageBox.Show("Tem certeza que deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Chama o método para deslogar o usuário e fecha a aplicação
                Deslogar();
                Application.Exit();
            }
        }

        // Método para verificar e ajustar os botões de acesso com base no usuário ativo
        void AccessButtons()
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                try
                {
                    // Consulta ao banco de dados para verificar o tipo de usuário ativo
                    string sql = "exec sp_select_usuario_ativo";
                    con.Open();
                    SqlCommand scmd = new SqlCommand(sql, con);
                    SqlDataReader reader = scmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(1))
                        {
                            // Ajusta os botões visíveis para um tipo de usuário
                            lblBemVindo.Text = "Bem vindo(a)!  \n \n" + reader["nome_func"].ToString();
                            reader.Close();
                            List<Button> list = new List<Button> { btnConsulta, btnExame, btnTratamento };
                            list.ForEach(item => item.Visible = false);
                        }
                        else
                        {
                            // Ajusta os botões visíveis para outro tipo de usuário
                            lblBemVindo.Text = "Bem vindo(a)! \n \n" + reader["nome_med"].ToString();
                            reader.Close();
                            List<Button> list = new List<Button> { btnAgendamento, btnCadastro, btnRegistros };
                            list.ForEach(item => item.Visible = false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro em caso de exceção
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // Fecha a conexão com o banco de dados
                    con.Close();
                }
            }
        }

        // Método para ocultar todos os controles de usuário
        void HideAll()
        {
            List<UserControl> list = new List<UserControl> { agendamento1, formAnimal1, formDono1, formFuncionario1, formMedico1, registros1, formAgenda1 };
            list.ForEach(item => item.Visible = false);
        }

        // Método para tratar o clique em um botão de menu
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

        // Evento de clique no botão "Cadastro"
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (!btnAnimal.Visible)
            {
                // Ajusta os botões visíveis quando o painel de cadastro está expandido
                ClickButton(formAgenda1, btnCadastro);
                btnCadastro.Font = new Font(btnCadastro.Font.Name, 14, FontStyle.Bold);
                btnAnimal.Visible = true;
                btnDono.Visible = true;
                btnFuncionario.Visible = true;
                btnMedico.Visible = true;
            }
            else
            {
                // Oculta os botões quando o painel de cadastro está contraído
                List<Button> list = new List<Button> { btnAnimal, btnDono, btnFuncionario, btnMedico };
                list.ForEach(item => item.Visible = false);
                ClickButton(formAgenda1, btnCadastro);
                btnCadastro.Font = new Font(btnCadastro.Font.Name, 14, FontStyle.Bold);
                pnlSeguidora.Location = btnCadastro.Location;
            }
        }

        // Eventos de clique para cada botão de menu
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

        // Evento de carga do formulário principal
        private void Estrutura_Load(object sender, EventArgs e)
        {
            // Chama o método para ajustar os botões de acordo com o usuário ativo
            AccessButtons();
        }

        // Método para deslogar o usuário
        void Deslogar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                try
                {
                    // Abre a conexão com o banco de dados e executa a atualização para desativar o usuário
                    con.Open();
                    string deslogar = "update tbUsuario set ativacao_usuario = 0 where ativacao_usuario = 1;";
                    SqlCommand sair = new SqlCommand(deslogar, con);
                    sair.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Lança uma exceção se ocorrer algum erro durante o processo
                    throw new Exception(ex.Message);
                }
                finally
                {
                    // Fecha a conexão com o banco de dados
                    con.Close();
                }
            }
        }

        // Evento de clique no botão "LogOut"
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Exibe uma mensagem de confirmação ao usuário antes de deslogar
            DialogResult result = MessageBox.Show("Tem certeza que deseja deslogar?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Desloga o usuário e reinicia a aplicação
                Deslogar();
                Application.Restart();
            }
        }

        // Evento de clique no rótulo de boas-vindas (não implementado)
        private void lblBemVindo_Click(object sender, EventArgs e)
        {
            // Este evento não tem implementação neste código
        }
    }
}
