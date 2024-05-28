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
    public partial class FormExame : UserControl
    {
        public FormExame()
        {
            InitializeComponent();
            CarregaCbos();
            CarregaDonos();
        }

        private void DadosExame()
        {
            if (String.IsNullOrWhiteSpace(cboExame.Text))
            {
                rtxtDadosAnimal.Text = "";
                rtxtDadosDono.Text = "";
                rtxtDadosExame.Text = "";
                rtxtObservacoes.Text = "";
            }
            else
            {
                //ANIMAL

                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    try
                    {
                        string sql = "SELECT CONCAT('Nome: ', A.nome_animal) [Nome], CONCAT('Idade: ', A.idade, ' ', A.tipo_idade) [Idade], CONCAT('Espécie: ', A.especie) [Espécie], CONCAT('Raça: ', A.raca_animal) [Raça], CONCAT('Descrição: ', A.descricao) [Descrição] from tbExame E inner join tbAnimal A on A.cod_animal = E.cod_animal where E.cod_exame = " + Convert.ToInt16(cboExame.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtDadosAnimal.Text = reader["Nome"].ToString() + "\n" + reader["Idade"].ToString() + "\n" + reader["Espécie"].ToString() + "\n" + reader["Raça"].ToString() + "\n" + reader["Descrição"].ToString();
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                //DONO

                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    try
                    {
                        string sql = "SELECT CONCAT('Nome: ', D.nome_dono) [Nome], CONCAT('Celular: ', D.cel_dono) [Celular], CONCAT('Telefone: ', D.tel_dono) [Telefone], CONCAT('Email: ', D.email_dono) [Email] from tbExame E inner join tbAnimal A on A.cod_animal = E.cod_animal inner join tbDono D on D.cod_dono = A.cod_dono where E.cod_exame = " + Convert.ToInt16(cboExame.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtDadosDono.Text = reader["Nome"].ToString() + "\n" + reader["Celular"].ToString() + "\n" + reader["Telefone"].ToString() + "\n" + reader["Email"].ToString();
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                //EXAME

                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    try
                    {
                        string sql = "SELECT CONCAT('Tipo: ', tipo_exame) [Tipo], CONCAT('Data: ', data_exame) [Data], CONCAT('Custo: ', custo_exame) [Custo] from tbExame where cod_exame = " + Convert.ToInt16(cboExame.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtDadosExame.Text = reader["Tipo"].ToString() + "\n" + reader["Data"].ToString() + "\n" + reader["Custo"].ToString();
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                //OBSERVAÇÕES

                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    try
                    {
                        string sql = "SELECT observacao_exame [Exame] from tbExame where cod_exame = " + Convert.ToInt16(cboExame.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtObservacoes.Text = reader["Exame"].ToString();
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void CarregaDonos()
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT D.cod_dono as [Codigo], CONCAT(D.nome_dono, ', CPF: ', D.cpf_dono) as [Dono] from tbDono D inner join tbAnimal A on A.cod_dono = D.cod_dono inner join tbExame E on E.cod_animal = A.cod_animal where E.cod_animal = A.cod_animal and E.status_exame = 0", con);
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

        private void CarregaCbos()
        {
            if (cboDono.Text == "")
            {
                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT E.cod_exame as [CodExame],  CONCAT(E.data_exame, ' ', A.nome_animal) as [Data] from tbExame E inner join tbAnimal A on A.cod_animal = E.cod_animal inner join tbMedico M on M.cod_medico = E.cod_medico inner join tbUsuario U on U.cod_medico = M.cod_medico where status_exame = 0 and U.ativacao_usuario = 1 and E.data_exame >= DateAdd(dd, -3, GetDate())", con);
                    SqlDataReader reader;
                    con.Open();
                    try
                    {
                        reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CodExame", typeof(int));
                        dt.Columns.Add("Data", typeof(string));
                        dt.Load(reader);

                        cboExame.ValueMember = "CodExame";
                        cboExame.DisplayMember = "Data";
                        cboExame.DataSource = dt;
                        cboExame.SelectedIndex = -1;
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
            else
            {
                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT E.cod_exame as [CodExame],  CONCAT(E.data_exame, ' ', A.nome_animal) as [Data] from tbExame E inner join tbAnimal A on A.cod_animal = E.cod_animal inner join tbMedico M on M.cod_medico = E.cod_medico inner join tbUsuario U on U.cod_medico = M.cod_medico  inner join tbDono D on D.cod_dono = A.cod_dono where status_exame = 0 and U.ativacao_usuario = 1 and E.data_exame >= DateAdd(dd, -3, GetDate()) and D.cod_dono = " + Convert.ToInt16(cboDono.SelectedValue), con);
                    SqlDataReader reader;
                    con.Open();
                    try
                    {
                        reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CodExame", typeof(int));
                        dt.Columns.Add("Data", typeof(string));
                        dt.Load(reader);

                        cboExame.ValueMember = "CodExame";
                        cboExame.DisplayMember = "Data";
                        cboExame.DataSource = dt;
                        cboExame.SelectedIndex = -1;
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
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(rtxtObservacoes.Text) || String.IsNullOrWhiteSpace(rtxtDadosAnimal.Text))
            {
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Exame exame = new Exame(Convert.ToInt16(cboExame.SelectedValue), rtxtObservacoes.Text);
                exame.Update();
            }
        }

        private void cboExame_SelectedValueChanged(object sender, EventArgs e)
        {
            DadosExame();
        }

        private void cboDono_TextChanged(object sender, EventArgs e)
        {
            CarregaCbos();
        }

        private void Limpeza()
        {
            CarregaCbos();
            CarregaDonos();
            DadosExame();
            rtxtObservacoes.Text = "";
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
