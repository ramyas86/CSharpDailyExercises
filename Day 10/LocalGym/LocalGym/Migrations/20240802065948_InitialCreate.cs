using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalGym.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Members",
            columns: table => new
            {
                MemberId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Members", x => x.MemberId);
            });

        migrationBuilder.CreateTable(
            name: "Trainers",
            columns: table => new
            {
                TrainerId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FeePer30Minutes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Trainers", x => x.TrainerId);
            });

        migrationBuilder.CreateTable(
            name: "Sessions",
            columns: table => new
            {
                SessionId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MemberId = table.Column<int>(type: "int", nullable: true),
                TrainerId = table.Column<int>(type: "int", nullable: true),
                SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Duration = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Sessions", x => x.SessionId);
                table.ForeignKey(
                    name: "FK_Sessions_Members_MemberId",
                    column: x => x.MemberId,
                    principalTable: "Members",
                    principalColumn: "MemberId");
                table.ForeignKey(
                    name: "FK_Sessions_Trainers_TrainerId",
                    column: x => x.TrainerId,
                    principalTable: "Trainers",
                    principalColumn: "TrainerId");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Sessions_MemberId",
            table: "Sessions",
            column: "MemberId");

        migrationBuilder.CreateIndex(
            name: "IX_Sessions_TrainerId",
            table: "Sessions",
            column: "TrainerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Sessions");

        migrationBuilder.DropTable(
            name: "Members");

        migrationBuilder.DropTable(
            name: "Trainers");
    }
}
