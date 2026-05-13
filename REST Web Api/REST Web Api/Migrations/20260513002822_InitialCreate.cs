using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_Web_Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(10)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentManufacturesld = table.Column<int>(type: "int", nullable: false),
                    ComponentTypesld = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Components_ComponentManufacturers_ComponentManufacturesld",
                        column: x => x.ComponentManufacturesld,
                        principalTable: "ComponentManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_ComponentTypes_ComponentTypesld",
                        column: x => x.ComponentTypesld,
                        principalTable: "ComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCComponents",
                columns: table => new
                {
                    PCId = table.Column<int>(type: "int", nullable: false),
                    ComponentCode = table.Column<string>(type: "char(10)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCComponents", x => new { x.PCId, x.ComponentCode });
                    table.ForeignKey(
                        name: "FK_PCComponents_Components_ComponentCode",
                        column: x => x.ComponentCode,
                        principalTable: "Components",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCComponents_PCs_PCId",
                        column: x => x.PCId,
                        principalTable: "PCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "INTEL", new DateTime(1982, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Group" },
                    { 2, "NVIDIA", new DateTime(1962, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nvidia Group" },
                    { 3, "Corsair", new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corsair Group" },
                    { 4, "Kingston", new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kingston Group" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Central Processing Unit" },
                    { 2, "GPU", "Graphics Processing Unit" },
                    { 3, "RAM", "Random Access Memory" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheap PC", 10, 24, 13f },
                    { 2, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium PC", 5, 36, 16f },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming PC", 3, 12, 22f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturesld", "ComponentTypesld", "Description", "Name" },
                values: new object[,]
                {
                    { "DDR4 16GB", 4, 3, "16GB (2x8GB) 6000MHz RAM", "DDR4 16GB RAM" },
                    { "DDR5 16GB", 3, 3, "16GB (2x8GB) 6000MHz RAM", "DDR5 16GB RAM" },
                    { "I7-6950K", 1, 1, "Intel Core i7-6950K", "Intel Core i7-6950K" },
                    { "RTX5090", 2, 2, "New nvidia graphic card", "NVIDIA Geforce RTX 5090" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PCId", "Amount" },
                values: new object[,]
                {
                    { "DDR5 16GB", 2, 2 },
                    { "I7-6950K", 2, 1 },
                    { "RTX5090", 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentManufacturesld",
                table: "Components",
                column: "ComponentManufacturesld");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentTypesld",
                table: "Components",
                column: "ComponentTypesld");

            migrationBuilder.CreateIndex(
                name: "IX_PCComponents_ComponentCode",
                table: "PCComponents",
                column: "ComponentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCComponents");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "PCs");

            migrationBuilder.DropTable(
                name: "ComponentManufacturers");

            migrationBuilder.DropTable(
                name: "ComponentTypes");
        }
    }
}
