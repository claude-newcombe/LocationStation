using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationStationDataAccessLibrary.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    LocationName = table.Column<string>(nullable: true),
                    XCoordinate = table.Column<int>(nullable: false),
                    YCoordinate = table.Column<int>(nullable: false),
                    Metadata = table.Column<string>(nullable: true),
                    YouTubeLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicItems");
        }
    }
}
