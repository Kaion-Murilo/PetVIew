using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetView.Models;
using PetView.Controller;

namespace PetView
{
    public partial class FormFuncionario : UserControl
    {
        // Construtor da classe FormFuncionario
        public FormFuncionario()
        {
            InitializeComponent();
            CarregaEstado(); // Chama o método para carregar os estados na combobox
        }

        // Método para carregar os estados na combobox
        void CarregaEstado()
        {
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }

        // Evento de clique do botão "Cadastrar"
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios foram preenchidos
            if (String.IsNullOrWhiteSpace(txtNomeFunc.Text) ||
               String.IsNullOrWhiteSpace(txtRGFunc.Text) ||
               String.IsNullOrWhiteSpace(txtCPF.Text) ||
               String.IsNullOrWhiteSpace(txtCargoFunc.Text) ||
               String.IsNullOrWhiteSpace(txtCelular.Text) ||
               String.IsNullOrWhiteSpace(txtEndereco.Text) ||
               String.IsNullOrWhiteSpace(txtBairro.Text) ||
               String.IsNullOrWhiteSpace(txtCidade.Text) ||
               String.IsNullOrWhiteSpace(cboUF.Text) ||
               String.IsNullOrWhiteSpace(txtCEP.Text) ||
               String.IsNullOrWhiteSpace(nupNumero.Text) ||
               String.IsNullOrWhiteSpace(nupSalario.Text) ||
               nupNumero.Text == "0" ||
               nupSalario.Text == "0")
            {
                // Exibe uma mensagem de aviso caso algum campo obrigatório não tenha sido preenchido
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Cria uma nova instância de Funcionario com os dados fornecidos
                    var funcionario = new Funcionario(txtNomeFunc.Text,
                        txtCPF.Text, txtRGFunc.Text, txtCelular.Text,
                        txtTelefone.Text, txtEmailFunc.Text,
                        txtCargoFunc.Text,
                        Convert.ToDouble(nupSalario.Text), txtCEP.Text, txtBairro.Text, txtCidade.Text, txtComplemento.Text,
                        Convert.ToInt16(nupNumero.Text), txtEndereco.Text, cboUF.Text);

                    // Insere o funcionário no banco de dados
                    FuncionarioController.Insert(funcionario);
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro em caso de exceção
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Método para limpar os campos do formulário
        private void Limpeza()
        {
            // Chama o método para carregar os estados na combobox
            CarregaEstado();

            // Limpa os campos do formulário
            txtNomeFunc.Text = "";
            txtEmailFunc.Text = "";
            txtRGFunc.Text = "";
            txtCPF.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtCargoFunc.Text = "";
            txtEndereco.Text = "";
            nupSalario.Value = 0;
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

        // Evento de clique do botão "Cancelar"
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Oculta o controle e limpa os campos do formulário
            this.Visible = false;
            Limpeza();
        }
    }
}