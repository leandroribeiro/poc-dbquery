using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{

    public class TarefaRepository : ITarefaRepository
    {
        public TarefaContext Context { get; }

        public TarefaRepository(TarefaContext context)
        {
            Context = context;
        }

        public IQueryable<Tarefa> Get()
        {
            return Context.Tarefas.AsQueryable();
        }

        public IQueryable<TarefaConcluidaQuery> GetTarefasConcluidas()
        {
            return Context.Query<TarefaConcluidaQuery>()
                .FromSql("SELECT *, 'Concluida' as 'Situacao' FROM Tarefa");
        }
        
        
        public IQueryable<TarefaConcluidaQuery> GetTarefasConcluidas(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;     

            return Context.Query<TarefaConcluidaQuery>().FromSql("SELECT *, 'Concluida' as 'Situacao' FROM Tarefa").Skip(skip).Take(pageSize);
        }
        
    }
}