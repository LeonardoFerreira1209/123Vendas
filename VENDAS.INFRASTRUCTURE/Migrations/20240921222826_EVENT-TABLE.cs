using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VENDAS.INFRASTRUCTURE.Migrations
{
    /// <inheritdoc />
    public partial class EVENTTABLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Processed = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Sended = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SchedulerTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    JsonBody = table.Column<string>(type: "longtext", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
