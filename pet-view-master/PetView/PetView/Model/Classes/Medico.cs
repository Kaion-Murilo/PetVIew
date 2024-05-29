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

    public class Medico 
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

        public interface IMedicoFactory
        {
            Medico CreateMedico(string nomeMedico, string cRMVMedico, string cPFMedico, string rGMedico, string celMedico, string telMedico, string emailMedico, string funcaoMedico, double salarioMedico, string cep, string bairro, string cidade, string complemento, int numcasa, string rua, string uf);
        }
        public class MedicoFactory : IMedicoFactory
        {
         public Medico CreateMedico(string nomeMedico, 
             string cRMVMedico, string cPFMedico, 
             string rGMedico, string celMedico, 
             string telMedico, string emailMedico, string funcaoMedico, 
             double salarioMedico, string cep, string bairro,
             string cidade, string complemento, int numcasa,
             string rua, string uf)


            {
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
        //IMedicoFactory medicoFactory = new MedicoFactory();

        ///////Medico medico = medicoFactory.CreateMedico(
        //"Dr. João",
        //"123456",
        //"123.456.789-00",
        //"MG-12.345.678",
        //"99999-9999",
        //"3333-3333",
        //"dr.joao@example.com",
        //"Veterinário",
        //12000.00,
        //"12345-678",
        //"Centro",
        //"Belo Horizonte",
        //"Apto 101",
        //123,
        //"Rua das Flores",
        //"MG"
        //);

        // Console.WriteLine($"Nome: {medico.NomeMedico}, CRMV: {medico.CRMVMedico}, Endereço: {medico.Endereco.Rua}, {medico.Endereco.NumCasa}");
    //}


}
}
