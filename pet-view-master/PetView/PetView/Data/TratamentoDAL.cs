using System;
using System.Data;
using System.Data.SqlClient;
using PetView.Models;

namespace PetView.DAL
{
    public class TratamentoDAL
    {
        private readonly string _connectionString;

        public TratamentoDAL()
        {
            _connectionString = StringConexao.connectionString;
        }

        public static void Insert(Tratamento tratamento)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_insert_tratamento", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_animal", SqlDbType.Int).Value = tratamento.animal.CodigoAnimal;
                cmd.Parameters.Add("@cod_medico", SqlDbType.Int).Value = tratamento.medico.CodigoMedico;
                cmd.Parameters.Add("@cod_consulta", SqlDbType.Int).Value = tratamento.CodTratamento;
                cmd.Parameters.Add("@tipo_tratamento", SqlDbType.VarChar).Value = tratamento.TipoTratamento;
                if (string.IsNullOrWhiteSpace(tratamento.Observacao))
                    cmd.Parameters.Add("@observacao_tratamento", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@observacao_tratamento", SqlDbType.VarChar).Value = tratamento.Observacao;
                cmd.Parameters.Add("@custo_tratamento", SqlDbType.Money).Value = tratamento.Custo;
                cmd.Parameters.Add("@data_tratamento", SqlDbType.DateTime).Value = tratamento.DataTratamento;

                con.Open();
                cmd.ExecuteNonQuery();
            
        }

        public static DataTable Select(string type, string value)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
  
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_tratamento", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                    cmd.SelectCommand.Parameters.Add("@cod_tratamento", SqlDbType.Int).Value = Convert.ToInt32(value);
                else if ("Nome do animal".Equals(type))
                    cmd.SelectCommand.Parameters.Add("@nome_animal", SqlDbType.VarChar).Value = value;
                else if ("Nome do médico".Equals(type))
                    cmd.SelectCommand.Parameters.Add("@nome_medico", SqlDbType.VarChar).Value = value;
                else if ("Nome do dono".Equals(type))
                    cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                else if ("Custo".Equals(type))
                    cmd.SelectCommand.Parameters.Add("@custo_tratamento", SqlDbType.Money).Value = Convert.ToDouble(value);
                else if ("Tipo".Equals(type))
                    cmd.SelectCommand.Parameters.Add("@tipo_tratamento", SqlDbType.VarChar).Value = value;

                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            
        }

        public static void Update(Tratamento tratamento)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_update_tratamento", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_tratamento", SqlDbType.Int).Value = tratamento.CodTratamento;
                if (string.IsNullOrWhiteSpace(tratamento.Observacao))
                    cmd.Parameters.Add("@observacao", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@observacao", SqlDbType.VarChar).Value = tratamento.Observacao;

                con.Open();
                cmd.ExecuteNonQuery();
            
        }

        public void Delete(int codigoTratamento)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_tratamento", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_tratamento", SqlDbType.Int).Value = codigoTratamento;

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
