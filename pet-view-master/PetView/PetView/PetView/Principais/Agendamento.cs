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
    public partial class Agendamento : UserControl
    {
        public Agendamento()
        {
            InitializeComponent();
            CarregarCBOS();
        }

        private void CarregarCBOS()
        {
            cboTipoAgendamento.Items.Clear();
            List<string> tipoagend = new List<string> { "Consulta", "Exame", "Tratamento" };
            tipoagend.ForEach(item => cboTipoAgendamento.Items.Add(item));
            cboTipoAgendamento.SelectedIndex = -1;

            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT cod_dono as [CodDono], CONCAT(nome_dono, ', CPF: ', cpf_dono) as [Dono] from tbDono", con);
                SqlDataReader reader;
                con.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CodDono", typeof(int));
                    dt.Columns.Add("Dono", typeof(string));
                    dt.Load(reader);

                    cboDono.ValueMember = "CodDono";
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

                    cboMed.ValueMember = "CodMed";
                    cboMed.DisplayMember = "Medico";
                    cboMed.DataSource = dt;
                    cboMed.SelectedIndex = -1;
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

        private void TipoAgendamentos(string agendamento)
        {
            if ("Consulta".Equals(agendamento))
            {
                cboTipo.Items.Clear();
                List<string> consultas = new List<string> { "Emergencial", "Agendada", "Checkup" };
                consultas.ForEach(item => cboTipo.Items.Add(item));
                cboTipo.SelectedIndex = -1;
                cboConsulta.Visible = false;
                lblConsultaAnterior.Visible = false;
            }
            else if ("Exame".Equals(agendamento))
            {
                cboTipo.Items.Clear();
                List<string> exames = new List<string> { "Sangue", "Urina e fezes", "Radiográfico" };
                exames.ForEach(item => cboTipo.Items.Add(item));
                cboTipo.SelectedIndex = -1;
            }
            else
            {
                cboTipo.Items.Clear();
                List<string> tratamentos = new List<string> { "Fisioterapia", "Vacina", "Fraturas", "Laserterapia" };
                tratamentos.ForEach(item => cboTipo.Items.Add(item));
                cboTipo.SelectedIndex = -1;
            }
        }

        private void CarregaCBOConsulta()
        {
            cboConsulta.Visible = true;
            lblConsultaAnterior.Visible = true;
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT C.cod_consulta as [CodConsulta],  CONCAT(C.data_consulta, ' ', A.nome_animal) as [Data] from tbConsulta C inner join tbAnimal A on A.cod_animal = C.cod_animal where status_consulta = 1 and C.cod_animal = " + Convert.ToInt16(cboAnimal.SelectedValue), con);
                SqlDataReader reader;
                con.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CodConsulta", typeof(int));
                    dt.Columns.Add("Data", typeof(string));
                    dt.Load(reader);

                    cboConsulta.ValueMember = "CodConsulta";
                    cboConsulta.DisplayMember = "Data";
                    cboConsulta.DataSource = dt;
                    cboConsulta.SelectedIndex = -1;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void cboDono_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT cod_animal as [CodAnimal], nome_animal as [Animal] from tbAnimal where cod_dono = " + Convert.ToInt16(cboDono.SelectedValue), con);
                SqlDataReader reader;
                con.Open();
                try
                {
                    reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CodAnimal", typeof(int));
                    dt.Columns.Add("Animal", typeof(string));
                    dt.Load(reader);

                    cboAnimal.ValueMember = "CodAnimal";
                    cboAnimal.DisplayMember = "Animal";
                    cboAnimal.DataSource = dt;
                    cboAnimal.SelectedIndex = -1;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void cboAnimal_TextChanged(object sender, EventArgs e)
        {
            if (cboTipoAgendamento.Text == "Exame" || cboTipoAgendamento.Text == "Tratamento")
                CarregaCBOConsulta();
        }

        private void cboTipoAgendamento_TextChanged(object sender, EventArgs e)
        {
            TipoAgendamentos(cboTipoAgendamento.Text.ToString());
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string aa = dtpData.Text + "T" + dtpHora.Text;

            //2016-03-08T08:00:00

            if (cboTipoAgendamento.Text == "" ||
               cboDono.Text == "" ||
               cboAnimal.Text == "" ||
               cboMed.Text == "" ||
               dtpData.Text == "" ||
               dtpHora.Text == "" ||
               cboTipoAgendamento.Text == "" ||
               (cboTipoAgendamento.Text != "Consulta" && cboConsulta.Text == ""))
            {
                MessageBox.Show("Somente o campo de observações pode ficar vazio, verifique se os demais campos estão preenchidos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if ("Exame".Equals(cboTipoAgendamento.Text))
                {
                    Exame exame = new Exame(rtxtObs.Text, Convert.ToDouble(nupCusto.Value), cboTipo.Text, aa, Convert.ToInt16(cboAnimal.SelectedValue), Convert.ToInt16(cboMed.SelectedValue), Convert.ToInt16(cboConsulta.SelectedValue));
                    exame.Insert();
                }
                else if ("Consulta".Equals(cboTipoAgendamento.Text))
                {
                    Consulta consulta = new Consulta(rtxtObs.Text, Convert.ToDouble(nupCusto.Value), cboTipo.Text, aa, Convert.ToInt16(cboMed.SelectedValue), Convert.ToInt16(cboAnimal.SelectedValue));
                    consulta.Insert();
                }
                else
                {
                    Tratamento tratamento = new Tratamento(rtxtObs.Text, Convert.ToDouble(nupCusto.Value), cboTipo.Text, aa, Convert.ToInt16(cboMed.SelectedValue), Convert.ToInt16(cboAnimal.SelectedValue), Convert.ToInt16(cboConsulta.SelectedValue));
                    tratamento.Insert();
                }
            }
        }
        
        private void Limpeza()
        {
            CarregarCBOS();
            nupCusto.Value = 0;
            rtxtObs.Text = "";
            cboTipo.SelectedIndex = -1;
            cboConsulta.SelectedIndex = -1;
            cboConsulta.Visible = false;
            lblConsultaAnterior.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpeza();
            this.Visible = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpeza();
        }
    }
}
