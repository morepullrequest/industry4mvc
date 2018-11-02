using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Data.Migrations
{
    public partial class feedbk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emergingTechnologiesFeedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Heading = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Feedback = table.Column<string>(nullable: true),
                    Agree = table.Column<int>(nullable: false),
                    Disagree = table.Column<int>(nullable: false),
                    EmergingTechnologiesName = table.Column<string>(nullable: true),
                    OwnerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergingTechnologiesFeedbacks", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emergingTechnologiesFeedbacks");
        }
    }
}
