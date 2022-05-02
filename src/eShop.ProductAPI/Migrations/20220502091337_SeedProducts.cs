using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Products(Name, Price, Description, Stock, ImageUrl, CategoryId)
                                    VALUES ('Caderno', 7.55, 'Caderno espiral', 10, 'caderno1.jpg', 1)");

            migrationBuilder.Sql(@"INSERT INTO Products(Name, Price, Description, Stock, ImageUrl, CategoryId)
                                    VALUES ('Lápis', 3.45, 'Lápis preto', 220, 'lapis1.jpg', 1)");

            migrationBuilder.Sql(@"INSERT INTO Products(Name, Price, Description, Stock, ImageUrl, CategoryId)
                                    VALUES ('Clips', 5.33, 'Clips para papel', 50, 'clips1.jpg', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
