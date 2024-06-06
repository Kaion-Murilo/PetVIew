using PetView.Data;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace PetView.Controllers
{
    public class MedicoController
    {
        public static DataTable Select(string type, string value)
        {
            return MedicoData.Select(type, value);
        }

        public static void Insert(Medico medico)
        {
            MedicoData.Insert(medico);
        }
        public static DataTable Get(int id)
        {
            DataTable dataTable = new DataTable();
            dataTable=MedicoData.get(id);
            return dataTable;
        }
        public static void Delete(int id)
        {
            MedicoData.Delete(id);
        }
        public static void UpdateMedico(
     int codMedico, string nomeMedico, string emailMedico, string rgMedico, string cpfMedico,
     int crmv, string funcaoMedico, string celularMedico, string telefoneMedico,
     string enderecoMedico, 
     string bairroMedico, string cidadeMedico, 
     string ufMedico, string cepMedico, int numcasaMedico,
     double salario, string complementoMedico)
        {
            EnderecoDAL.Update(cep:cepMedico,numero: numcasaMedico, enderecoMedico,bairroMedico,
                complemento:complementoMedico,cidade: cidadeMedico, uf:ufMedico);
            MedicoData.UpdateMedico(codMedico: codMedico,
                nomeMedico: nomeMedico,
                emailMedico: emailMedico,
                rgMedico: rgMedico,
                cpfMedico: cpfMedico,
                crmv: crmv,
                funcaoMedico: funcaoMedico,
                celularMedico: celularMedico,
                telefoneMedico: telefoneMedico,
                enderecoMedico: enderecoMedico,
                bairroMedico: bairroMedico,
                cidadeMedico: cidadeMedico,
                ufMedico: ufMedico,
                cepMedico: cepMedico,
                numcasaMedico: numcasaMedico,
                salarioMedico: salario,
                complementoMedicos: complementoMedico

            );
        }
    }
}
