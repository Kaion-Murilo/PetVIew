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
        public F_EditDono(int id)
        {
            InitializeComponent();
            this.id = id;
            Dono dono = new Dono();
            dono.CodigoDono = id;
            CarregaEstado();

        }
        private void F_EditDono_Load(object sender, EventArgs e)
        {
            Dono dono = new Dono();
            dono.CodigoDono = id;
            
            DataTable dt = new DataTable();
            
            dt = ControllerDono.Get(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                // Itera sobre as linhas do DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Itera sobre as colunas do DataTable
                    foreach (DataColumn col in dt.Columns)
                    {
                        // Imprime o nome da coluna e o valor da célula
                        Console.WriteLine($"{col.ColumnName}: {row[col]}");
                    }
                    Console.WriteLine(); // Adiciona uma linha em branco entre as linhas
                }
            }
            else
            {
                Console.WriteLine("Nenhum dado encontrado no DataTable.");
            }
            Console.WriteLine($"Codigo dono View: {id}");
            
            txtNomeDono.Text = dt.Rows[0].Field<string>("nome_dono").ToString();
            txtCPF.Text = dt.Rows[0].Field<string>("cpf_dono").ToString();
            txtRGDono.Text = dt.Rows[0].Field<string>("rg_dono").ToString();
            txtCelular.Text = dt.Rows[0].Field<string>("cel_dono").ToString();
            txtTelefone.Text = dt.Rows[0].Field<string>("tel_dono").ToString();
            //txtEndereco.Text = dt.Rows[0].Field<string>("").ToString();
            txtEmailDono.Text = dt.Rows[0].Field<string>("email_dono").ToString();
            nupNumero.Text = dt.Rows[0].Field<Int32>("numcasa_dono").ToString();
            //txtComplemento.Text = dt.Rows[0].Field<string>("complemento").ToString();
            //txtBairro.Text = dt.Rows[0].Field<string>("bairro").ToString();
            //txtCidade.Text = dt.Rows[0].Field<string>("cidade").ToString();
            //cboUF.Text = dt.Rows[0].Field<string>("uf").ToString();
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
            Console.WriteLine($"Frinm: {id}");
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
            Console.WriteLine($"Entrou em Editar");
            string nomeDono = txtNomeDono.Text;
            string cpfDono = txtCPF.Text;
            string rgDono = txtRGDono.Text;
            string celDono = txtCelular.Text;
            string telDono = txtTelefone.Text;
            string emailDono = txtEmailDono.Text;
            string cep = txtCEP.Text;
            int numero = int.Parse(nupNumero.Text);

            // Obtendo os dados do endereço
            DataTable dte = ControllerEndereco.GetEndereco(cep, numero);

            string rua = dte.Rows.Count > 0 ? dte.Rows[0]["rua"].ToString() : string.Empty;
            string bairro = dte.Rows.Count > 0 ? dte.Rows[0]["bairro"].ToString() : string.Empty;
            string complemento = dte.Rows.Count > 0 ? dte.Rows[0]["complemento"].ToString() : string.Empty;
            string cidade = dte.Rows.Count > 0 ? dte.Rows[0]["cidade"].ToString() : string.Empty;
            string uf = dte.Rows.Count > 0 ? dte.Rows[0]["uf"].ToString() : string.Empty;

            
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
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ControllerDono.Delete(id);
        }
    }
}
