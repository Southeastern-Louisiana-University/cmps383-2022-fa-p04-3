using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA22.P04.Web.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "Listing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Listing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Listing",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNameString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ListingId",
                table: "Listing",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_OwnerId",
                table: "Listing",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ProductId",
                table: "Listing",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId1",
                table: "UserRole",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Listing_ListingId",
                table: "Listing",
                column: "ListingId",
                principalTable: "Listing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Product_ProductId",
                table: "Listing",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_User_OwnerId",
                table: "Listing",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Listing_ListingId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Product_ProductId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_User_OwnerId",
                table: "Listing");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ListingId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_OwnerId",
                table: "Listing");

            migrationBuilder.DropIndex(
                name: "IX_Listing_ProductId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Listing");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Listing");
        }
    }
}
