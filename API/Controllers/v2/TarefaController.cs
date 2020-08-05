using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TarefaController
    {
        private ITarefaRepository Repository { get; }
        
        public TarefaController(ITarefaRepository repository)
        {
            Repository = repository;
        }

        // GET api/v2[controller]/concluidas[?page=1&pageSize=5]
        [Route("concluidas")]
        [HttpGet]
        public IList<TarefaConcluidaQuery> Get(int page, int pageSize)
        {
            return Repository.GetTarefasConcluidas(page, pageSize).ToList();
        }
        
    }
}