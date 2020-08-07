namespace Domain
{
    public class Tarefa
    {
        public Tarefa(string nome, decimal codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public decimal Codigo { get; }
        public string Nome { get; }
        
        public bool Concluida { get; private set; }

        public void MarcarComoConcluida()
        {
            this.Concluida = true;
        }
    }
}