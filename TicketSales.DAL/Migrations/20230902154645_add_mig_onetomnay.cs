using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSales.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_onetomnay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEvent",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EventID", "IdEvent" },
                values: new object[] { new DateTime(2023, 9, 2, 18, 46, 45, 584, DateTimeKind.Local).AddTicks(4012), null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventID",
                table: "Users",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventID",
                table: "Users",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EventID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdEvent",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 15, 22, 19, 33, DateTimeKind.Local).AddTicks(8438));
        }
    }
}
