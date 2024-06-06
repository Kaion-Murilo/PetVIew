namespace PetView.Models
{
    // Classe que representa um funcionário
    public class Funcionario
    {
        // Código do funcionário
        public int CodigoFunc { get; set; }
        // Nome do funcionário
        public string NomeFunc { get; set; }
        // CPF do funcionário
        public string CPFFunc { get; set; }
        // RG do funcionário
        public string RGFunc { get; set; }
        // Número de celular do funcionário
        public string CelFunc { get; set; }
        // Número de telefone do funcionário
        public string TelFunc { get; set; }
        // Email do funcionário
        public string EmailFunc { get; set; }
        // Cargo do funcionário
        public string CargoFunc { get; set; }
        // Salário do funcionário
        public double SalarioFunc { get; set; }
        // Endereço do funcionário
        public Endereco endereco { get; set; }

        // Construtor para criar um novo funcionário com detalhes completos
        public Funcionario(string nomeFunc, string cPFFunc, string rGFunc, string celFunc, string telFunc, string emailFunc, string cargoFunc, double salarioFunc, string cep, string bairro, string cidade, string complemento, int numcasa, string rua, string uf)
        {
            // Inicializa o endereço do funcionário
            endereco = new Endereco();
            // Define o nome do funcionário
            NomeFunc = nomeFunc;
            // Define o CPF do funcionário
            CPFFunc = cPFFunc;
            // Define o RG do funcionário
            RGFunc = rGFunc;
            // Define o número de celular do funcionário
            CelFunc = celFunc;
            // Define o número de telefone do funcionário
            TelFunc = telFunc;
            // Define o email do funcionário
            EmailFunc = emailFunc;
            // Define o cargo do funcionário
            CargoFunc = cargoFunc;
            // Define o salário do funcionário
            SalarioFunc = salarioFunc;
            // Define os detalhes do endereço do funcionário
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
