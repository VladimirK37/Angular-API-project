using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class MaterialNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nasoses_Materials_ImpellerMaterialId",
                table: "Nasoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Nasoses_Materials_MaterialHullId",
                table: "Nasoses");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialHullId",
                table: "Nasoses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImpellerMaterialId",
                table: "Nasoses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Nasoses_Materials_ImpellerMaterialId",
                table: "Nasoses",
                column: "ImpellerMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nasoses_Materials_MaterialHullId",
                table: "Nasoses",
                column: "MaterialHullId",
                principalTable: "Materials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nasoses_Materials_ImpellerMaterialId",
                table: "Nasoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Nasoses_Materials_MaterialHullId",
                table: "Nasoses");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialHullId",
                table: "Nasoses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ImpellerMaterialId",
                table: "Nasoses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nasoses_Materials_ImpellerMaterialId",
                table: "Nasoses",
                column: "ImpellerMaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nasoses_Materials_MaterialHullId",
                table: "Nasoses",
                column: "MaterialHullId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
