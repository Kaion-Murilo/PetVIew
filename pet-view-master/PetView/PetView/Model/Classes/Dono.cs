﻿using PetView.Model.Classes.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetView
{
    public class Dono : FacPessoa
    {

        public int CodigoDono { get; set; }

        public String TelDono { get; set; }

        public Endereco Endereco { get; set; }
        public override string Nome { get; set; }
        public override string CPF { get; set; }
        public override string RG { get; set; }
        public override string Cel { get; set; }
        public override string Email { get; set; }

        public Dono() { }

        public Dono(string nomeDono, string cPFDono, string rGDono, string celDono,
            string telDono, string emailDono, string cep, string bairro, 
            string cidade, string complemento, int numcasa, string rua, string uf)
        {

            this.Nome = nomeDono;
            this.CPF = cPFDono;
            this.RG = rGDono;
            this.Cel = celDono;
            TelDono = telDono;
            this.Email = emailDono;
            Endereco = new Endereco.EnderecoBuilder()
            .ComCEP(cep)
            .ComNumCasa(numcasa)
            .NaRua(rua)
            .NoBairro(bairro)
            .ComComplemento(complemento)
            .NaCidade(cidade)
            .NoUF(uf)
            .Construir();

        }
        public static Dono CriarDono(IPessoaFactory factory, string nome, string cpf, string rg, string cel,
                             string tel, string email, string cep, string bairro,
                             string cidade, string complemento, int numcasa, string rua, string uf)
        {
            return (Dono)factory.CriarPessoa(nome, cpf, rg, cel, tel, email, cep, bairro, cidade, complemento, numcasa, rua, uf);
        }
    }
}