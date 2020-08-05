using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface ITarefaRepository
    {
        IQueryable<Tarefa> Get();
        IQueryable<TarefaConcluidaQuery> GetTarefasConcluidas();
        IQueryable<TarefaConcluidaQuery> GetTarefasConcluidas(int pageIndex, int pageSize);
    }
}