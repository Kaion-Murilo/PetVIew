using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView
{
    // Classe que representa um endereço
    public class Endereco
    {
        // CEP do endereço
        public string CEP { get; set; }
        // Número da casa
        public int NumCasa { get; set; }
        // Nome da rua
        public string Rua { get; set; }
        // Nome do bairro
        public string Bairro { get; set; }
        // Complemento do endereço
        public string Complemento { get; set; }
        // Nome da cidade
        public string Cidade { get; set; }
        // Unidade federativa
        public string UF { get; set; }

        // Classe interna para construir um objeto Endereco
        public class EnderecoBuilder
        {
            // Objeto Endereco que será construído
            private Endereco endereco;

            // Construtor que inicializa o objeto Endereco
            public EnderecoBuilder()
            {
                endereco = new Endereco();
            }

            // Método para definir o CEP do endereço
            public EnderecoBuilder ComCEP(string cep)
            {
                endereco.CEP = cep;
                return this;
            }

            // Método para definir o número da casa
            public EnderecoBuilder ComNumCasa(int numCasa)
            {
                endereco.NumCasa = numCasa;
                return this;
            }

            // Método para definir a rua do endereço
            public EnderecoBuilder NaRua(string rua)
            {
                endereco.Rua = rua;
                return this;
            }

            // Método para definir o bairro do endereço
            public EnderecoBuilder NoBairro(string bairro)
            {
                endereco.Bairro = bairro;
                return this;
            }

            // Método para definir o complemento do endereço
            public EnderecoBuilder ComComplemento(string complemento)
            {
                endereco.Complemento = complemento;
                return this;
            }

            // Método para definir a cidade do endereço
            public EnderecoBuilder NaCidade(string cidade)
            {
                endereco.Cidade = cidade;
                return this;
            }

            // Método para definir a unidade federativa do endereço
            public EnderecoBuilder NoUF(string uf)
            {
                endereco.UF = uf;
                return this;
            }

            // Método para construir o objeto Endereco com os dados fornecidos
            public Endereco Construir()
            {
                return endereco;
            }
        }
    }
}
