using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace PetView.Data
{
    public static class MedicoData
    {
        public static DataTable Select(string type, string value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_medico", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Adicione aqui a lógica para definir os parâmetros de acordo com o tipo
                // ...

                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public static void Insert(Medico medico)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_insert_medico", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cep", SqlDbType.Char).Value = medico.endereco.CEP;
            cmd.Parameters.Add("@numero", SqlDbType.Int).Value = medico.endereco.NumCasa;
            cmd.Parameters.Add("@rua", SqlDbType.VarChar).Value = medico.endereco.Rua;
            cmd.Parameters.Add("@bairro", SqlDbType.VarChar).Value = medico.endereco.Bairro;
            if (string.IsNullOrWhiteSpace(medico.endereco.Complemento))
                cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = medico.endereco.Complemento;
            cmd.Parameters.Add("@cidade", SqlDbType.VarChar).Value = medico.endereco.Cidade;
            cmd.Parameters.Add("@uf", SqlDbType.Char).Value = medico.endereco.UF;
            cmd.Parameters.Add("@crmv", SqlDbType.Int).Value = medico.CRMVMedico;
            cmd.Parameters.Add("@nome_med", SqlDbType.VarChar).Value = medico.NomeMedico;
            cmd.Parameters.Add("@funcao_med", SqlDbType.VarChar).Value = medico.FuncaoMedico;
            cmd.Parameters.Add("@cpf_med", SqlDbType.Char).Value = medico.CPFMedico;
            cmd.Parameters.Add("@rg_med", SqlDbType.Char).Value = medico.RGMedico;
            cmd.Parameters.Add("@cel_med", SqlDbType.Char).Value = medico.CelMedico;
            if (string.IsNullOrWhiteSpace(medico.TelMedico))
                cmd.Parameters.Add("@tel_med", SqlDbType.Char).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@tel_med", SqlDbType.Char).Value = medico.TelMedico;
            cmd.Parameters.Add("@email_med", SqlDbType.VarChar).Value = medico.EmailMedico;
            cmd.Parameters.Add("@salario_med", SqlDbType.Money).Value = medico.SalarioMedico;
            con.Open();
            cmd.ExecuteNonQuery();


            try
            {



                MessageBox.Show("Médico registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        public static DataTable get(int id)

        {
            Console.WriteLine("id="+id);
            int cod_usuario = id;

            DataTable dataTable = new DataTable();
            string sql = "Select * FROM tbMedico where cod_medico= @id";

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
            foreach (DataRow row in  dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.WriteLine($"{col.ColumnName}: {row[col]}");
                }
                Console.WriteLine(); // Adiciona uma linha em branco entre cada linha de dados
            }


            return dataTable;


        }
        public static void UpdateMedico(int codMedico, string nomeMedico, string emailMedico,
            string rgMedico, string cpfMedico, int crmv, string funcaoMedico, string celularMedico,
            string telefoneMedico, string enderecoMedico, string bairroMedico, string cidadeMedico,
            string ufMedico, string cepMedico, 
            int numcasaMedico, double salarioMedico, string complementoMedicos)
        {
            string statusMedico = "Ativo";
            string connectionString = StringConexao.connectionString;

            string sql = @"
        UPDATE tbMedico 
        SET 
            crmv = @crmv,
            nome_med = @nome_med,
            funcao_med = @funcao_med,
            cpf_med = @cpf_med,
            rg_med = @rg_med,
            cel_med = @cel_med,
            tel_med = @tel_med,
            email_med = @email_med,
            salario_med = @salario_med,
            status_med = @status_med,
            cep_med = @cep_med,
            numcasa_med = @numcasa_med
        WHERE cod_medico = @cod_medico;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@cod_medico", codMedico);
                    command.Parameters.AddWithValue("@crmv", crmv);
                    command.Parameters.AddWithValue("@nome_med", nomeMedico);
                    command.Parameters.AddWithValue("@funcao_med", funcaoMedico);
                    command.Parameters.AddWithValue("@cpf_med", cpfMedico);
                    command.Parameters.AddWithValue("@rg_med", rgMedico);
                    command.Parameters.AddWithValue("@cel_med", celularMedico);
                    command.Parameters.AddWithValue("@tel_med", telefoneMedico);
                    command.Parameters.AddWithValue("@email_med", emailMedico);
                    command.Parameters.AddWithValue("@salario_med", salarioMedico);
                    command.Parameters.AddWithValue("@status_med", statusMedico); // Adicionando o parâmetro faltante
                    command.Parameters.AddWithValue("@cep_med", cepMedico);
                    command.Parameters.AddWithValue("@numcasa_med", numcasaMedico);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Dados do médico atualizados com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log the error)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }
        public static void Delete(int id)
        {
            int cod_usuario = id;


            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(StringConexao.connectionString))
            {
                string sql = "DElETE  From tbMedico WHERE cod_medico = " + id;
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

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
        }
    


    }

}
