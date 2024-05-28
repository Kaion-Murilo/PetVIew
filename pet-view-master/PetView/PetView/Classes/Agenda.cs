using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView
{
    public class Agenda
    {
        public static DataTable Select(String datainicial, String datafinal, int? medico)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_servicos", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (string.IsNullOrWhiteSpace(datainicial))
                    cmd.SelectCommand.Parameters.Add("@data_inicial", SqlDbType.DateTime).Value = SqlString.Null;

                else if (string.IsNullOrWhiteSpace(datafinal))
                    cmd.SelectCommand.Parameters.Add("@data_final", SqlDbType.DateTime).Value = SqlString.Null;

                else if (string.IsNullOrWhiteSpace(datainicial) && string.IsNullOrWhiteSpace(datafinal))
                {
                    cmd.SelectCommand.Parameters.Add("@data_inicial", SqlDbType.DateTime).Value = SqlString.Null;
                    cmd.SelectCommand.Parameters.Add("@data_final", SqlDbType.DateTime).Value = SqlString.Null;
                }

                else if (!string.IsNullOrWhiteSpace(datainicial) && !string.IsNullOrWhiteSpace(datafinal))
                {
                    cmd.SelectCommand.Parameters.Add("@data_inicial", SqlDbType.DateTime).Value = datainicial;
                    cmd.SelectCommand.Parameters.Add("@data_final", SqlDbType.DateTime).Value = datafinal;
                }

                else if (medico == null)
                    cmd.SelectCommand.Parameters.Add("@cod_medico", SqlDbType.Int).Value = SqlString.Null;

                else
                {
                    cmd.SelectCommand.Parameters.Add("@data_inicial", SqlDbType.DateTime).Value = datainicial;
                    cmd.SelectCommand.Parameters.Add("@data_final", SqlDbType.DateTime).Value = datafinal;
                    cmd.SelectCommand.Parameters.Add("@cod_medico", SqlDbType.Int).Value = medico;
                }

                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }
    }
}
