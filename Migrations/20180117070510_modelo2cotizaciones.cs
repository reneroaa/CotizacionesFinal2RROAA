using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cotizaciones.Migrations
{
    public partial class modelo2cotizaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotizacion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonaRut = table.Column<string>(nullable: true),
                    descripcionCotizacion = table.Column<string>(nullable: true),
                    estadoCotizacion = table.Column<string>(nullable: true),
                    fechaCotizacion = table.Column<DateTime>(nullable: false),
                    fechaValidez = table.Column<DateTime>(nullable: false),
                    nombreCliente = table.Column<string>(nullable: true),
                    valorCotizacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cotizacion_Personas_PersonaRut",
                        column: x => x.PersonaRut,
                        principalTable: "Personas",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_PersonaRut",
                table: "Cotizacion",
                column: "PersonaRut");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotizacion");
        }
    }
}
