using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SeedsClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financiamentos_Clientes_cpf",
                table: "Financiamentos");

            migrationBuilder.DropIndex(
                name: "IX_Financiamentos_cpf",
                table: "Financiamentos");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Financiamentos",
                newName: "Cpf");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Financiamentos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Financiamentos_Cpf",
                table: "Financiamentos",
                column: "Cpf");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Cpf", "Celular", "Nome", "UF" },
                values: new object[,]
                {
                    { "27585548010", "5126262626", "Zazu", "RS" },
                    { "30439355001", "1126232623", "Scar", "SP" },
                    { "61450660088", "4166666666", "Ed", "PR" },
                    { "67482339094", "1165656565", "Rafiki", "SP" },
                    { "71676470042", "1198989898", "Nala", "SP" },
                    { "83799824014", "1165686568", "Mufasa", "SP" },
                    { "89387788008", "4155668899", "Simba", "PR" },
                    { "90406710015", "1166996699", "Pumba", "SP" },
                    { "99927465050", "1158585858", "Timão", "SP" }
                });

            migrationBuilder.InsertData(
                table: "Financiamentos",
                columns: new[] { "Id", "Cpf", "DataUltimoVencimento", "TipoFinanciamento", "ValorTotal" },
                values: new object[,]
                {
                    { 1, "90406710015", new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3552), 1, 5000m },
                    { 2, "67482339094", new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3560), 1, 5000m },
                    { 3, "89387788008", new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3561), 1, 5000m },
                    { 4, "99927465050", new DateTime(2023, 1, 25, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3562), 4, 5000m },
                    { 5, "27585548010", new DateTime(2023, 1, 25, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3564), 4, 5000m },
                    { 6, "71676470042", new DateTime(2023, 1, 25, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3566), 4, 5000m },
                    { 7, "83799824014", new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3567), 4, 5000m },
                    { 8, "30439355001", new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3567), 4, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataPagamento", "DataVencimento", "IdFinanciamento", "NumeroParcela", "ValorParcela" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3583), new DateTime(2022, 6, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3583), 1, 1, 1000m },
                    { 2, new DateTime(2022, 7, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3588), new DateTime(2022, 7, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3587), 1, 2, 1000m },
                    { 3, new DateTime(2022, 8, 28, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3589), new DateTime(2022, 8, 28, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3589), 1, 3, 1000m },
                    { 4, new DateTime(2022, 9, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3591), new DateTime(2022, 9, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3590), 1, 4, 1000m },
                    { 5, null, new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3592), 1, 5, 1000m },
                    { 6, new DateTime(2022, 7, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3593), new DateTime(2022, 7, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3593), 2, 1, 1000m },
                    { 7, new DateTime(2022, 8, 28, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3594), new DateTime(2022, 8, 28, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3594), 2, 2, 1000m },
                    { 8, new DateTime(2022, 9, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3596), new DateTime(2022, 9, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3595), 2, 3, 1000m },
                    { 9, null, new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3598), 2, 4, 1000m },
                    { 10, null, new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3599), 2, 5, 1000m },
                    { 11, null, new DateTime(2022, 9, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3632), 3, 1, 1000m },
                    { 12, null, new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3633), 3, 2, 1000m },
                    { 13, null, new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3634), 3, 3, 1000m },
                    { 14, null, new DateTime(2022, 12, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3635), 3, 4, 1000m },
                    { 15, null, new DateTime(2023, 1, 25, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3636), 3, 5, 1000m },
                    { 16, null, new DateTime(2022, 9, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3637), 4, 1, 1000m },
                    { 17, null, new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3638), 4, 2, 1000m },
                    { 18, null, new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3639), 4, 3, 1000m },
                    { 19, null, new DateTime(2022, 12, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3640), 4, 4, 1000m },
                    { 20, null, new DateTime(2023, 1, 25, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3641), 4, 5, 1000m },
                    { 21, null, new DateTime(2022, 9, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3641), 5, 1, 1000m },
                    { 22, null, new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3642), 5, 2, 1000m },
                    { 23, null, new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3644), 5, 3, 1000m },
                    { 24, null, new DateTime(2022, 12, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3645), 5, 4, 1000m },
                    { 25, null, new DateTime(2023, 1, 25, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3646), 5, 5, 1000m },
                    { 26, null, new DateTime(2022, 7, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3647), 6, 1, 1000m },
                    { 27, null, new DateTime(2022, 8, 28, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3649), 6, 2, 1000m },
                    { 28, null, new DateTime(2022, 9, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3650), 6, 3, 1000m },
                    { 29, null, new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3651), 6, 4, 1000m },
                    { 30, null, new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3652), 6, 5, 1000m },
                    { 31, null, new DateTime(2022, 7, 29, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3653), 7, 1, 1000m },
                    { 32, null, new DateTime(2022, 8, 28, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3654), 7, 2, 1000m },
                    { 33, null, new DateTime(2022, 9, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3655), 7, 3, 1000m },
                    { 34, null, new DateTime(2022, 10, 27, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3656), 7, 4, 1000m },
                    { 35, null, new DateTime(2022, 11, 26, 15, 32, 53, 861, DateTimeKind.Utc).AddTicks(3657), 7, 5, 1000m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Financiamentos_Clientes_Cpf",
                table: "Financiamentos",
                column: "Cpf",
                principalTable: "Clientes",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financiamentos_Clientes_Cpf",
                table: "Financiamentos");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Financiamentos_Cpf",
                table: "Financiamentos");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "61450660088");

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Parcelas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "30439355001");

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Financiamentos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "27585548010");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "67482339094");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "71676470042");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "83799824014");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "89387788008");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "90406710015");

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Cpf",
                keyValue: "99927465050");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Financiamentos",
                newName: "cpf");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Financiamentos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Financiamentos_cpf",
                table: "Financiamentos",
                column: "cpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Financiamentos_Clientes_cpf",
                table: "Financiamentos",
                column: "cpf",
                principalTable: "Clientes",
                principalColumn: "Cpf");
        }
    }
}
