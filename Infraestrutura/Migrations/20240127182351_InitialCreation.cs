using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "VARCHAR", nullable: false, defaultValue: "100")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sonho",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    pessoaId = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    criacao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2024, 1, 27, 18, 23, 50, 862, DateTimeKind.Utc).AddTicks(2795)),
                    realizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sonho", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Sonho",
                        column: x => x.pessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "NCHARNCHAR", maxLength: 55, nullable: false),
                    descricao = table.Column<string>(type: "VARCHAR", maxLength: 200, nullable: false),
                    QuantidadePorPeriodo = table.Column<int>(type: "INT", nullable: false),
                    ativa = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    Periodicidade = table.Column<int>(type: "VARCHAR", maxLength: 50, nullable: false),
                    SonhoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sonho_Tarefa",
                        column: x => x.SonhoId,
                        principalTable: "Sonho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feito",
                columns: table => new
                {
                    idTarefa = table.Column<Guid>(type: "uuid", nullable: false),
                    data = table.Column<DateTime>(type: "DATE", nullable: false),
                    concluido = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feito", x => new { x.idTarefa, x.data });
                    table.ForeignKey(
                        name: "FK_tarefa_feito",
                        column: x => x.idTarefa,
                        principalTable: "Tarefa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recordacao",
                columns: table => new
                {
                    foto = table.Column<string>(type: "TEXT", nullable: false),
                    data = table.Column<DateTime>(type: "DATE", nullable: false),
                    SonhoId = table.Column<Guid>(type: "uuid", nullable: true),
                    TarefaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordacao", x => new { x.foto, x.data });
                    table.ForeignKey(
                        name: "FK_Recordacao_Tarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefa",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Sonho_Recordacao",
                        column: x => x.SonhoId,
                        principalTable: "Sonho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recordacao_SonhoId",
                table: "Recordacao",
                column: "SonhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordacao_TarefaId",
                table: "Recordacao",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sonho_pessoaId",
                table: "Sonho",
                column: "pessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_SonhoId",
                table: "Tarefa",
                column: "SonhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feito");

            migrationBuilder.DropTable(
                name: "Recordacao");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Sonho");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
