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
    }
}
