INSERT INTO TB_TipoDeUsuario (NomeTipoDeUsuario)
VALUES ('Adm'), ('Médico'), ('Paciente')

INSERT INTO TB_Especialidade (NomeEspecialidade)
VALUES ('Pediatra'), ('Dermatologista'), ('Oftamologista'), ('Neurologista'), ('Ortopedista')

INSERT INTO TB_Clinica (NomeFantasia, RazaoSocial, CNPJ, HorarioDeAbertura, HorarioDeFechamento)
VALUES ('HealthClinic', 'Clinica Medica Health LTDA', '12345678901234', '08:00:00', '20:00:00')

INSERT INTO TB_PlanoSaude (NomePlanoSaude)
VALUES ('Sulamérica'),('Porto Seguro'),('Unimed'),('NotreDame')

INSERT INTO TB_Prontuario (Descricao)
VALUES ('Primeira consulta')