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
        public FormAnimal()
        {
            InitializeComponent();
            CarregarDono();
           
        }

        private void CarregarDono()
        {
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
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
        string tempo;
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNomeAnimal.Text) ||
               String.IsNullOrWhiteSpace(nupIdade.Text) ||
               String.IsNullOrWhiteSpace(txtEspecie.Text) ||
               String.IsNullOrWhiteSpace(txtRaca.Text) ||
               String.IsNullOrWhiteSpace(rtxtDescricao.Text) ||
               cboDono.Text == "" || (!rbAnos.Checked && !rbMeses.Checked))
            {
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (rbAnos.Checked)
                        tempo = "Anos";
                    else
                        tempo = "Meses";

                    Animal animal = new Animal(NullableObjs.ToNullableInt(txtRGA.Text), txtNomeAnimal.Text, Convert.ToInt16(nupIdade.Text), tempo, txtEspecie.Text, txtRaca.Text, rtxtDescricao.Text, Convert.ToInt16(cboDono.SelectedValue));
                    AnimalController.Insert(animal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Limpeza();
        }

        private void Limpeza()
        {
            CarregarDono();
            txtEspecie.Text = "";
            txtRaca.Text = "";
            txtNomeAnimal.Text = "";
            nupIdade.Value = 0;
            rbAnos.Checked = false;
            rbMeses.Checked = false;
            txtRGA.Text = "";
            rtxtDescricao.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpeza();
        }
    }
}
