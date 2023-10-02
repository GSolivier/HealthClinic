using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthclinic_webapi.Migrations
{
    /// <inheritdoc />
    public partial class bd_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFinal = table.Column<TimeOnly>(type: "time", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoSaude",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoSaude", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    IdTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_TiposUsuario_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cargo = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrador_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: "VARCHAR(6)", nullable: false),
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medico_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidade_IdEspecialidade",
                        column: x => x.IdEspecialidade,
                        principalTable: "Especialidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medico_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPlanoSaude = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_PlanoSaude_IdPlanoSaude",
                        column: x => x.IdPlanoSaude,
                        principalTable: "PlanoSaude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Visivel = table.Column<bool>(type: "BIT", nullable: false),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prontuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prontuario_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    IdAdministrador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFeedback = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Administrador_IdAdministrador",
                        column: x => x.IdAdministrador,
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Feedback_IdFeedback",
                        column: x => x.IdFeedback,
                        principalTable: "Feedback",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_IdUsuario",
                table: "Administrador",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdAdministrador",
                table: "Consulta",
                column: "IdAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdFeedback",
                table: "Consulta",
                column: "IdFeedback");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_IdPaciente",
                table: "Feedback",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdClinica",
                table: "Medico",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdEspecialidade",
                table: "Medico",
                column: "IdEspecialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdUsuario",
                table: "Medico",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdPlanoSaude",
                table: "Paciente",
                column: "IdPlanoSaude");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdUsuario",
                table: "Paciente",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_IdPaciente",
                table: "Prontuario",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoUsuario",
                table: "Usuario",
                column: "IdTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "PlanoSaude");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TiposUsuario");
        }
    }
}
