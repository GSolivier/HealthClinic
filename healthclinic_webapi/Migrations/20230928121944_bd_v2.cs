using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthclinic_webapi.Migrations
{
    /// <inheritdoc />
    public partial class bd_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Prontuario_IdProntuario",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdProntuario",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "IdProntuario",
                table: "Paciente");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPaciente",
                table: "Prontuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_IdPaciente",
                table: "Prontuario",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Prontuario_Paciente_IdPaciente",
                table: "Prontuario",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prontuario_Paciente_IdPaciente",
                table: "Prontuario");

            migrationBuilder.DropIndex(
                name: "IX_Prontuario_IdPaciente",
                table: "Prontuario");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Prontuario");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProntuario",
                table: "Paciente",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdProntuario",
                table: "Paciente",
                column: "IdProntuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Prontuario_IdProntuario",
                table: "Paciente",
                column: "IdProntuario",
                principalTable: "Prontuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
