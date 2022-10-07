using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_crud_mvc.Migrations
{
    public partial class CategoryAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizze_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Pizze",
                columns: new[] { "Id", "CategoryId", "Descrizione", "Foto", "Nome", "Prezzo" },
                values: new object[,]
                {
                    { 1, null, "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo", "img/pizza.jpg", "Margherita", 5.0 },
                    { 2, null, "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo", "img/pizza.jpg", "Margherita", 5.0 },
                    { 3, null, "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo", "img/pizza.jpg", "Margherita", 5.0 },
                    { 4, null, "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo", "img/pizza.jpg", "Margherita", 5.0 },
                    { 5, null, "Pom. San Marzano D.O.P, Fior di Latte , Olio Evo", "img/pizza.jpg", "Margherita", 5.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_CategoryId",
                table: "Pizze",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizze");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
