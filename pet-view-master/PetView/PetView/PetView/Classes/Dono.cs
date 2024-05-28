using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView
{
    public class Dono : ICadastro
    {
        public int CodigoDono { get; set; }
        public String NomeDono { get; set; }
        public String CPFDono { get; set; }
        public String RGDono { get; set; }
        public String CelDono { get; set; }
        public String TelDono { get; set; }
        public String EmailDono { get; set; }
        public Endereco Endereco { get; set; }

        public Dono() { }

        public Dono(string nomeDono, string cPFDono, string rGDono, string celDono, string telDono, string emailDono, string cep, string bairro, string cidade, string complemento, int numcasa, string rua, string uf)
        {

            NomeDono = nomeDono;
            CPFDono = cPFDono;
            RGDono = rGDono;
            CelDono = celDono;
            TelDono = telDono;
            EmailDono = emailDono;
            Endereco = new Endereco.EnderecoBuilder()
            .ComCEP(cep)
            .ComNumCasa(numcasa)
            .NaRua(rua)
            .NoBairro(bairro)
            .ComComplemento(complemento)
            .NaCidade(cidade)
            .NoUF(uf)
            .Construir();

        }

        public void Insert()
        {
            Console.WriteLine($"Inicio de Inserte");
            SqlConnection con = new SqlConnection(StringConexao.connectionString);
            SqlCommand cmd = new SqlCommand("sp_insert_dono", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cep", SqlDbType.Char).Value = Endereco.CEP;

            cmd.Parameters.Add("@numero", SqlDbType.Int).Value = Endereco.NumCasa;
            Console.WriteLine($"Número: {Endereco.NumCasa}");
            cmd.Parameters.Add("@rua", SqlDbType.VarChar).Value = Endereco.Rua;
            Console.WriteLine($"Rua: {Endereco.Rua}");
            cmd.Parameters.Add("@bairro", SqlDbType.VarChar).Value = Endereco.Bairro;
            Console.WriteLine($"Bairro: {Endereco.Bairro}");
            if (string.IsNullOrWhiteSpace(Endereco.Complemento))
                cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@complemento", SqlDbType.VarChar).Value = Endereco.Complemento;
            cmd.Parameters.Add("@cidade", SqlDbType.VarChar).Value = Endereco.Cidade;
            cmd.Parameters.Add("@uf", SqlDbType.Char).Value = Endereco.UF;
            cmd.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = NomeDono;
            cmd.Parameters.Add("@cpf_dono", SqlDbType.Char).Value = CPFDono;
            cmd.Parameters.Add("@rg_dono", SqlDbType.Char).Value = RGDono;
            if (string.IsNullOrWhiteSpace(TelDono))
                cmd.Parameters.Add("@tel_dono", SqlDbType.Char).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@tel_dono", SqlDbType.Char).Value = TelDono;
            cmd.Parameters.Add("@cel_dono", SqlDbType.Char).Value = CelDono;
            if (string.IsNullOrWhiteSpace(EmailDono))
                cmd.Parameters.Add("@email_dono", SqlDbType.VarChar).Value = SqlString.Null;
            else
                cmd.Parameters.Add("@email_dono", SqlDbType.VarChar).Value = EmailDono;
            con.Open();


            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Dono registrado com sucesso!", "Cadastro finalizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static DataTable Select(String type, String value)
        {
            using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
            {
                SqlDataAdapter cmd = new SqlDataAdapter("sp_select_dono", con);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                if ("Código".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cod_dono", SqlDbType.Int).Value = Convert.ToInt32(value);
                }
                else if ("Nome".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@nome_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("CPF".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cpf_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("RG".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@rg_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Telefone".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@tel_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Celular".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@cel_dono", SqlDbType.VarChar).Value = value;
                }
                else if ("Email".Equals(type))
                {
                    cmd.SelectCommand.Parameters.Add("@email_dono", SqlDbType.VarChar).Value = value;
                }
                DataTable dtbl = new DataTable();
                cmd.Fill(dtbl);
                return dtbl;
            }
        }

        public void Update()
        {

        }
        public void Delete()
        {
            int cod_usuario = CodigoDono;
            Console.WriteLine($"Codigo dono: {CodigoDono}");

            try
            {
                using (SqlConnection con = new SqlConnection(StringConexao.connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("sp_delete_usuario", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@cod_usuario", SqlDbType.Int).Value = cod_usuario;

                        int rowsAffected = command.ExecuteNonQuery();
                        con.Close();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Usuário deletado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Nenhum usuário foi deletado. Verifique o código do usuário.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }


        }


    }
}