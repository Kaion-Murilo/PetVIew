namespace PetView.Models
{
    // Classe Animal que representa um animal no sistema
    public class Animal
    {
        // Propriedades da classe Animal
        public int CodigoAnimal { get; set; } // Código único do animal
        public int? RGA { get; set; } // Registro Geral do Animal, pode ser nulo
        public string NomeAnimal { get; set; } // Nome do animal
        public int IdadeAnimal { get; set; } // Idade do animal
        public string Tempo { get; set; } // Unidade de tempo da idade (dias, meses, anos)
        public string Especie { get; set; } // Espécie do animal (cão, gato, etc.)
        public string Raca { get; set; } // Raça do animal
        public string Descricao { get; set; } // Descrição adicional sobre o animal
        public Dono dono { get; set; } // Objeto Dono que representa o dono do animal

        // Construtor padrão
        public Animal() { }

        // Construtor com parâmetros que inicializa um novo objeto Animal
        public Animal(int? rga, string nomeAnimal, int idadeAnimal, string tempo, string especie, string raca, string descricao, int codDono)
        {
            dono = new Dono(); // Cria um novo objeto Dono
            RGA = rga; // Inicializa o RGA do animal
            NomeAnimal = nomeAnimal; // Inicializa o nome do animal
            IdadeAnimal = idadeAnimal; // Inicializa a idade do animal
            Tempo = tempo; // Inicializa a unidade de tempo da idade
            Especie = especie; // Inicializa a espécie do animal
            Raca = raca; // Inicializa a raça do animal
            Descricao = descricao; // Inicializa a descrição do animal
            dono.CodigoDono = codDono; // Inicializa o código do dono do animal
        }
    }
}
