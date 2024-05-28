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

namespace PetView
{
    public partial class FormAgenda : UserControl
    {
        public FormAgenda()
        {
            InitializeComponent();
            CarregaMedico();
        }

        private void CarregaMedico()
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT cod_medico as [CodMed], (CONCAT(RTRIM(nome_med), ', CRMV: ', crmv)) as [Medico] from tbMedico", con);
                SqlDataReader reader;
                con.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CodMed", typeof(int));
                    dt.Columns.Add("Medico", typeof(string));
                    dt.Load(reader);

                    cboMedico.ValueMember = "CodMed";
                    cboMedico.DisplayMember = "Medico";
                    cboMedico.DataSource = dt;
                    cboMedico.SelectedIndex = -1;
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
        }

        private void dgvParametros(String coluna, String valor)
        {
            if (datainicial != "" && datafinal != "" || medico != null)
                dgvAgenda.DataSource = Agenda.Select(datainicial, datafinal, medico);
            else if (datainicial != "" && datafinal != "")
                dgvAgenda.DataSource = Agenda.Select(datainicial, datafinal, medico);

            switch (coluna)
            {
                case "Consulta":
                    dgvAgenda.DataSource = Consulta.Select(coluna, valor);
                    break;

                case "Exame":
                    dgvAgenda.DataSource = Exame.Select(coluna, valor);
                    break;

                case "Tratamento":
                    dgvAgenda.DataSource = Tratamento.Select(coluna, valor);
                    break;

                case "Todos":
                    dgvAgenda.DataSource = Agenda.Select(datainicial, datafinal, medico);
                    break;
            }
        }

        string tipo, datainicial, datafinal;
        int? medico;

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo = cboTipo.Text.ToString();
            dgvParametros(tipo, "");
        }

        private void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            datainicial = dtpDataInicial.Text + "T00:00:00";
            dgvParametros(tipo, "");
        }

        private void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            datafinal = dtpDataFinal.Text + "T00:00:00";
            dgvParametros(tipo, "");
        }

        private void cboMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            medico = Convert.ToInt16(cboMedico.SelectedValue);
            dgvParametros(tipo, "");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tipo = "";
            medico = null;
            datainicial = "";
            datafinal = "";
            CarregaMedico();
            dgvParametros(tipo, "");
        }
    }
}
