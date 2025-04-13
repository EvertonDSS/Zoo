using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciamentoZoo.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Especie = table.Column<string>(type: "text", nullable: false),
                    Habitat = table.Column<string>(type: "text", nullable: false),
                    PaisOrigem = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCuidado = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Frequencia = table.Column<int>(type: "integer", nullable: false),
                    UnidadeFrequencia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimaisEntityCuidadosEntity",
                columns: table => new
                {
                    AnimaisId = table.Column<int>(type: "integer", nullable: false),
                    CuidadosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimaisEntityCuidadosEntity", x => new { x.AnimaisId, x.CuidadosId });
                    table.ForeignKey(
                        name: "FK_AnimaisEntityCuidadosEntity_Animais_AnimaisId",
                        column: x => x.AnimaisId,
                        principalTable: "Animais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimaisEntityCuidadosEntity_Cuidados_CuidadosId",
                        column: x => x.CuidadosId,
                        principalTable: "Cuidados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimaisEntityCuidadosEntity_CuidadosId",
                table: "AnimaisEntityCuidadosEntity",
                column: "CuidadosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimaisEntityCuidadosEntity");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Cuidados");
        }
    }
}
