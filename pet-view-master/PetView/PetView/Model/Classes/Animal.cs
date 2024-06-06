using System;

namespace PetView.Models
{
    public class Animal
    {
        public int CodigoAnimal { get; set; }
        public int? RGA { get; set; }
        public string NomeAnimal { get; set; }
        public int IdadeAnimal { get; set; }
        public string Tempo { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public string Descricao { get; set; }
        public Dono dono { get; set; }

        public Animal() { }

        public Animal(int? rga, string nomeAnimal, int idadeAnimal, string tempo, string especie, string raca, string descricao, int codDono)
        {
            dono = new Dono();
            RGA = rga;

            NomeAnimal = nomeAnimal;
            
            IdadeAnimal = idadeAnimal;
           
            Tempo = tempo;
            
            Especie = especie;
            
            Raca = raca;
           
            Descricao = descricao;
  
            dono.CodigoDono = codDono;
           
       
        }
    }
}
