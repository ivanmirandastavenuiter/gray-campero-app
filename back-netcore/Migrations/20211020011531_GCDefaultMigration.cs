using Microsoft.EntityFrameworkCore.Migrations;

namespace GC.Migrations
{
    public partial class GCDefaultMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    UrlPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.CartId, x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price", "Stock", "UrlPath" },
                values: new object[,]
                {
                    { 2000, "Amazing yummy bacon", "Bacon", 0.75f, 5, "bacon.jpg" },
                    { 2001, "Amazing yummy onion", "Onion", 0.25f, 13, "onion.jpg" },
                    { 2002, "Amazing yummy lettuce", "Lettuce", 0.2f, 25, "lettuce.jpg" },
                    { 2003, "Amazing yummy cheese", "Cheese", 0.99f, 4, "cheese.jpg" },
                    { 2004, "Amazing yummy tomato", "Tomato", 0.3f, 5, "tomato.jpg" },
                    { 2005, "Amazing yummy ham", "Ham", 0.45f, 4, "ham.jpg" },
                    { 2006, "Amazing yummy bread", "Bread", 0.1f, 70, "bread.jpg" },
                    { 2007, "Amazing yummy mayonnaise", "Mayonnaise", 0.05f, 4, "mayonnaise.jpg" },
                    { 2008, "Amazing yummy yogurt sauce", "Yogurt sauce", 0.15f, 123, "yogurt-sauce.jpg" },
                    { 2009, "Amazing yummy chicken", "Chicken", 1.25f, 3, "chicken.jpg" },
                    { 2010, "Amazing yummy arugula", "Arugula", 0.08f, 3, "arugula.jpg" },
                    { 2011, "Amazing yummy carrot", "Carrot", 0.02f, 5, "carrot.jpg" },
                    { 2012, "Amazing yummy lamb", "Lamb", 2f, 10, "lamb.jpg" },
                    { 2013, "Amazing yummy pork", "Pork", 0.65f, 12, "pork.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Lastname", "Name" },
                values: new object[,]
                {
                    { 1001, "ivanmist90@gmail.com", "Miranda Stavenuiter", "Iván" },
                    { 1002, "gc-admin@gmail.com", "gc-admin", "GCAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "ProductId", "UserId", "Quantity", "Status" },
                values: new object[,]
                {
                    { 3000, 2000, 1001, 1, "ACTIVE" },
                    { 3000, 2001, 1001, 3, "ACTIVE" },
                    { 3000, 2003, 1001, 2, "ACTIVE" },
                    { 3001, 2009, 1002, 1, "ACTIVE" },
                    { 3001, 2010, 1002, 2, "ACTIVE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
