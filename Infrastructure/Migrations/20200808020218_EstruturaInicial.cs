using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class EstruturaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Concluida = table.Column<bool>(nullable: false, defaultValue: false),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "dbo",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Tarefas",
                columns: new[] { "Id", "Concluida", "Nome", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, "Fazer 1", null },
                    { 20, false, "Fazer 20", null },
                    { 19, false, "Fazer 19", null },
                    { 18, false, "Fazer 18", null },
                    { 17, false, "Fazer 17", null },
                    { 16, false, "Fazer 16", null },
                    { 15, false, "Fazer 15", null },
                    { 14, false, "Fazer 14", null },
                    { 13, false, "Fazer 13", null },
                    { 11, false, "Fazer 11", null },
                    { 12, false, "Fazer 12", null },
                    { 9, false, "Fazer 9", null },
                    { 8, false, "Fazer 8", null },
                    { 7, false, "Fazer 7", null },
                    { 6, false, "Fazer 6", null },
                    { 5, true, "Fazer 5", null },
                    { 4, true, "Fazer 4", null },
                    { 3, true, "Fazer 3", null },
                    { 2, true, "Fazer 2", null },
                    { 10, false, "Fazer 10", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Usuarios",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 2, "Beltrano" },
                    { 1, "Fulano" },
                    { 3, "Ciclano" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId",
                schema: "dbo",
                table: "Tarefas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "dbo");
        }
    }
}
