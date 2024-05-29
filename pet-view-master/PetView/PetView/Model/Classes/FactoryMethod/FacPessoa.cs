using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView.Model.Classes.FactoryMethod
{
    public abstract class FacPessoa
    { 
        
        public abstract String Nome { get; set; }
        public abstract String CPF { get; set; }
        public abstract String RG { get; set; }
        public abstract String Cel { get; set; }
        public abstract String Email { get; set; }
    }
    public interface IPessoaFactory
    {
        FacPessoa CriarPessoa(string nome, string cpf, string rg, string cel,
                              string tel, string email, string cep, string bairro,
                              string cidade, string complemento, int numcasa, string rua, string uf);
    }

    // Fábrica para criação de Donos
    public class DonoFactory : IPessoaFactory
    {
        // Método para criar um Dono
        public FacPessoa CriarPessoa(string nome, string cpf, string rg, string cel,
                                      string tel, string email, string cep, string bairro,
                                      string cidade, string complemento, int numcasa, string rua, string uf)
        {
            return new Dono(nome, cpf, rg, cel, tel, email, cep, bairro, cidade,
                            complemento, numcasa, rua, uf);
        }
    }
}
