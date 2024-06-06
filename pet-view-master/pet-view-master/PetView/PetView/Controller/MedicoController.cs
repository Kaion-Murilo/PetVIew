using PetView.Data;
using System.Data;

namespace PetView.Controllers
{
    public class MedicoController
    {
        // Método para selecionar médicos com base em um tipo e valor de pesquisa
        public static DataTable Select(string type, string value)
        {
            return MedicoData.Select(type, value);
        }

        // Método para inserir um novo médico
        public static void Insert(Medico medico)
        {
            MedicoData.Insert(medico);
        }

        // Método para obter os dados de um médico pelo ID
        public static DataTable Get(int id)
        {
            DataTable dataTable = new DataTable();
            dataTable = MedicoData.get(id);
            return dataTable;
        }

        // Método para excluir um médico pelo ID
        public static void Delete(int id)
        {
            MedicoData.Delete(id);
        }

        // Método para atualizar os dados de um médico
        public static void UpdateMedico(
            int codMedico, string nomeMedico, string emailMedico, string rgMedico, string cpfMedico,
            int crmv, string funcaoMedico, string celularMedico, string telefoneMedico,
            string enderecoMedico,
            string bairroMedico, string cidadeMedico,
            string ufMedico, string cepMedico, int numcasaMedico,
            double salario, string complementoMedico)
        {
            // Atualiza o endereço do médico
            EnderecoDAL.Update(cep: cepMedico, numero: numcasaMedico, enderecoMedico, bairroMedico,
                complemento: complementoMedico, cidade: cidadeMedico, uf: ufMedico);

            // Atualiza os dados do médico
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
