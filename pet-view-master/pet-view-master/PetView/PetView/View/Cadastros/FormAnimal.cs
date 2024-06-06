using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PetView.Models;
using PetView.Controllers;
using PetView.Models;
using System.Deployment.Internal;

namespace PetView
{
    public partial class FormAnimal : UserControl
    {
        // Construtor da classe FormAnimal
        public FormAnimal()
        {
            InitializeComponent();
            CarregarDono(); // Chama o método para carregar os dados do dono
        }

        // Método para carregar os dados do dono
        private void CarregarDono()
        {
            // Cria uma conexão com o banco de dados
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT cod_dono as [Codigo], CONCAT(nome_dono, ', CPF: ', cpf_dono) as [Dono] from tbDono", con);
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Codigo", typeof(int));
                dt.Columns.Add("Dono", typeof(string));
                dt.Load(reader);

                cboDono.ValueMember = "Codigo";
                cboDono.DisplayMember = "Dono";
                cboDono.DataSource = dt;
                cboDono.SelectedIndex = -1;
            }
            catch (SqlException e)
            {
                // Lança uma exceção em caso de erro ao executar o comando SQL
                throw new Exception(e.Message);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                con.Close();
            }
        }

        string tempo;

        // Evento de clique do botão "Cadastrar"
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios foram preenchidos
            if (String.IsNullOrWhiteSpace(txtNomeAnimal.Text) ||
               String.IsNullOrWhiteSpace(nupIdade.Text) ||
               String.IsNullOrWhiteSpace(txtEspecie.Text) ||
               String.IsNullOrWhiteSpace(txtRaca.Text) ||
               String.IsNullOrWhiteSpace(rtxtDescricao.Text) ||
               cboDono.Text == "" || (!rbAnos.Checked && !rbMeses.Checked))
            {
                // Exibe uma mensagem de aviso caso algum campo obrigatório não tenha sido preenchido
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Define o valor da variável 'tempo' com base no radio button selecionado
                    if (rbAnos.Checked)
                        tempo = "Anos";
                    else
                        tempo = "Meses";

                    // Cria um objeto 'Animal' com os dados informados
                    Animal animal = new Animal(NullableObjs.ToNullableInt(txtRGA.Text), txtNomeAnimal.Text, Convert.ToInt16(nupIdade.Text), tempo, txtEspecie.Text, txtRaca.Text, rtxtDescricao.Text, Convert.ToInt16(cboDono.SelectedValue));

                    // Chama o método para inserir um novo animal
                    AnimalController.Insert(animal);
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro em caso de exceção
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Evento de clique do botão "Cancelar"
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Oculta o controle do formulário e limpa os campos
            this.Visible = false;
            Limpeza();
        }

        // Método para limpar os campos do formulário
        private void Limpeza()
        {
            // Chama o método para carregar os dados do dono
            CarregarDono();

            // Limpa os campos do formulário
            txtEspecie.Text = "";
            txtRaca.Text = "";
            txtNomeAnimal.Text = "";
            nupIdade.Value = 0;
            rbAnos.Checked = false;
            rbMeses.Checked = false;
            txtRGA.Text = "";
            rtxtDescricao.Text = "";
        }

        // Evento de clique do botão "Limpar"
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Chama o método para limpar os campos do formulário
            Limpeza();
        }
    }
}