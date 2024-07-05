// Bibliotecas necessárias para acesso a dados e definição de modelos
using System;
using System.Data;
using System.Data.SqlClient;
using PetView.Models; // Importa o namespace que contém o modelo Tratamento

namespace PetView.DAL
{
    // Classe responsável pelas operações de acesso aos dados para tratamento
    public class TratamentoDAL
    {
        private readonly string _connectionString; // String de conexão privada

        // Construtor da classe que inicializa a string de conexão
        public TratamentoDAL()
        {
            _connectionString = StringConexao.connectionString;
        }

        // Método estático para inserir um tratamento no banco de dados
        public static void Insert(Tratamento tratamento)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_insert_tratamento", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Adiciona os parâmetros necessários para a stored procedure de inserção
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

        // Método estático para selecionar tratamentos com base em um critério específico
        public static DataTable Select(string type, string value)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlDataAdapter cmd = new SqlDataAdapter("sp_select_tratamento", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

            // Define os parâmetros da stored procedure de seleção com base no tipo de filtro
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

        // Método estático para atualizar informações de um tratamento existente
        public static void Update(Tratamento tratamento)
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_update_tratamento", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Define os parâmetros da stored procedure de atualização
            cmd.Parameters.Add("@cod_tratamento", SqlDbType.Int).Value = tratamento.CodTratamento;
            if (string.IsNullOrWhiteSpace(tratamento.Observacao))
                cmd.Parameters.Add("@observacao", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@observacao", SqlDbType.VarChar).Value = tratamento.Observacao;

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // Método para excluir um tratamento com base no código do tratamento
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
