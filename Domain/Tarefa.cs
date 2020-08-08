namespace Domain
{
    public class Tarefa
    {
        public Tarefa(int id, string nome, bool concluida)
        {
            Id = id;
            Nome = nome;
            if(concluida)
                this.MarcarComoConcluida();
        }   
        
        public Tarefa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }        
        public Tarefa(string nome)
        {
            Nome = nome;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public bool Concluida { get; private set; }
        public Usuario Usuario { get; private set; }

        public void AtribuirUsuario(Usuario usuario)
        {
            this.Usuario = usuario;
        }
        public void MarcarComoConcluida()
        {
            this.Concluida = true;
        }
    }
}