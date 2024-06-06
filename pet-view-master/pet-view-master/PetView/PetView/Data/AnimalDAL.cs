using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PetView.Models;

namespace PetView.DAL
{
    public class AnimalDAL
    {
        private readonly string _connectionString;

        public AnimalDAL()
        {
            _connectionString = StringConexao.connectionString;
        }

        public static void Insert(Animal animal)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_insert_animal", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@rga", SqlDbType.Int).Value = (object)animal.RGA ?? DBNull.Value;
            cmd.Parameters.Add("@cod_dono", SqlDbType.Int).Value = animal.dono.CodigoDono;
            cmd.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = animal.NomeAnimal;
            cmd.Parameters.Add("@idade", SqlDbType.Int).Value = animal.IdadeAnimal;
            cmd.Parameters.Add("@tipo_idade", SqlDbType.VarChar).Value = animal.Tempo;
            cmd.Parameters.Add("@raca_animal", SqlDbType.VarChar).Value = animal.Raca;
            cmd.Parameters.Add("@especie", SqlDbType.VarChar).Value = animal.Especie;
            cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = animal.Descricao;

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

        }

        public static DataTable Select(string type, string value)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlDataAdapter cmd = new SqlDataAdapter("sp_select_animal", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

            switch (type)
            {
                case "RGA":
                    cmd.SelectCommand.Parameters.Add("@rga", SqlDbType.Int).Value = Convert.ToInt32(value);
                    break;
                case "Nome do dono":
                    cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                    break;
                case "Código":
                    cmd.SelectCommand.Parameters.Add("@cod_animal", SqlDbType.Int).Value = Convert.ToInt32(value);
                    break;
                case "Nome do animal":
                    cmd.SelectCommand.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = value;
                    break;
                case "Idade":
                    cmd.SelectCommand.Parameters.Add("@idade", SqlDbType.Int).Value = Convert.ToInt32(value);
                    break;
                case "Raça":
                    cmd.SelectCommand.Parameters.Add("@raca_animal", SqlDbType.VarChar).Value = value;
                    break;
                case "Espécie":
                    cmd.SelectCommand.Parameters.Add("@especie", SqlDbType.VarChar).Value = value;
                    break;
                case "Descrição":
                    cmd.SelectCommand.Parameters.Add("@descricao", SqlDbType.VarChar).Value = value;
                    break;
            }

            DataTable dtbl = new DataTable();
            cmd.Fill(dtbl);
            return dtbl;

        }

        public static void Update(Animal animal)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_update_animal", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = animal.CodigoAnimal;
            cmd.Parameters.Add("@rga", SqlDbType.Int).Value = (object)animal.RGA ?? DBNull.Value;
            cmd.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = animal.NomeAnimal;
            cmd.Parameters.Add("@idade", SqlDbType.Int).Value = animal.IdadeAnimal;
            cmd.Parameters.Add("@tipo_idade", SqlDbType.VarChar).Value = animal.Tempo;
            cmd.Parameters.Add("@raca_animal", SqlDbType.VarChar).Value = animal.Raca;
            cmd.Parameters.Add("@especie", SqlDbType.VarChar).Value = animal.Especie;
            cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = animal.Descricao;

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

        }

        public void Delete(int codigoAnimal)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_animal", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = codigoAnimal;

                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Animal deletado com sucesso!", "Exclusão finalizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Erro: " + e.ToString());
                }
            }
        }
        public static DataTable Get(int id)
        {
            int cod_animal = id;

            DataTable dataTable = new DataTable();
            string sql = "Select * from tbAnimal where cod_animal= @id";

            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log the error)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return dataTable;


        }
    }
    
}