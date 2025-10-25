using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCEcommerce.Migrations
{
    /// <inheritdoc />
    public partial class CreditCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreditCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installments_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), "axess" },
                    { new Guid("fce20ea5-7ace-4965-9024-3792bedca3f2"), "world" },
                    { new Guid("fce20ea5-7ace-4965-9024-3792bedca3f3"), "bonus" },
                    { new Guid("fce20ea5-7ace-4965-9024-3792bedca3f4"), "maximum" },
                    { new Guid("fce20ea5-7ace-4965-9024-3792bedca3f5"), "advantage" },
                    { new Guid("fce20ea5-7ace-4965-9024-3792bedca3f6"), "bankkart" }
                });

            migrationBuilder.InsertData(
                table: "Installments",
                columns: new[] { "Id", "Count", "CreditCardId", "Rate" },
                values: new object[,]
                {
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3e08"), 2, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f2"), 1m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3e10"), 6, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f2"), 1m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3e11"), 8, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f2"), 1.15m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3e12"), 9, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f2"), 1.22m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3e13"), 12, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f2"), 1.28m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3eb3"), 4, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), 1m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3ed0"), 2, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), 1m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3ed1"), 3, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), 1m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3ed4"), 6, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), 1m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3ed5"), 8, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), 1.10m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3ed6"), 9, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), 1.20m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3ed7"), 12, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f1"), 1.30m },
                    { new Guid("ab107747-f610-4752-8a97-2ebcac3c3ed9"), 3, new Guid("fce20ea5-7ace-4965-9024-3792bedca3f2"), 1m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installments_CreditCardId",
                table: "Installments",
                column: "CreditCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "CreditCards");
        }
    }
}
