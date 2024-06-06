using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetView
{
    // A interface ICadastro declara os métodos necessários para realizar operações de cadastro, incluindo inserção, atualização e exclusão de registros.
    public interface ICadastro
    {
        void Insert(); // Método para inserir um novo registro
        void Update(); // Método para atualizar um registro existente
        void Delete(); // Método para deletar um registro existente
    }
}
