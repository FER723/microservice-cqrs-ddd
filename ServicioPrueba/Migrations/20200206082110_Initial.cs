using Microsoft.EntityFrameworkCore.Migrations;

namespace ServicioPrueba.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clips_atributos",
                columns: table => new
                {
                    idAtributo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vchAtributo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clips_atributos", x => x.idAtributo);
                });

            migrationBuilder.CreateTable(
                name: "clips_atributosKK",
                columns: table => new
                {
                    idAtributo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vchAtributo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clips_atributosKK", x => x.idAtributo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clips_atributos");

            migrationBuilder.DropTable(
                name: "clips_atributosKK");
        }
    }
}
