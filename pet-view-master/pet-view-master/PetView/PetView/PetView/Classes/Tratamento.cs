using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView
{
    public class Tratamento : ICadastro
    {

        //FUNCIONÁRIO

        public Tratamento(string observacao, double custo, string tipoTratamento, string dataTratamento, int codMedico, int codAnimal, int codConsulta)
        {
            medico = new Medico();
            animal = new Animal();
            consulta = new Consulta();
            this.Observacao = observacao;
            this.Custo = custo;
            this.TipoTratamento = tipoTratamento;
            this.DataTratamento = dataTratamento;
            medico.CodigoMedico = codMedico;
            animal.CodigoAnimal = codAnimal;
            consulta.CodConsulta = codConsulta;
        }

        //MÉDICO

        public Tratamento(int codTratamento, string observacoes)
        {
            this.CodTratamento = codTratamento;
            this.Observacao = observacoes;
        }

        public int CodTratamento { get; set; }
        public Medico medico { get; set; }
        public Animal animal { get; set; }
        public Consulta consulta { get; set; }
        public String Observacao { get; set; }
        public double Custo { get; set; }
        public String TipoTratamento { get; set; }
        public String DataTratamento { get; set; }

        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_tratamento", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_tratamento", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("Nome do animal".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = value;
                }
                else if ("Nome do médico".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_medico", SqlDbType.VarChar).Value = value;
                }
                else if ("Nome do dono".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Custo".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@custo_tratamento", SqlDbType.Money).Value = Convert.ToDouble(value);
                }
                else if ("Tipo".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@tipo_tratamento", SqlDbType.VarChar).Value = value;
                }
                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_insert_tratamento", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = animal.CodigoAnimal;
            cmd.Parameters.Add("@cod_medico", SqlDbType.Int).Value = medico.CodigoMedico;
            cmd.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = consulta.CodConsulta;
            cmd.Parameters.Add("@tipo_tratamento", SqlDbType.VarChar).Value = TipoTratamento;
            if (string.IsNullOrWhiteSpace(Observacao))
                cmd.Parameters.Add("@observacao_tratamento", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao_tratamento", SqlDbType.VarChar).Value = Observacao;
            cmd.Parameters.Add("@custo_tratamento", SqlDbType.Money).Value = Custo;
            cmd.Parameters.Add("@data_tratamento", SqlDbType.DateTime).Value = DataTratamento;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Tratamento registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Erro: " + e.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public void Update()
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_update_tratamento", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_tratamento", SqlDbType.Int).Value = CodTratamento;
            if (string.IsNullOrWhiteSpace(Observacao))
                cmd.Parameters.Add("@observacao", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao", SqlDbType.VarChar).Value = Observacao;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Tratamento registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Erro: " + e.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}
