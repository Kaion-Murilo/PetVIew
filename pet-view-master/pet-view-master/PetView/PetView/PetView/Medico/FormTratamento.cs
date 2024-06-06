﻿using System;
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
    public partial class FormTratamento : UserControl
    {
        public FormTratamento()
        {
            InitializeComponent();
            CarregaCbos();
            CarregaDonos();
        }

        private void DadosTratamento()
        {
            if (String.IsNullOrWhiteSpace(cboTratamento.Text))
            {
                rtxtDadosAnimal.Text = "";
                rtxtDadosDono.Text = "";
                rtxtDadosTratamento.Text = "";
                rtxtObservacoes.Text = "";
            }
            else
            {
                //ANIMAL

                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    try
                    {
                        string sql = "SELECT CONCAT('Nome: ', A.nome_animal) [Nome], CONCAT('Idade: ', A.idade, ' ', A.tipo_idade) [Idade], CONCAT('Espécie: ', A.especie) [Espécie], CONCAT('Raça: ', A.raca_animal) [Raça], CONCAT('Descrição: ', A.descricao) [Descrição] from tbTratamento T inner join tbAnimal A on A.cod_animal = T.cod_animal where T.cod_tratamento = " + Convert.ToInt16(cboTratamento.SelectedValue);
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
                        string sql = "SELECT CONCAT('Nome: ', D.nome_dono) [Nome], CONCAT('Celular: ', D.cel_dono) [Celular], CONCAT('Telefone: ', D.tel_dono) [Telefone], CONCAT('Email: ', D.email_dono) [Email] from tbTratamento T inner join tbAnimal A on A.cod_animal = T.cod_animal inner join tbDono D on D.cod_dono = A.cod_dono where T.cod_tratamento = " + Convert.ToInt16(cboTratamento.SelectedValue);
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
                        string sql = "SELECT CONCAT('Tipo: ', tipo_tratamento) [Tipo], CONCAT('Data: ', data_tratamento) [Data], CONCAT('Custo: ', custo_tratamento) [Custo] from tbTratamento where cod_tratamento = " + Convert.ToInt16(cboTratamento.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtDadosTratamento.Text = reader["Tipo"].ToString() + "\n" + reader["Data"].ToString() + "\n" + reader["Custo"].ToString();
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
                        string sql = "SELECT observacao_tratamento [Tratamento] from tbTratamento where cod_tratamento = " + Convert.ToInt16(cboTratamento.SelectedValue);
                        con.Open();
                        SqlCommand scmd = new SqlCommand(sql, con);
                        SqlDataReader reader = scmd.ExecuteReader();

                        if (reader.Read())
                        {
                            rtxtObservacoes.Text = reader["Tratamento"].ToString();
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
            SqlCommand cmd = new SqlCommand("SELECT D.cod_dono as [Codigo], CONCAT(D.nome_dono, ', CPF: ', D.cpf_dono) as [Dono] from tbDono D inner join tbAnimal A on A.cod_dono = D.cod_dono inner join tbTratamento T on T.cod_animal = A.cod_animal where T.cod_animal = A.cod_animal and T.status_tratamento = 0", con);
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
                    SqlCommand cmd = new SqlCommand("SELECT T.cod_tratamento as [CodTratamento],  CONCAT(T.data_tratamento, ' ', A.nome_animal) as [Data] from tbTratamento T inner join tbAnimal A on A.cod_animal = T.cod_animal inner join tbMedico M on M.cod_medico = T.cod_medico inner join tbUsuario U on U.cod_medico = M.cod_medico where status_tratamento = 0 and U.ativacao_usuario = 1 and T.data_tratamento >= DateAdd(dd, -3, GetDate())", con);
                    SqlDataReader reader;
                    con.Open();
                    try
                    {
                        reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CodTratamento", typeof(int));
                        dt.Columns.Add("Data", typeof(string));
                        dt.Load(reader);

                        cboTratamento.ValueMember = "CodTratamento";
                        cboTratamento.DisplayMember = "Data";
                        cboTratamento.DataSource = dt;
                        cboTratamento.SelectedIndex = -1;
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
                    SqlCommand cmd = new SqlCommand("SELECT T.cod_tratamento as [CodTratamento],  CONCAT(T.data_tratamento, ' ', A.nome_animal) as [Data] from tbTratamento T inner join tbAnimal A on A.cod_animal = T.cod_animal inner join tbDono D on D.cod_dono = A.cod_dono inner join tbMedico M on M.cod_medico = T.cod_medico inner join tbUsuario U on U.cod_medico = M.cod_medico where status_tratamento = 0 and U.ativacao_usuario = 1 and T.data_tratamento >= DateAdd(dd, -3, GetDate()) and D.cod_dono = " + Convert.ToInt16(cboDono.SelectedValue), con);
                    SqlDataReader reader;
                    con.Open();
                    try
                    {
                        reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CodTratamento", typeof(int));
                        dt.Columns.Add("Data", typeof(string));
                        dt.Load(reader);

                        cboTratamento.ValueMember = "CodTratamento";
                        cboTratamento.DisplayMember = "Data";
                        cboTratamento.DataSource = dt;
                        cboTratamento.SelectedIndex = -1;
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
                Tratamento tratamento = new Tratamento(Convert.ToInt16(cboTratamento.SelectedValue), rtxtObservacoes.Text);
                tratamento.Update();
            }
        }

        private void cboTratamento_SelectedValueChanged(object sender, EventArgs e)
        {
            DadosTratamento();
        }

        private void cboDono_TextChanged(object sender, EventArgs e)
        {
            CarregaCbos();
        }

        private void Limpeza()
        {
            CarregaCbos();
            CarregaDonos();
            DadosTratamento();
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
