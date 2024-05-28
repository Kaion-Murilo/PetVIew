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
        private void F_EditDono_Load(object sender, EventArgs e)
        {
            Dono dono = new Dono();
            dono.CodigoDono = id;
            Edit.Update1(id);
            dono.CodigoDono = id;
            Console.WriteLine($"Codigo dono: {id}");
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
        }

    }
}
