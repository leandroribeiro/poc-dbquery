using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class TarefaRepository : TarefaQueryRepository, ITarefaRepository, ITarefaQueryRepository
    {
        public TarefaRepository(TarefaContext context) : base(context)
        {
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

        public IQueryable<Tarefa> ObterTodasAtribuidas()
        {
            return Obter().Where(x => x.Usuario != null).Include(y=>y.Usuario);
        }
    }
}