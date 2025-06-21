using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSSDotNetTrainingBatch2.MiniPosConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteFlagColumnToAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeleteFlag",
                table: "Tbl_SaleDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteFlag",
                table: "Tbl_Sale",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteFlag",
                table: "Tbl_Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteFlag",
                table: "Tbl_SaleDetail");

            migrationBuilder.DropColumn(
                name: "DeleteFlag",
                table: "Tbl_Sale");

            migrationBuilder.DropColumn(
                name: "DeleteFlag",
                table: "Tbl_Product");
        }
    }
}
