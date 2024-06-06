using PetView.Controller;
using PetView.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView.View.Edit
{
    public partial class F_EditMedico : Form
    {
        private int id;
        public F_EditMedico(int id)
        {
            InitializeComponent();
            this.id = id;
            CarregaEstado();
        }
        void CarregaEstado()
        {
            cboUF.Items.Clear();
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }
        private void F_EditMedico_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = MedicoController.Get(id);
            if (dt.Rows.Count > 0)
            {
                {
                    // Preencher os campos com os valores do DataTable
                    txtNomeMedico.Text = dt.Rows[0]["nome_med"].ToString().Trim();

                    txtEmailMedico.Text = dt.Rows[0]["email_med"].ToString();
                    txtRGMedico.Text = dt.Rows[0]["rg_med"].ToString();
                    txtCPF.Text = dt.Rows[0]["cpf_med"].ToString();
                    txtCRMV.Text = dt.Rows[0]["crmv"].ToString();
                    txtFuncaoMedico.Text = dt.Rows[0]["funcao_med"].ToString();
                    txtCelular.Text = dt.Rows[0]["cel_med"].ToString();
                   
                   
                    txtCEP.Text = dt.Rows[0]["cep_med"].ToString();
                    nupNumero.Value = Convert.ToInt32(dt.Rows[0]["numcasa_med"]);
                    nupSalarioMedico.Value = Convert.ToDecimal(dt.Rows[0]["salario_med"]);


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
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Recuperar os valores dos campos de texto
            string nomeMedico = txtNomeMedico.Text.Trim();
            string emailMedico = txtEmailMedico.Text.Trim();
            string rgMedico = txtRGMedico.Text.Trim();
            string cpfMedico = txtCPF.Text.Trim();
            int crmv = int.Parse(txtCRMV.Text.Trim()); // Suponho que o CRMV seja um número inteiro
            string funcaoMedico = txtFuncaoMedico.Text.Trim();
            string celularMedico = txtCelular.Text.Trim();
            string telefoneMedico = txtTelefone.Text.Trim();
            string enderecoMedico = txtEndereco.Text.Trim();
            string bairroMedico = txtBairro.Text.Trim();
            string cidadeMedico = txtCidade.Text.Trim();
            string ufMedico = cboUF.Text.Trim();
            string cepMedico = txtCEP.Text.Trim();
            int numcasaMedico = (int)nupNumero.Value;
            double salarioMedico = (double)nupSalarioMedico.Value;
            string complementoMedico = txtComplemento.Text.Trim();

            // Chamar a função para fazer o update do médico
            MedicoController.UpdateMedico(
                codMedico: id,
                nomeMedico: nomeMedico,
                emailMedico: emailMedico,
                rgMedico: rgMedico,
                cpfMedico: cpfMedico,
                crmv: crmv,
                funcaoMedico: funcaoMedico,
                celularMedico: celularMedico,
                telefoneMedico: telefoneMedico,
                enderecoMedico: enderecoMedico,
                bairroMedico: bairroMedico,
                cidadeMedico: cidadeMedico,
                ufMedico: ufMedico,
                cepMedico: cepMedico,
                numcasaMedico: numcasaMedico,
                salario: salarioMedico,
                complementoMedico: complementoMedico
            );

            Close();
        }

        private void btnExlcuir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirmar Exclusao? ", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                MedicoController.Delete(id);

                Close();
            }
        }
    }
}
