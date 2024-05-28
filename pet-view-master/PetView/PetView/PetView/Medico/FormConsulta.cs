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
    public partial class FormConsulta : UserControl
    {
        public FormConsulta()
        {
            InitializeComponent();
            CarregaCbos();
            CarregaDonos();
         
        }

        private void DadosConsulta()
        {
            if (String.IsNullOrWhiteSpace(cboConsulta.Text))
            {
                rtxtDadosAnimal.Text = "";
                rtxtDadosDono.Text = "";
                rtxtDadosConsulta.Text = "";
                rtxtObservacoes.Text = "";
            }
            else
            {
                //ANIMAL

                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    try
                    {
                        string sql = "SELECT CONCAT('Nome: ', A.nome_animal) [Nome], CONCAT('Idade: ', A.idade, ' ', A.tipo_idade) [Idade], CONCAT('Espécie: ', A.especie) [Espécie], CONCAT('Raça: ', A.raca_animal) [Raça], CONCAT('Descrição: ', A.descricao) [Descrição] from tbConsulta C inner join tbAnimal A on A.cod_animal = C.cod_animal where C.cod_consulta = " + Convert.ToInt16(cboConsulta.SelectedValue);
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
                        string sql = "SELECT CONCAT('Nome: ', D.nome_dono) [Nome], CONCAT('Celular: ', D.cel_dono) [Celular], CONCAT('Telefone: ', D.tel_dono) [Telefone], CONCAT('Email: ', D.email_dono) [Email] from tbConsulta C inner join tbAnimal A on A.cod_animal = C.cod_animal inner join tbDono D on D.cod_dono = A.cod_dono where C.cod_consulta = " + Convert.ToInt16(cboConsulta.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtDadosDono.Text = reader["Nome"].ToString() + "\n" + reader["Celular"].ToString() + "\n" + reader["Telefone"].ToString() + "\n" + reader["Email"].ToString();
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("rtxDADODono");
                            Console.WriteLine("-------------------------------");
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

                //CONSULTA

                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    try
                    {
                        string sql = "SELECT CONCAT('Tipo: ', tipo_consulta) [Tipo], CONCAT('Data: ', data_consulta) [Data], CONCAT('Custo: ', custo_consulta) [Custo] from tbConsulta where cod_consulta = " + Convert.ToInt16(cboConsulta.SelectedValue);
                        con.Open();
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("sql");
                        Console.WriteLine("-------------------------------");
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("rtxDADOConsulats");
                            Console.WriteLine("-------------------------------");
                            rtxtDadosConsulta.Text = reader["Tipo"].ToString() + "\n" + reader["Data"].ToString() + "\n" + reader["Custo"].ToString();
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
                        string sql = "SELECT observacao_consulta [Consulta] from tbConsulta where cod_consulta = " + Convert.ToInt16(cboConsulta.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtObservacoes.Text = reader["Consulta"].ToString();
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
            SqlCommand cmd = new SqlCommand("SELECT D.cod_dono as [Codigo], CONCAT(D.nome_dono, ', CPF: ', D.cpf_dono) as [Dono] from tbDono D inner join tbAnimal A on A.cod_dono = D.cod_dono inner join tbConsulta C on C.cod_animal = A.cod_animal where C.cod_animal = A.cod_animal and C.status_consulta = 0", con);
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
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("CarregarCBos  if");
                    Console.WriteLine("-------------------------------");
                    SqlCommand cmd = new SqlCommand("SELECT C.cod_consulta as [CodConsulta],  CONCAT(C.data_consulta, ' ', A.nome_animal) as [Data] from tbConsulta C inner join tbAnimal A on A.cod_animal = C.cod_animal inner join tbMedico M on M.cod_medico = C.cod_medico inner join tbUsuario U on U.cod_medico = M.cod_medico where status_consulta = 0 and U.ativacao_usuario = 1 and C.data_consulta >= DateAdd(dd, -3, GetDate())", con);
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
            else
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("CarregarCBos  else");
                Console.WriteLine("-------------------------------");
                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT C.cod_consulta as [CodConsulta],  CONCAT(C.data_consulta, ' ', A.nome_animal) as [Data] from tbConsulta C inner join tbAnimal A on A.cod_animal = C.cod_animal inner join tbMedico M on M.cod_medico = C.cod_medico inner join tbUsuario U on U.cod_medico = M.cod_medico inner join tbDono D on D.cod_dono = A.cod_dono where status_consulta = 0 and U.ativacao_usuario = 1 and C.data_consulta >= DateAdd(dd, -3, GetDate()) and D.cod_dono = " + Convert.ToInt16(cboDono.SelectedValue), con);
                    SqlDataReader reader;
                    con.Open();                    
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine(cmd);
                    Console.WriteLine("-------------------------------");
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
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("DT=" + dt);
                        Console.WriteLine("-------------------------------");
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
            if (String.IsNullOrWhiteSpace(rtxtSintomas.Text) ||
               String.IsNullOrWhiteSpace(rtxtDadosDiagnostico.Text) ||
               String.IsNullOrWhiteSpace(rtxtDadosAnimal.Text))
            {
                MessageBox.Show("Preencha todos os campos requeridos.", "Não foi possível criar um novo registro.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Consulta consulta = new Consulta(Convert.ToInt16(cboConsulta.SelectedValue), rtxtSintomas.Text, rtxtDadosDiagnostico.Text, rtxtObservacoes.Text);
                    consulta.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cboDono_TextChanged(object sender, EventArgs e)
        {
            CarregaCbos();
        }

        private void cboConsulta_SelectedValueChanged(object sender, EventArgs e)
        {
            DadosConsulta();
        }

        private void Limpeza()
        {
            CarregaCbos();
            CarregaDonos();
            DadosConsulta();
            rtxtObservacoes.Text = "";
            rtxtSintomas.Text = "";
            rtxtDadosDiagnostico.Text = "";
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
