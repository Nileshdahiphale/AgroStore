using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroStore.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProviderIdAddedToTheCouponTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProviderId",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Coupons");
        }
    }
}
