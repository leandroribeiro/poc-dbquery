using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TarefaQueryRepository : ITarefaQueryRepository
    {
        public TarefaQueryRepository(TarefaContext context)
        {
            Context = context;
        }

        public TarefaContext Context { get; set; }
        
        public IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSql()
        {
            var query = "SELECT t.Nome AS 'Tarefa', U.Nome AS 'Usuario', Concluida FROM Tarefas AS T LEFT JOIN Usuarios AS U ON U.Id = T.UsuarioId WHERE T.Concluida=1";
            
            return Context.Query<TarefaConcluidaQuery>()
                .FromSql(query);
        }

        public IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSqlComPaginacao(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            
            return ObterTarefasConcluidasFromSql().Skip(skip).Take(pageSize);
        }

        public IEnumerable<TarefaConcluidaQuery> ObterTarefasConcluidas()
        {
            return Context.TarefasConcluidas.AsQueryable();
        }

        public Task<List<TarefaConcluidaQuery>> ObterTarefasConcluidasFromSqlAsync()
        {
            return ObterTarefasConcluidasFromSql().ToListAsync<TarefaConcluidaQuery>();
        }
    }
}