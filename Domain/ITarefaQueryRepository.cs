using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface ITarefaQueryRepository
    {
        IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSql();
        IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSqlComPaginacao(int pageIndex, int pageSize);
        IEnumerable<TarefaConcluidaQuery> ObterTarefasConcluidas();
        Task<List<TarefaConcluidaQuery>> ObterTarefasConcluidasFromSqlAsync();
    }
}