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
    public class Medico : ICadastro
    {
        public int CodigoMedico { get; set; }
        public String NomeMedico { get; set; }
        public String CRMVMedico { get; set; }
        public String CPFMedico { get; set; }
        public String RGMedico { get; set; }
        public String CelMedico { get; set; }
        public String TelMedico { get; set; }
        public String EmailMedico { get; set; }
        public String FuncaoMedico { get; set; }
        public double SalarioMedico { get; set; }
        public Endereco endereco { get; set; }

        public Medico() { }

        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_medico", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_medico", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("CRMV".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@crmv", SqlDbType.VarChar).Value = value;
                }
                else if ("Nome".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_med", SqlDbType.VarChar).Value = value;
                }
                else if ("Função".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@funcao_med", SqlDbType.VarChar).Value = value;
                }
                else if ("CPF".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cpf_med", SqlDbType.VarChar).Value = value;
                }
                else if ("RG".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@rg_med", SqlDbType.VarChar).Value = value;
                }
                else if ("Celular".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cel_med", SqlDbType.VarChar).Value = value;
                }
                else if ("Telefone".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@tel_med", SqlDbType.VarChar).Value = value;
                }
                else if ("Email".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@email_med", SqlDbType.VarChar).Value = value;
                }
                else if ("Status".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@status_med", SqlDbType.VarChar).Value = value;
                }
                else if ("Salário".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@salario_med", SqlDbType.Money).Value = Convert.ToDouble(value);
                }
                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public Medico(string nomeMedico, string cRMVMedico, string cPFMedico, string rGMedico, string celMedico, string telMedico, string emailMedico, string funcaoMedico, double salarioMedico, string cep, string bairro, string cidade, string complemento, int numcasa, string rua, string uf)
        {
            endereco = new Endereco();
            NomeMedico = nomeMedico;
            CRMVMedico = cRMVMedico;
            CPFMedico = cPFMedico;
            RGMedico = rGMedico;
            CelMedico = celMedico;
            TelMedico = telMedico;
            EmailMedico = emailMedico;
            FuncaoMedico = funcaoMedico;
            SalarioMedico = salarioMedico;
            endereco.CEP = cep;
            endereco.Bairro = bairro;
            endereco.Cidade = cidade;
            endereco.Complemento = complemento;
            endereco.NumCasa = numcasa;
            endereco.Rua = rua;
            endereco.UF = uf;
        }

        public void Insert()
        {
            SqlConnection con = new SqlConnection(StringConexao.connectionString);

            SqlCommand cmd = new SqlCommand("sp_insert_medico", con);
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
            cmd.Parameters.Add("@crmv", SqlDbType.Int).Value = CRMVMedico;
            cmd.Parameters.Add("@nome_med", SqlDbType.VarChar).Value = NomeMedico;
            cmd.Parameters.Add("@funcao_med", SqlDbType.VarChar).Value = FuncaoMedico;
            cmd.Parameters.Add("@cpf_med", SqlDbType.Char).Value = CPFMedico;
            cmd.Parameters.Add("@rg_med", SqlDbType.Char).Value = RGMedico;
            cmd.Parameters.Add("@cel_med", SqlDbType.Char).Value = CelMedico;
            if (string.IsNullOrWhiteSpace(TelMedico))
                cmd.Parameters.Add("@tel_med", SqlDbType.Char).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@tel_med", SqlDbType.Char).Value = TelMedico;
            cmd.Parameters.Add("@email_med", SqlDbType.VarChar).Value = EmailMedico;
            cmd.Parameters.Add("@salario_med", SqlDbType.Money).Value = SalarioMedico;

            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Médico registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
