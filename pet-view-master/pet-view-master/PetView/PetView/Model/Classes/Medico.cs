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
    // Classe que representa um médico
    public class Medico
    {
        // Código do médico
        public int CodigoMedico { get; set; }
        // Nome do médico
        public String NomeMedico { get; set; }
        // CRMV do médico
        public String CRMVMedico { get; set; }
        // CPF do médico
        public String CPFMedico { get; set; }
        // RG do médico
        public String RGMedico { get; set; }
        // Número de celular do médico
        public String CelMedico { get; set; }
        // Número de telefone do médico
        public String TelMedico { get; set; }
        // Email do médico
        public String EmailMedico { get; set; }
        // Função do médico
        public String FuncaoMedico { get; set; }
        // Salário do médico
        public double SalarioMedico { get; set; }
        // Endereço do médico
        public Endereco endereco { get; set; }

        // Construtor padrão
        public Medico() { }

        // Interface para a fábrica de médicos
        public interface IMedicoFactory
        {
            // Método para criar um médico
            Medico CreateMedico(string nomeMedico, string cRMVMedico, string cPFMedico, string rGMedico, string celMedico, string telMedico, string emailMedico, string funcaoMedico, double salarioMedico, string cep, string bairro, string cidade, string complemento, int numcasa, string rua, string uf);
        }

        // Classe que implementa a interface de fábrica de médicos
        public class MedicoFactory : IMedicoFactory
        {
            // Método para criar um médico
            public Medico CreateMedico(string nomeMedico,
                string cRMVMedico, string cPFMedico,
                string rGMedico, string celMedico,
                string telMedico, string emailMedico, string funcaoMedico,
                double salarioMedico, string cep, string bairro,
                string cidade, string complemento, int numcasa,
                string rua, string uf)
            {
                // Retorna um novo médico com os dados fornecidos
                return new Medico
                {
                    NomeMedico = nomeMedico,
                    CRMVMedico = cRMVMedico,
                    CPFMedico = cPFMedico,
                    RGMedico = rGMedico,
                    CelMedico = celMedico,
                    TelMedico = telMedico,
                    EmailMedico = emailMedico,
                    FuncaoMedico = funcaoMedico,
                    SalarioMedico = salarioMedico,
                    endereco = new Endereco.EnderecoBuilder()
                        .ComCEP(cep)
                        .ComNumCasa(numcasa)
                        .NaRua(rua)
                        .NoBairro(bairro)
                        .ComComplemento(complemento)
                        .NaCidade(cidade)
                        .NoUF(uf)
                        .Construir()
                };
            }
        }

        // Construtor para criar um novo médico com detalhes completos
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
    }
}
