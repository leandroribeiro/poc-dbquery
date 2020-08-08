using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Usuario
    {
        public Usuario(int id, string nome)
        {
            Nome = nome;
            Id = id;
        }
        
        public Usuario(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; private set; }
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}