using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSales.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 15, 22, 19, 33, DateTimeKind.Local).AddTicks(8438));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventsID = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.EventsID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_EventUser_Events_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 12, 50, 53, 423, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UsersID",
                table: "EventUser",
                column: "UsersID");
        }
    }
}
