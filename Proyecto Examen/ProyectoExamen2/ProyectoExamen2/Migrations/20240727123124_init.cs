using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoExamen2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    DisbursementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstPaymentData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_clients_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "clients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Amortization",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<int>(type: "int", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SaldoDePrincipal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PagoNiveladoSinSVSD = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PagoNiveladoConSVSD = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroCuota = table.Column<int>(type: "int", nullable: false),
                    Principal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amortization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amortization_Loan_LoanId",
                        column: x => x.LoanId,
                        principalSchema: "dbo",
                        principalTable: "Loan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amortization_LoanId",
                schema: "dbo",
                table: "Amortization",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_ClienteId",
                schema: "dbo",
                table: "Loan",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amortization",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Loan",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "dbo");
        }
    }
}
