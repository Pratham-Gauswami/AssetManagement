using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetRequestViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Asset_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Asset_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Model_No = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Serial_No = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Make_Company = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Asset_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Employee_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: false),
                    Department = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee_having_assets",
                columns: table => new
                {
                    Asset_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Employee_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Asset_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Make_Company = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date_of_assign = table.Column<DateTime>(type: "datetime", nullable: false),
                    Date_of_req = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_having_assets", x => x.Asset_Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset_Request",
                columns: table => new
                {
                    Request_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Emp_Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ReqAsset_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Asset_description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Reason = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Date_of_request = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset_Request", x => x.Request_Id);
                    table.ForeignKey(
                        name: "FK_Asset_Request_Employee",
                        column: x => x.Emp_Id,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_Request_Emp_Id",
                table: "Asset_Request",
                column: "Emp_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Asset_Request");

            migrationBuilder.DropTable(
                name: "Employee_having_assets");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
