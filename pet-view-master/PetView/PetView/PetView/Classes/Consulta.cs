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
    /// <summary>
    /// DTO (Inicio)
    /// </summary>
    public class Consulta : ICadastro
    {
        public int CodConsulta { get; set; }
        public Medico medico { get; set; }
        public Animal animal { get; set; }
        public String Sintomas { get; set; }
        public String Diagnostico { get; set; }
        public String Observacao { get; set; }
        public double Custo { get; set; }
        public String TipoConsulta { get; set; }
        public String DataConsulta { get; set; }
        /// <summary>
        /// DTO (Fim)
        /// </summary>

        public Consulta() { }

        //FUNCIONÁRIO

        public Consulta(string observacao, double custo, string tipoConsulta, string dataConsulta, int codMedico, int codAnimal)
        {
            medico = new Medico();
            animal = new Animal();
            this.Observacao = observacao;
            this.Custo = custo;
            this.TipoConsulta = tipoConsulta;
            this.DataConsulta = dataConsulta;
            medico.CodigoMedico = codMedico;
            animal.CodigoAnimal = codAnimal;
        }

        //MÉDICO

        public Consulta(int codConsulta, string sintomas, string diagnostico, string observacao)
        {
            this.CodConsulta = codConsulta;
            this.Sintomas = sintomas;
            this.Diagnostico = diagnostico;
            this.Observacao = observacao;
        }
        
        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_consulta", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = Convert.ToInt32(value);
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
                    cmd.SelectCommand.Parameters.Add("@custo_consulta", SqlDbType.Money).Value = Convert.ToDouble(value);
                }
                else if ("Tipo".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@tipo_consulta", SqlDbType.VarChar).Value = value;
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

            SqlCommand cmd = new SqlCommand("sp_insert_consulta", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = animal.CodigoAnimal;
            cmd.Parameters.Add("@cod_medico", SqlDbType.Int).Value = medico.CodigoMedico;
            cmd.Parameters.Add("@custo_consulta", SqlDbType.Money).Value = Custo;
            if (string.IsNullOrWhiteSpace(Observacao))
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = Observacao;
            cmd.Parameters.Add("@tipo_consulta", SqlDbType.VarChar).Value = TipoConsulta;
            cmd.Parameters.Add("@data_consulta", SqlDbType.DateTime).Value = DataConsulta;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Consulta registrada com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            SqlCommand cmd = new SqlCommand("sp_update_consulta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = CodConsulta;
            if (string.IsNullOrWhiteSpace(Observacao))
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@observacao_consulta", SqlDbType.VarChar).Value = Observacao;
            cmd.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = Sintomas;
            cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = Diagnostico;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Consulta registrada com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
