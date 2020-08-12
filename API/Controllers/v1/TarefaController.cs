using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{

    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TarefaController
    {
        private readonly ITarefaRepository _repository;

        public TarefaController(ITarefaRepository repository)
        {
            _repository = repository;
        }
        
        // GET api/v1/[controller]/ping
        [Route("ping")]
        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }
        
        // GET api/v1/[controller][?page=1&pageSize=5]
        [HttpGet]
        public PagedResult<Tarefa> Get(int page = 0, int pageSize = 5)
        {
            return _repository.Obter().GetPaged(page, pageSize);
        }
        
        // GET api/v1/[controller]/concluidas[?page=1&pageSize=5]
        [Route("concluidas")]
        [HttpGet]
        public PagedResult<TarefaConcluidaQuery> Paged(int page, int pageSize)
        {
            return _repository.ObterTarefasConcluidasFromSql().GetPaged(page, pageSize);
        }
        
    }
}