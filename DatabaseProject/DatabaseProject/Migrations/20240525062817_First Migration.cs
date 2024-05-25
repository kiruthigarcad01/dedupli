using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseProject.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataDeduplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDeduplication", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataDeduplication_Email",
                table: "DataDeduplication",
                column: "Email"); // Add index on Email column
        }

    }
}
