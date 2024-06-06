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
    // Definição da classe para o formulário principal da aplicação, gerenciando diversas funcionalidades e formulários.
    public partial class Estrutura : Form
    {
        // Construtor da classe Estrutura que inicializa os componentes quando o formulário é carregado.
        public Estrutura()
        {
            InitializeComponent();
        }

        // Método para tratar o evento de clique no botão de sair.
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Deslogar();
                Application.Exit();
            }
        }

        // Método para acessar os botões de acordo com o usuário logado.
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

        // Método para ocultar todos os controles de usuário (UserControl).
        void HideAll()
        {
            List<UserControl> list = new List<UserControl> { agendamento1, formAnimal1, formDono1, formFuncionario1, formMedico1, registros1, formAgenda1 };
            list.ForEach(item => item.Visible = false);
        }

        // Método para controlar o clique em botões específicos e a visualização de controles de usuário.
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

        // Método para manipular o clique no botão de cadastro.
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

        // Outros métodos para manipular cliques em botões específicos que mudam a exibição de controles de usuário.
        private void btnAgendamento_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnRegistros_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnAgenda_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnAnimal_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnDono_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnFuncionario_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnMedico_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnConsulta_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnExame_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }
        private void btnTratamento_Click(object sender, EventArgs e) { /* Similar a ClickButton */ }

        // Método chamado quando o formulário é carregado para definir o acesso aos botões.
        private void Estrutura_Load(object sender, EventArgs e)
        {
            AccessButtons();
        }

        // Método para deslogar o usuário atualizando o status no banco de dados.
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

        // Método para tratar o evento de clique no botão de logout, que desloga o usuário e reinicia a aplicação.
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem certeza que deseja deslogar?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Deslogar();
                Application.Restart();
            }
        }

        // Evento de clique para a label de boas-vindas.
        private void lblBemVindo_Click(object sender, EventArgs e)
        {

        }
    }
}