using PetView.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView.Edit
{
    public partial class F_EditDono : Form
    {
        private int id;

        // Construtor da classe F_EditDono
        public F_EditDono(int id)
        {
            InitializeComponent();
            this.id = id;
            Dono dono = new Dono();
            dono.CodigoDono = id;
            CarregaEstado();
        }

        // Evento de carregamento do formulário
        private void F_EditDono_Load(object sender, EventArgs e)
        {
            Dono dono = new Dono();
            dono.CodigoDono = id;

            DataTable dt = new DataTable();
            dt = ControllerDono.Get(id);

            // Preenchendo os campos do formulário com os dados do dono
            txtNomeDono.Text = dt.Rows[0].Field<string>("nome_dono").ToString();
            txtCPF.Text = dt.Rows[0].Field<string>("cpf_dono").ToString();
            txtRGDono.Text = dt.Rows[0].Field<string>("rg_dono").ToString();
            txtCelular.Text = dt.Rows[0].Field<string>("cel_dono").ToString();
            txtTelefone.Text = dt.Rows[0].Field<string>("tel_dono").ToString();
            txtEmailDono.Text = dt.Rows[0].Field<string>("email_dono").ToString();
            nupNumero.Text = dt.Rows[0].Field<Int32>("numcasa_dono").ToString();

            txtCEP.Text = dt.Rows[0].Field<string>("cep_dono").ToString();

            // Obtendo os dados do endereço
            string cep = txtCEP.Text;
            int numero = int.Parse(nupNumero.Text);
            DataTable dte = ControllerEndereco.GetEndereco(cep, numero);

            if (dte.Rows.Count > 0)
            {
                // Preenchendo os campos de endereço com os dados do DataTable
                txtEndereco.Text = dte.Rows[0]["rua"].ToString();
                txtBairro.Text = dte.Rows[0]["bairro"].ToString();
                txtComplemento.Text = dte.Rows[0]["complemento"].ToString();
                txtCidade.Text = dte.Rows[0]["cidade"].ToString();
                cboUF.Text = dte.Rows[0]["uf"].ToString();
            }

            dono.CodigoDono = id;
        }

        // Método para carregar os estados na combobox
        void CarregaEstado()
        {
            cboUF.Items.Clear();
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }

        // Evento de clique do botão "Editar"
        private void btnEditar_Click(object sender, EventArgs e)
        {
            string nomeDono = txtNomeDono.Text;
            string cpfDono = txtCPF.Text;
            string rgDono = txtRGDono.Text;
            string celDono = txtCelular.Text;
            string telDono = txtTelefone.Text;
            string emailDono = txtEmailDono.Text;
            string cep = txtCEP.Text;
            int numero = int.Parse(nupNumero.Text);

            // Obtendo os dados do endereço
            string rua = txtEndereco.Text;
            string bairro = txtBairro.Text;
            string complemento = txtComplemento.Text;
            string cidade = txtCidade.Text;
            string uf = cboUF.Text;

            // Atualizando os dados do dono no banco de dados
            ControllerDono.UpdateDono(
                codDono: id,
                cep: cep,
                numero: numero,
                rua: rua,
                bairro: bairro,
                complemento: complemento,
                cidade: cidade,
                uf: uf,
                nomeDono: nomeDono,
                cpfDono: cpfDono,
                rgDono: rgDono,
                telDono: telDono,
                celDono: celDono,
                emailDono: emailDono
            );
            Close();
        }

        // Evento de clique do botão "Excluir"
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirmar Exclusao? ", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                ControllerDono.Delete(id);

                Close();
            }
        }
    }
}
            // Exibe um diálogo de confirma