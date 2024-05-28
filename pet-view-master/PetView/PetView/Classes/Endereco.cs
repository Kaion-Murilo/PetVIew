using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView
{
    public class Endereco
    {
        public string CEP { get; set; }
        public int NumCasa { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public class EnderecoBuilder
        {
            private Endereco endereco;

            public EnderecoBuilder()
            {
                endereco = new Endereco();
            }

            public EnderecoBuilder ComCEP(string cep)
            {
                endereco.CEP = cep;
                return this;
            }

            public EnderecoBuilder ComNumCasa(int numCasa)
            {
                endereco.NumCasa = numCasa;
                return this;
            }

            public EnderecoBuilder NaRua(string rua)
            {
                endereco.Rua = rua;
                return this;
            }

            public EnderecoBuilder NoBairro(string bairro)
            {
                endereco.Bairro = bairro;
                return this;
            }

            public EnderecoBuilder ComComplemento(string complemento)
            {
                endereco.Complemento = complemento;
                return this;
            }

            public EnderecoBuilder NaCidade(string cidade)
            {
                endereco.Cidade = cidade;
                return this;
            }

            public EnderecoBuilder NoUF(string uf)
            {
                endereco.UF = uf;
                return this;
            }

            public Endereco Construir()
            {
                return endereco;
            }
        }
    }

}
