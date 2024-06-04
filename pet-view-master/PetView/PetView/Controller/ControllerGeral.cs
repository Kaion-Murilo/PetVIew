using PetView.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PetView.Models.ConsultaModel;

namespace PetView.Controller
{
    internal class ControllerGeral
    {

        public DataTable GetConsultasByDono(int codDono, string nomeDono)
        {
            DataTable dataTable = new DataTable();

            using (var connection = new SqlConnection(StringConexao.connectionString))
            {
                connection.Open();

                var query = @"
                    SELECT c.cod_consulta, c.sintomas, c.diagnostico, c.custo_consulta, c.tipo_consulta, 
                           c.data_consulta, c.observacao_consulta, c.status_consulta,
                           a.cod_animal, a.nome_animal,
                           m.cod_medico, m.nome_medico
                    FROM tbConsulta c
                    INNER JOIN tbAnimal a ON c.cod_animal = a.cod_animal
                    INNER JOIN tbMedico m ON c.cod_medico = m.cod_medico
                    INNER JOIN tbDono d ON a.cod_dono = d.cod_dono
                    WHERE d.cod_dono = @CodDono AND d.nome_dono = @NomeDono";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodDono", codDono);
                    command.Parameters.AddWithValue("@NomeDono", nomeDono);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
           
    }
    }
}
                 
