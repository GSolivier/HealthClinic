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
                name: "FK_Consulta_Feedback_IdFeedback",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdFeedback",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdFeedback",
                table: "Consulta");

            migrationBuilder.AddColumn<Guid>(
                name: "IdConsulta",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_IdConsulta",
                table: "Feedback",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Consulta_IdConsulta",
                table: "Feedback",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Consulta_IdConsulta",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_IdConsulta",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "IdConsulta",
                table: "Feedback");

            migrationBuilder.AddColumn<Guid>(
                name: "IdFeedback",
                table: "Consulta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdFeedback",
                table: "Consulta",
                column: "IdFeedback");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Feedback_IdFeedback",
                table: "Consulta",
                column: "IdFeedback",
                principalTable: "Feedback",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
