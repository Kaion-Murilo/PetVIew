using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define o namespace do projeto
namespace PetView.Model.Classes.FactoryMethod
{
    // Classe abstrata FacPessoa que define a estrutura básica de uma pessoa
    public abstract class FacPessoa
    {
        // Propriedades abstratas que serão implementadas nas classes derivadas
        public abstract String Nome { get; set; }
        public abstract String CPF { get; set; }
        public abstract String RG { get; set; }
        public abstract String Cel { get; set; }
        public abstract String Email { get; set; }
    }

    // Interface IPessoaFactory que define o método para criar uma pessoa
    public interface IPessoaFactory
    {
        // Método abstrato para criar uma pessoa
        FacPessoa CriarPessoa(string nome, string cpf, string rg, string cel,
                              string tel, string email, string cep, string bairro,
                              string cidade, string complemento, int numcasa, string rua, string uf);
    }

    // Classe DonoFactory que implementa a interface IPessoaFactory
    public class DonoFactory : IPessoaFactory
    {
        // Método para criar um Dono
        public FacPessoa CriarPessoa(string nome, string cpf, string rg, string cel,
                                      string tel, string email, string cep, string bairro,
                                      string cidade, string complemento, int numcasa, string rua, string uf)
        {
            // Retorna uma nova instância da classe Dono
            return new Dono(nome, cpf, rg, cel, tel, email, cep, bairro, cidade,
                            complemento, numcasa, rua, uf);
        }
    }
}
