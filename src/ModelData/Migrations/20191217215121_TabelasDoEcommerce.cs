using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ModelData.Migrations
{
    public partial class TabelasDoEcommerce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    DataDeEdicao = table.Column<DateTime>(nullable: true),
                    DataDeRemocao = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 400, nullable: false),
                    ImagemURL = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    DataDeEdicao = table.Column<DateTime>(nullable: true),
                    DataDeRemocao = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disco",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    DataDeEdicao = table.Column<DateTime>(nullable: true),
                    DataDeRemocao = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 400, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Categoria_Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disco_Categoria_Categoria_Id",
                        column: x => x.Categoria_Id,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    DataDeEdicao = table.Column<DateTime>(nullable: true),
                    DataDeRemocao = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Cliente_Id = table.Column<long>(nullable: false),
                    CashBackTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_Cliente_Id",
                        column: x => x.Cliente_Id,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    DataDeEdicao = table.Column<DateTime>(nullable: true),
                    DataDeRemocao = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Venda_Id = table.Column<long>(nullable: false),
                    Disco_Id = table.Column<long>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    CashBackUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaItem_Disco_Disco_Id",
                        column: x => x.Disco_Id,
                        principalTable: "Disco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaItem_Venda_Venda_Id",
                        column: x => x.Venda_Id,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disco_Categoria_Id",
                table: "Disco",
                column: "Categoria_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Cliente_Id",
                table: "Venda",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItem_Disco_Id",
                table: "VendaItem",
                column: "Disco_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItem_Venda_Id",
                table: "VendaItem",
                column: "Venda_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaItem");

            migrationBuilder.DropTable(
                name: "Disco");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
