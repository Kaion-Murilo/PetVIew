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
    public class Funcionario : ICadastro
    {
        public int CodigoFunc { get; set; }
        public String NomeFunc { get; set; }
        public String CPFFunc { get; set; }
        public String RGFunc { get; set; }
        public String CelFunc { get; set; }
        public String TelFunc { get; set; }
        public String EmailFunc { get; set; }
        public String CargoFunc { get; set; }
        public double SalarioFunc { get; set; }
        public Endereco endereco { get; set; }

        public Funcionario(string nomeFunc, string cPFFunc, string rGFunc, string celFunc, string telFunc, string emailFunc, string cargoFunc, double salarioFunc, string cep, string bairro, string cidade, string complemento, int numcasa, string rua, string uf)
        {
            endereco = new Endereco();
            NomeFunc = nomeFunc;
            CPFFunc = cPFFunc;
            RGFunc = rGFunc;
            CelFunc = celFunc;
            TelFunc = telFunc;
            EmailFunc = emailFunc;
            CargoFunc = cargoFunc;
            SalarioFunc = salarioFunc;
            endereco.CEP = cep;
            endereco.Bairro = bairro;
            endereco.Cidade = cidade;
            endereco.Complemento = complemento;
            endereco.NumCasa = numcasa;
            endereco.Rua = rua;
            endereco.UF = uf;
        }

        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_func", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_funcionario", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("Nome".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_func", SqlDbType.VarChar).Value = value;
                }
                else if ("CPF".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cpf_func", SqlDbType.VarChar).Value = value;
                }
                else if ("RG".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@rg_func", SqlDbType.VarChar).Value = value;
                }
                else if ("Status".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@status_func", SqlDbType.VarChar).Value = value;
                }
                else if ("Telefone".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@tel_func", SqlDbType.VarChar).Value = value;
                }
                else if ("Celular".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cel_func", SqlDbType.VarChar).Value = value;
                }
                else if ("Email".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@email_func", SqlDbType.VarChar).Value = value;
                }
                else if ("Cargo".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cargo_func", SqlDbType.VarChar).Value = value;
                }
                else if ("Salário".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@salario_func", SqlDbType.Money).Value = Convert.ToDouble(value);
                }
                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public void Insert()
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_insert_func", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@cep", SqlDbType.Char).Value = endereco.CEP;
            cmd.Parameters.Add("@numero", SqlDbType.Int).Value = endereco.NumCasa;
            cmd.Parameters.Add("@rua", SqlDbType.VarChar).Value = endereco.Rua;
            cmd.Parameters.Add("@bairro", SqlDbType.VarChar).Value = endereco.Bairro;
            if (string.IsNullOrWhiteSpace(endereco.Complemento))
                cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = endereco.Complemento;
            cmd.Parameters.Add("@cidade", SqlDbType.VarChar).Value = endereco.Cidade;
            cmd.Parameters.Add("@uf", SqlDbType.Char).Value = endereco.UF;
            cmd.Parameters.Add("@nome_func", SqlDbType.VarChar).Value = NomeFunc;
            cmd.Parameters.Add("@cargo_func", SqlDbType.VarChar).Value = CargoFunc;
            cmd.Parameters.Add("@cpf_func", SqlDbType.Char).Value = CPFFunc;
            cmd.Parameters.Add("@rg_func", SqlDbType.Char).Value = RGFunc;
            if (string.IsNullOrWhiteSpace(TelFunc))
                cmd.Parameters.Add("@tel_func", SqlDbType.Char).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@tel_func", SqlDbType.Char).Value = TelFunc;
            cmd.Parameters.Add("@cel_func", SqlDbType.Char).Value = CelFunc;
            if (string.IsNullOrWhiteSpace(EmailFunc))
                cmd.Parameters.Add("@email_func", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@email_func", SqlDbType.VarChar).Value = EmailFunc;
            cmd.Parameters.Add("@salario_func", SqlDbType.Money).Value = SalarioFunc;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Funcionário registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void Update() { }
        public void Delete() { }
    }
}
