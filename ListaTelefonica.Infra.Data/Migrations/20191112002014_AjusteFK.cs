using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaTelefonica.Infra.Data.Migrations
{
    public partial class AjusteFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaTelefone_Pessoa_PersonId",
                schema: "public",
                table: "PessoaTelefone");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                schema: "public",
                table: "PessoaTelefone",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaTelefone_Pessoa_PersonId",
                schema: "public",
                table: "PessoaTelefone",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaTelefone_Pessoa_PersonId",
                schema: "public",
                table: "PessoaTelefone");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                schema: "public",
                table: "PessoaTelefone",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaTelefone_Pessoa_PersonId",
                schema: "public",
                table: "PessoaTelefone",
                column: "PersonId",
                principalSchema: "public",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
