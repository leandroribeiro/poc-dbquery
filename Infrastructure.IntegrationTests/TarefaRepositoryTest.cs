using System.Collections.Generic;
using System.Linq;
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
            var tarefas = _repository.ObterPor(x => x.Nome.Contains("Fazer 1")).ToList();

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(11);
        }

        [Fact]
        public void ObterPorAsyncTest()
        {
            var task = _repository.ObterPorAsync(x => x.Nome.Contains("Fazer 1"));

            var tarefas = task.Result.Should().BeOfType<List<Tarefa>>().Subject;

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(11);
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
                .And.HaveCount(3);
        }

        [Fact]
        public void ObterTarefasConcluidasTest()
        {
            var tarefas = _repository.ObterTarefasConcluidas().ToList();

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(5)
                .And.OnlyContain(x => x.Concluida);
        }

        [Fact]
        public void ObterTarefasConcluidasFromSqlTest()
        {
            var tarefas = _repository.ObterTarefasConcluidasFromSql().ToList();

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(5)
                .And.OnlyContain(x => x.Concluida);
        }

        [Fact]
        public void ObterTarefasConcluidasFromSqlAsyncTest()
        {
            var task = _repository.ObterTarefasConcluidasFromSqlAsync();

            var tarefas = task.Result.Should().BeOfType<List<TarefaConcluidaQuery>>().Subject;

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(5)
                .And.OnlyContain(x => x.Concluida); // Way 1

            tarefas.All(x => x.Concluida).Should().BeTrue(); // Way 2
        }

        [Fact]
        public void ObterTarefasConcluidasFromSqlComPaginacaoTest()
        {
            var tarefas = _repository.ObterTarefasConcluidasFromSqlComPaginacao(1, 3).ToList();

            tarefas.Should().NotBeNullOrEmpty()
                .And.HaveCount(3);
        }
    }
}