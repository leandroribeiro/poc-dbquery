using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InsercaoDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Usuarios",
                columns: new[] {"Id", "Nome"},
                values: new object[,]
                {
                    { 1, "Fulano" },
                    { 2, "Beltrano" },
                    { 3, "Ciclano" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tarefas",
                columns: new[] { "Id", "Concluida", "Nome", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, "Fazer 1", 1 },
                    { 2, true, "Fazer 2", 2 },
                    { 3, true, "Fazer 3", 3 },
                    { 4, true, "Fazer 4", 2 },
                    { 5, true, "Fazer 5", 1 },
                    
                    { 6, false, "Fazer 6", 2 },
                    { 7, false, "Fazer 7", 3 },
                    { 8, false, "Fazer 8", 2 },
                    { 9, false, "Fazer 9", 1 },
                    
                    { 10, false, "Fazer 10", null },
                    { 11, false, "Fazer 11", null },
                    { 12, false, "Fazer 12", null },
                    { 13, false, "Fazer 13", null },
                    { 14, false, "Fazer 14", null },
                    { 15, false, "Fazer 15", null },
                    { 16, false, "Fazer 16", null },
                    { 17, false, "Fazer 17", null },
                    { 18, false, "Fazer 18", null },
                    { 19, false, "Fazer 19", null },
                    
                    { 20, false, "Fazer 20", null },
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
