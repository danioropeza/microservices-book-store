﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreServices.Api.ShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class MySQLInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingCartSession",
                columns: table => new
                {
                    ShoppingCartSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSession", x => x.ShoppingCartSessionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingCartSessionDetail",
                columns: table => new
                {
                    ShoppingCartSessionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SelectedProduct = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShoppingCartSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSessionDetail", x => x.ShoppingCartSessionDetailId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartSessionDetail_ShoppingCartSession_ShoppingCartSe~",
                        column: x => x.ShoppingCartSessionId,
                        principalTable: "ShoppingCartSession",
                        principalColumn: "ShoppingCartSessionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartSessionDetail_ShoppingCartSessionId",
                table: "ShoppingCartSessionDetail",
                column: "ShoppingCartSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartSessionDetail");

            migrationBuilder.DropTable(
                name: "ShoppingCartSession");
        }
    }
}
