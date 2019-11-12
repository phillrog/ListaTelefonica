using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListaTelefonica.Infra.Data.Migrations
{
    public partial class CorrecaoPersonPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "public",
                table: "Pessoa",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 12, 11, 35, 4, 492, DateTimeKind.Local).AddTicks(99),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 12, 1, 59, 12, 122, DateTimeKind.Local).AddTicks(2060));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "public",
                table: "Pessoa",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 12, 1, 59, 12, 122, DateTimeKind.Local).AddTicks(2060),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 12, 11, 35, 4, 492, DateTimeKind.Local).AddTicks(99));
        }
    }
}
