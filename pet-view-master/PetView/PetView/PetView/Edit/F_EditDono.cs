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
        public F_EditDono(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        void CarregaEstado()
        {
            cboUF.Items.Clear();
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            var dono = new Dono(txtNomeDono.Text, txtCPF.Text, txtRGDono.Text, txtCelular.Text, txtTelefone.Text, txtEmailDono.Text, txtCEP.Text, txtBairro.Text, txtCidade.Text, txtComplemento.Text, Convert.ToInt16(nupNumero.Text), txtEndereco.Text, cboUF.Text);
        }
    }
}
