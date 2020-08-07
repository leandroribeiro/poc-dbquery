using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Infrastructure.IntegrationTests
{
    public class TarefaRepositoryTest
    {
        private readonly TarefaRepository _repository;

        public TarefaRepositoryTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<TarefaContext>();

            builder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=TarefaDb;User Id=sa;Password=Dev123456789;")
                .UseInternalServiceProvider(serviceProvider);

            var context = new TarefaContext(builder.Options);
            _repository = new TarefaRepository(context);
        }
        
        [Fact]
        public void ObterTest()
        {
            var tarefas = _repository.Obter().ToList();

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCountGreaterOrEqualTo(20);
        }
        
        [Fact]
        public void ObterPorTest()
        {
            var tarefas = _repository.ObterPor(x=>x.Nome.Contains("E00")).ToList();
            
            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(9);
        }
        
        [Fact]
        public void ObterPorAsyncTest()
        {
            var task = _repository.ObterPorAsync(x=>x.Nome.Contains("E00"));

            var tarefas = task.Result.Should().BeOfType<List<Tarefa>>().Subject;
            
            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(9);
        }
        
        [Fact]
        public void ObterTodasAsyncTest()
        {
            var task = _repository.ObterTodasAsync();

            var tarefas = task.Result.Should().BeOfType<List<Tarefa>>().Subject;
            
            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(20);
        }
        
        [Fact]
        public void ObterComPaginacaoTest()
        {
            var tarefas = _repository.ObterComPaginacao(1, 3).ToList();

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCountGreaterOrEqualTo(3);
        }
        
    }
}
