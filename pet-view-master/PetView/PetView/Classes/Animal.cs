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
    public class Animal
    {
        public int CodigoAnimal { get; set; }
        public int? RGA { get; set; }
        public String NomeAnimal { get; set; }
        public int IdadeAnimal { get; set; }
        public String Tempo { get; set; }
        public String Especie { get; set; }
        public String Raca { get; set; }
        public String Descricao { get; set; }
        public Dono dono { get; set; }

        public Animal() { }

        public Animal(int? rGA, String nomeAnimal, int idadeAnimal, String tempo, String especie, String raca, String descricao, int codDono)
        {
            dono = new Dono();
            this.RGA = rGA;
            this.NomeAnimal = nomeAnimal;
            this.IdadeAnimal = idadeAnimal;
            this.Tempo = tempo;
            this.Especie = especie;
            this.Raca = raca;
            this.Descricao = descricao;
            dono.CodigoDono = codDono;
        }

        public void Insert()
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_insert_animal", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@rga", SqlDbType.Int).Value = (object)RGA ?? DBNull.Value;
            cmd.Parameters.Add("@cod_dono", SqlDbType.Int).Value = dono.CodigoDono;
            cmd.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = NomeAnimal;
            cmd.Parameters.Add("@idade", SqlDbType.Int).Value = IdadeAnimal;
            cmd.Parameters.Add("@tipo_idade", SqlDbType.VarChar).Value = Tempo;
            cmd.Parameters.Add("@raca_animal", SqlDbType.VarChar).Value = Raca;
            cmd.Parameters.Add("@especie", SqlDbType.VarChar).Value = Especie;
            cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = Descricao;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Animal registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_animal", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("RGA".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@rga", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("Nome do dono".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_animal", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("Nome do animal".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = value;
                }
                else if ("Idade".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@idade", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("Raça".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@raca_animal", SqlDbType.VarChar).Value = value;
                }
                else if ("Espécie".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@especie", SqlDbType.VarChar).Value = value;
                }
                else if ("Descrição".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@descricao", SqlDbType.VarChar).Value = value;
                }
                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public void Update()
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_update_dono", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = CodigoAnimal;
            cmd.Parameters.Add("@rga", SqlDbType.Int).Value = (object)RGA ?? DBNull.Value;
            cmd.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = NomeAnimal;
            cmd.Parameters.Add("@idade", SqlDbType.Int).Value = IdadeAnimal;
            cmd.Parameters.Add("@raca_animal", SqlDbType.VarChar).Value = Raca;
            cmd.Parameters.Add("@especie", SqlDbType.VarChar).Value = Especie;
            cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = Descricao;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Registros do animal atualizados com sucesso!", "Atualização finalizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void Delete() {
        
        }
    }
}
