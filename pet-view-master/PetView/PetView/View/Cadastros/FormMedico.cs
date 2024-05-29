using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetView.Controllers;

namespace PetView
{
    public partial class FormMedico : UserControl
    {
        public FormMedico()
        {
            InitializeComponent();
            CarregaEstado();
        }

        void CarregaEstado()
        {
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNomeMedico.Text) ||
               String.IsNullOrWhiteSpace(txtEmailMedico.Text) ||
               String.IsNullOrWhiteSpace(txtRGMedico.Text) ||
               String.IsNullOrWhiteSpace(txtCPF.Text) ||
               String.IsNullOrWhiteSpace(txtCRMV.Text) ||
               String.IsNullOrWhiteSpace(txtFuncaoMedico.Text) ||
               String.IsNullOrWhiteSpace(txtCelular.Text) ||
               String.IsNullOrWhiteSpace(txtEndereco.Text) ||
               String.IsNullOrWhiteSpace(txtBairro.Text) ||
               String.IsNullOrWhiteSpace(txtCidade.Text) ||
               String.IsNullOrWhiteSpace(cboUF.Text) ||
               String.IsNullOrWhiteSpace(txtCEP.Text) ||
               String.IsNullOrWhiteSpace(nupNumero.Text) ||
               String.IsNullOrWhiteSpace(nupSalarioMedico.Text) ||
               nupNumero.Text == "0" ||
               nupSalarioMedico.Text == "0")
            {
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                  var medico = new Medico(txtNomeMedico.Text, txtCRMV.Text, txtCPF.Text, txtRGMedico.Text, txtCelular.Text, txtTelefone.Text, txtEmailMedico.Text, txtFuncaoMedico.Text, Convert.ToDouble(nupSalarioMedico.Text), txtCEP.Text, txtBairro.Text, txtCidade.Text, txtComplemento.Text, Convert.ToInt16(nupNumero.Text), txtEndereco.Text, cboUF.Text);
                   MedicoController.Insert(medico);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Limpeza()
        {
            CarregaEstado();
            txtNomeMedico.Text = "";
            txtEmailMedico.Text = "";
            txtRGMedico.Text = "";
            txtCPF.Text = "";
            txtCelular.Text = "";
            txtTelefone.Text = "";
            txtCRMV.Text = "";
            txtFuncaoMedico.Text = "";
            txtEndereco.Text = "";
            nupSalarioMedico.Value = 0;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpeza();
            this.Visible = false;
        }
    }
}
