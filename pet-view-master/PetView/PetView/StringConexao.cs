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
        /// <summary>
        /// Singleton (Inicio)
        /// </summary>
            // Instância singleton privada e objeto de bloqueio para thread safety
            private static StringConexao _instance;
            private static readonly object _lock = new object();
            // Construtor privado para impedir a instanciação externa
            private StringConexao() { }
            // Campo de instância para a string de conexão
            private static String _connectionString = @"Data Source=NOTE1;Initial Catalog=dbPetView;User ID=sa;Password=123456789;Encrypt=False";
            // Propriedade estática para acessar a única instância da classe
            public static StringConexao Instance
            {
                get
                {// Dupla verificação para garantir thread safety na criação da instância
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new StringConexao();
                            }
                        }
                    }
                    return _instance;
                }
            }
            // Propriedade para acessar e modificar a string de conexão
            public static string connectionString
            {
                get { return _connectionString; }
                set { _connectionString = value; }
            }
        /// Singleton (Fim)
    }
}
