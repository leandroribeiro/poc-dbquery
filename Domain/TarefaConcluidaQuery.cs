namespace Domain
{
    public class TarefaConcluidaQuery
    {
        public TarefaConcluidaQuery()
        {
            
        }

        public string Tarefa { get; private set; }
        
        public string Usuario { get; private set; }
        
        public bool Concluida { get; private set; }
    }
}