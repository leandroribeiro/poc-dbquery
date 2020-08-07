using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface ITarefaRepository
    {
        IQueryable<Tarefa> Obter();
        IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidas();
        IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasComPaginacao(int pageIndex, int pageSize);
    }
}