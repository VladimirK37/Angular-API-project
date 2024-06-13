using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Power = table.Column<int>(type: "integer", nullable: false),
                    Current = table.Column<int>(type: "integer", nullable: false),
                    NominalSpeed = table.Column<int>(type: "integer", nullable: false),
                    Motor = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nasoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxPressure = table.Column<double>(type: "double precision", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MotorEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialHullId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImpellerMaterialId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nasoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nasoses_Materials_ImpellerMaterialId",
                        column: x => x.ImpellerMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nasoses_Materials_MaterialHullId",
                        column: x => x.MaterialHullId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nasoses_Motors_MotorEntityId",
                        column: x => x.MotorEntityId,
                        principalTable: "Motors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nasoses_ImpellerMaterialId",
                table: "Nasoses",
                column: "ImpellerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Nasoses_MaterialHullId",
                table: "Nasoses",
                column: "MaterialHullId");

            migrationBuilder.CreateIndex(
                name: "IX_Nasoses_MotorEntityId",
                table: "Nasoses",
                column: "MotorEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nasoses");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Motors");
        }
    }
}
