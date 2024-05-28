using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView
{
    public class StringConexao
    {
        private static String _connectionString = @"Data Source=NOTE1;Initial Catalog=dbPetView;User ID=sa;Password=123456789;Encrypt=False";
        public static string connectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
    }
}
