using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoGame.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDescricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    CadastroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastroNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.CadastroId);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotaValor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.NotaId);
                });

            migrationBuilder.CreateTable(
                name: "Descricao",
                columns: table => new
                {
                    DescricaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotaId = table.Column<int>(type: "int", nullable: false),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    DescricaoJogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descricao", x => x.DescricaoId);
                    table.ForeignKey(
                        name: "FK_Descricao_Cadastro_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastro",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Descricao_Nota_NotaId",
                        column: x => x.NotaId,
                        principalTable: "Nota",
                        principalColumn: "NotaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descricao_CadastroId",
                table: "Descricao",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Descricao_NotaId",
                table: "Descricao",
                column: "NotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descricao");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "Nota");
        }
    }
}
