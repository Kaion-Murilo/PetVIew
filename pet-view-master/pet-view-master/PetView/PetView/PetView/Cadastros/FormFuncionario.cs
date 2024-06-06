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
    public partial class FormFuncionario : UserControl
    {
        public FormFuncionario()
        {
            InitializeComponent();
            CarregaEstado();
        }

        void CarregaEstado()
        {
            List<string> estados = new List<string> { "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA","MT","MS","MG","PA","PB","PR","PE","PI","RJ","RN", "RS","RO","RR","SC","SP","SE","TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var funcionario = new Funcionario(txtNomeFunc.Text, txtCPF.Text, txtRGFunc.Text, txtCelular.Text, txtTelefone.Text, txtEmailFunc.Text, txtCargoFunc.Text, Convert.ToDouble(nupSalario.Text), txtCEP.Text, txtBairro.Text, txtCidade.Text, txtComplemento.Text, Convert.ToInt16(nupNumero.Text), txtEndereco.Text, cboUF.Text);
                    funcionario.Insert();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpeza();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Limpeza();
        }
    }
}
