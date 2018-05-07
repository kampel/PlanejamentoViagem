using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace App.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "LocalInteresse",
                columns: table => new
                {
                    IdLocalInteresse = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdEndereco = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    TipoLocalInteresse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalInteresse", x => x.IdLocalInteresse);
                    table.ForeignKey(
                        name: "FK_LocalInteresse_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajante",
                columns: table => new
                {
                    IdViajante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    IdEndereco = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajante", x => x.IdViajante);
                    table.ForeignKey(
                        name: "FK_Viajante_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roteiro",
                columns: table => new
                {
                    IdRoteiro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    IdViajante = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roteiro", x => x.IdRoteiro);
                    table.ForeignKey(
                        name: "FK_Roteiro_Viajante_IdViajante",
                        column: x => x.IdViajante,
                        principalTable: "Viajante",
                        principalColumn: "IdViajante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoteiroLocalInteresse",
                columns: table => new
                {
                    IdRoteiro = table.Column<int>(nullable: false),
                    IdLocalInteresse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoteiroLocalInteresse", x => new { x.IdRoteiro, x.IdLocalInteresse });
                    table.ForeignKey(
                        name: "FK_RoteiroLocalInteresse_LocalInteresse_IdLocalInteresse",
                        column: x => x.IdLocalInteresse,
                        principalTable: "LocalInteresse",
                        principalColumn: "IdLocalInteresse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoteiroLocalInteresse_Roteiro_IdRoteiro",
                        column: x => x.IdRoteiro,
                        principalTable: "Roteiro",
                        principalColumn: "IdRoteiro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalInteresse_IdEndereco",
                table: "LocalInteresse",
                column: "IdEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roteiro_IdViajante",
                table: "Roteiro",
                column: "IdViajante");

            migrationBuilder.CreateIndex(
                name: "IX_RoteiroLocalInteresse_IdLocalInteresse",
                table: "RoteiroLocalInteresse",
                column: "IdLocalInteresse");

            migrationBuilder.CreateIndex(
                name: "IX_Viajante_IdEndereco",
                table: "Viajante",
                column: "IdEndereco",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoteiroLocalInteresse");

            migrationBuilder.DropTable(
                name: "LocalInteresse");

            migrationBuilder.DropTable(
                name: "Roteiro");

            migrationBuilder.DropTable(
                name: "Viajante");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
