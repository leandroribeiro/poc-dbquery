using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface ITarefaRepository
    {
        IQueryable<Tarefa> Obter();
        IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSql();
        IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSqlComPaginacao(int pageIndex, int pageSize);
    }
}