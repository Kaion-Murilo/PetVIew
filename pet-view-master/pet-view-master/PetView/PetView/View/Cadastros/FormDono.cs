using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetView.Controller;
using PetView.Model.Classes.FactoryMethod;

namespace PetView
{
    public partial class FormDono : UserControl
    {
        // Construtor da classe FormDono
        public FormDono()
        {
            InitializeComponent();
            CarregaEstado(); // Chama o método para carregar os estados
        }

        // Método para carregar os estados na combobox
        void CarregaEstado()
        {
            cboUF.Items.Clear();
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }

        // Evento de clique do botão "Cadastrar"
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios foram preenchidos
            if (String.IsNullOrWhiteSpace(txtNomeDono.Text) ||
               String.IsNullOrWhiteSpace(txtEmailDono.Text) ||
               String.IsNullOrWhiteSpace(txtRGDono.Text) ||
               String.IsNullOrWhiteSpace(txtCPF.Text) ||
               String.IsNullOrWhiteSpace(txtCelular.Text) ||
               String.IsNullOrWhiteSpace(txtEndereco.Text) ||
               String.IsNullOrWhiteSpace(txtBairro.Text) ||
               String.IsNullOrWhiteSpace(txtCidade.Text) ||
               String.IsNullOrWhiteSpace(cboUF.Text) ||
               String.IsNullOrWhiteSpace(txtCEP.Text) ||
               String.IsNullOrWhiteSpace(nupNumero.Text) ||
               nupNumero.Text == "0")
            {
                // Exibe uma mensagem de aviso caso algum campo obrigatório não tenha sido preenchido
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Cria uma instância da fábrica de pessoa
                    IPessoaFactory factory = new DonoFactory();

                    // Cria uma nova instância de Dono usando o Factory Method
                    var dono = Dono.CriarDono(factory, txtNomeDono.Text, txtCPF.Text, txtRGDono.Text, txtCelular.Text,
                                              txtTelefone.Text, txtEmailDono.Text, txtCEP.Text, txtBairro.Text,
                                              txtCidade.Text, txtComplemento.Text, Convert.ToInt16(nupNumero.Text),
                                              txtEndereco.Text, cboUF.Text);

                    // Inserir o dono no controlador
                    ControllerDono.insert(dono);
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
            // Limpa os campos do formulário e oculta o controle
            Limpeza();
            this.Visible = false;
        }

        // Método para limpar os campos do formulário
        private void Limpeza()
        {
            // Chama o método para carregar os estados na combobox
            CarregaEstado();

            // Limpa os campos do formulário
            txtNomeDono.Text = "";
            txtEmailDono.Text = "";
            txtRGDono.Text = "";
            txtCPF.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtEndereco.Text = "";
            nupNumero.Value = 0;
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtCEP.Text = "";
        }

        // Evento de clique do botão "Limpar"
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Chama o método para limpar os campos do formulário
            Limpeza();
        }
    }
}