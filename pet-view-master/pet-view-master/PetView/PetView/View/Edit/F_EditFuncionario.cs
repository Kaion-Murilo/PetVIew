using PetView.Controller;
using PetView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView.View.Edit
{
    public partial class F_EditFuncionario : Form
    {
        private int id;

        public F_EditFuncionario(int id)
        {
            InitializeComponent();
            this.id = id;
            CarregaEstado();
        }

        // Método para carregar os estados na combobox de UF
        void CarregaEstado()
        {
            cboUF.Items.Clear();
            List<string> estados = new List<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            estados.ForEach(item => cboUF.Items.Add(item));
            cboUF.SelectedIndex = -1;
        }

        private void F_EditFuncionario_Load(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data = FuncionarioController.Get(id);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                string cepme = row["cep_func"].ToString().Replace("-", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
                string cpf = row["cpf_func"].ToString().Replace(".", string.Empty).Replace("-", string.Empty);
                string celular = row["cel_func"].ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty);
                string telefone = row["tel_func"].ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty);

                // Preencher os campos com os valores do DataRow
                txtNomeFunc.Text = row["nome_func"].ToString();
                txtRGFunc.Text = row["rg_func"].ToString();
                txtCelular.Text = celular;
                txtCargoFunc.Text = row["cargo_func"].ToString();
                txtCEP.Text = cepme;
                txtEmailFunc.Text = row["email_func"].ToString();
                txtCPF.Text = cpf;
                txtTelefone.Text = telefone;
                nupSalario.Value = Convert.ToDecimal(row["salario_func"]);
                nupNumero.Value = Convert.ToInt32(row["numcasa_func"]);

                string cep = "'" + txtCEP.Text.Replace("(", string.Empty).Replace(")", string.Empty).Replace("_", string.Empty) + "'";
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
            else
            {
                // Lógica para tratar quando não há dados encontrados
                Console.WriteLine("Nenhum funcionário encontrado com o ID fornecido.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Definir os limites máximos para os campos de texto
            int maxNomeLength = 70;
            int maxRGLength = 9;
            int maxCelularLength = 11;
            int maxCargoLength = 30;
            int maxEnderecoLength = 50;
            int maxComplementoLength = 20;
            int maxCidadeLength = 50;
            int maxCEPLength = 8;
            int maxEmailLength = 100;
            int maxCPFLength = 11;
            int maxTelefoneLength = 10;
            int maxNumeroLength = 10;
            int maxBairroLength = 50;
            int maxUFLength = 2;

            // Recuperar os valores dos campos e limitar o comprimento
            string nomeFunc = txtNomeFunc.Text.Substring(0, Math.Min(txtNomeFunc.Text.Length, maxNomeLength));
            string rgFunc = txtRGFunc.Text.Substring(0, Math.Min(txtRGFunc.Text.Length, maxRGLength));
            string celular = txtCelular.Text.Substring(0, Math.Min(txtCelular.Text.Length, maxCelularLength));
            string cargoFunc = txtCargoFunc.Text.Substring(0, Math.Min(txtCargoFunc.Text.Length, maxCargoLength));
            string endereco = txtEndereco.Text.Substring(0, Math.Min(txtEndereco.Text.Length, maxEnderecoLength));
            string complemento = txtComplemento.Text.Substring(0, Math.Min(txtComplemento.Text.Length, maxComplementoLength));
            string cidade = txtCidade.Text.Substring(0, Math.Min(txtCidade.Text.Length, maxCidadeLength));
            string cep = txtCEP.Text.Replace("'", string.Empty).Substring(0, Math.Min(txtCEP.Text.Length, maxCEPLength)); // Remover as aspas simples
            string emailFunc = txtEmailFunc.Text.Substring(0, Math.Min(txtEmailFunc.Text.Length, maxEmailLength));
            string cpf = txtCPF.Text.Substring(0, Math.Min(txtCPF.Text.Length, maxCPFLength));
            string telefone = txtTelefone.Text.Substring(0, Math.Min(txtTelefone.Text.Length, maxTelefoneLength));
            double salario = Convert.ToDouble(nupSalario.Value);
            int numero = Math.Min((int)nupNumero.Value, maxNumeroLength);
            string bairro = txtBairro.Text.Substring(0, Math.Min(txtBairro.Text.Length, maxBairroLength));
            string uf = cboUF.Text.Substring(0, Math.Min(cboUF.Text.Length, maxUFLength));

            // Chamar a função para fazer o update
            FuncionarioController.Update(id, nomeFunc, rgFunc, celular, cargoFunc, endereco, complemento, cidade, cep, emailFunc, cpf, telefone, salario, numero, bairro, uf);
            Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirmar Exclusao? ", "Excluir?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                FuncionarioController.Delete(id);
                Close();
            }
        }
    }
}