using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ViewTarefasConcluidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW TarefasConcluidas
                AS
                SELECT 
                    t.Nome AS 'Tarefa', 
                    U.Nome AS 'Usuario', 
                    t.Concluida 
                FROM 
                    Tarefas AS T 
                    LEFT JOIN Usuarios AS U ON U.Id = T.UsuarioId 
                WHERE 
                    Concluida=1;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW TarefasConcluidas;");
        }
    }
}
