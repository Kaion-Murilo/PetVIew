namespace PetView.Models
{
    public class Funcionario
    {
        public int CodigoFunc { get; set; }
        public string NomeFunc { get; set; }
        public string CPFFunc { get; set; }
        public string RGFunc { get; set; }
        public string CelFunc { get; set; }
        public string TelFunc { get; set; }
        public string EmailFunc { get; set; }
        public string CargoFunc { get; set; }
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
    }
}
