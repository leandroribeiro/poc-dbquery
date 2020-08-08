using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<Tarefa> Obter()
        {
            return Context.Tarefas.AsQueryable();
        }
        
        public IList<Tarefa> ObterPor(Expression<Func<Tarefa, bool>> expression)
        {
            return Context.Tarefas.Where(expression).ToList();
        }
        
        public Task<List<Tarefa>> ObterPorAsync(Expression<Func<Tarefa, bool>> expression)
        {
            return Context.Tarefas.Where(expression).ToListAsync();
        }
        
        public Task<List<Tarefa>> ObterTodasAsync()
        {
            return Obter().ToListAsync();
        }
        
        public IQueryable<Tarefa> ObterComPaginacao(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            
            return Obter().Skip(skip).Take(pageSize);
        }

        public IEnumerable<TarefaConcluidaQuery> ObterTarefasConcluidas()
        {
            return Context.TarefasConcluidas.AsQueryable();
        }
        
        public IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSql()
        {
            var query = "SELECT t.Nome AS 'Tarefa', U.Nome AS 'Usuario', Concluida FROM Tarefas AS T LEFT JOIN Usuarios AS U ON U.Id = T.UsuarioId WHERE T.Concluida=1";
            
            return Context.Query<TarefaConcluidaQuery>()
                .FromSql(query);
        }

        public Task<List<TarefaConcluidaQuery>> ObterTarefasConcluidasFromSqlAsync()
        {
            return ObterTarefasConcluidasFromSql().ToListAsync();
        }
        
        public IQueryable<TarefaConcluidaQuery> ObterTarefasConcluidasFromSqlComPaginacao(int pageIndex, int pageSize)
        {
            var skip = (pageIndex - 1) * pageSize;
            
            return ObterTarefasConcluidasFromSql().Skip(skip).Take(pageSize);
        }
        
    }
}