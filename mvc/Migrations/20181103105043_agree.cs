using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class agree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agrees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyFeedbackId = table.Column<int>(nullable: false),
                    TechFeedbackId = table.Column<int>(nullable: false),
                    AgreeOrDisagree = table.Column<string>(nullable: true),
                    FeedbackType = table.Column<string>(nullable: true),
                    Cookie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agrees", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agrees");
        }
    }
}
