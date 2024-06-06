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
    public class Exame : ICadastro
    {
        //FUNCIONÁRIO

        public Exame(string observacao, double custo, string tipoExame, string dataExame, int codAnimal, int codMed, int codConsulta)
        {
            medico = new Medico();
            animal = new Animal();
            consulta = new Consulta();
            this.Observacao = observacao;
            this.Custo = custo;
            this.TipoExame = tipoExame;
            this.DataExame = dataExame;
            animal.CodigoAnimal = codAnimal;
            medico.CodigoMedico = codMed;
            consulta.CodConsulta = codConsulta;
        }

        //MÉDICO

        public Exame(int codExame, string observacao)
        {
            this.CodExame = codExame;
            this.Observacao = observacao;
        }

        public int CodExame { get; set; }
        public Medico medico { get; set; }
        public Animal animal { get; set; }
        public Consulta consulta { get; set; }
        public String Observacao { get; set; }
        public double Custo { get; set; }
        public String TipoExame { get; set; }
        public String DataExame { get; set; }

        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_exame", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_exame", SqlDbType.Int).Value = Convert.ToInt32(value);
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
                    cmd.SelectCommand.Parameters.Add("@custo_exame", SqlDbType.Money).Value = Convert.ToDouble(value);
                }
                else if ("Tipo".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@tipo_exame", SqlDbType.VarChar).Value = value;
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

            SqlCommand cmd = new SqlCommand("sp_insert_exame", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = animal.CodigoAnimal;
            cmd.Parameters.Add("@cod_medico", SqlDbType.Int).Value = medico.CodigoMedico;
            cmd.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = consulta.CodConsulta;
            cmd.Parameters.Add("@tipo_exame", SqlDbType.VarChar).Value = TipoExame;
            if (string.IsNullOrWhiteSpace(Observacao))
                cmd.Parameters.Add("@observacao_exame", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao_exame", SqlDbType.VarChar).Value = Observacao;
            cmd.Parameters.Add("@custo_exame", SqlDbType.Money).Value = Custo;
            cmd.Parameters.Add("@data_exame", SqlDbType.DateTime).Value = DataExame;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Exame registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            SqlCommand cmd = new SqlCommand("sp_update_exame", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@cod_exame", SqlDbType.Int).Value = CodExame;
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
                    MessageBox.Show("Exame registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
