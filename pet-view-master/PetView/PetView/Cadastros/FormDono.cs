using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView
{
    public partial class FormDono : UserControl
    {
        public FormDono()
        {
            InitializeComponent();
            CarregaEstado();
        }

        void CarregaEstado()
        {
            cboUF.Items.Clear();
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var dono = new Dono(txtNomeDono.Text, txtCPF.Text, txtRGDono.Text, txtCelular.Text, txtTelefone.Text, txtEmailDono.Text, txtCEP.Text, txtBairro.Text, txtCidade.Text, txtComplemento.Text, Convert.ToInt16(nupNumero.Text), txtEndereco.Text, cboUF.Text);
                    dono.Insert();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpeza();
            this.Visible = false;
        }
    
        private void Limpeza()
        {
            CarregaEstado();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpeza();
        }
    }
}
