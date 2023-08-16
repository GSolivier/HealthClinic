INSERT INTO TB_TipoDeUsuario (NomeTipoDeUsuario)
VALUES ('Adm'), ('Médico'), ('Paciente')

INSERT INTO TB_Especialidade (NomeEspecialidade)
VALUES ('Pediatra'), ('Dermatologista'), ('Oftamologista'), ('Neurologista'), ('Ortopedista')

INSERT INTO TB_Clinica (NomeFantasia, RazaoSocial, CNPJ, HorarioDeAbertura, HorarioDeFechamento)
VALUES ('HealthClinic', 'Clinica Medica Health LTDA', '12345678901234', '08:00:00', '20:00:00')

INSERT INTO TB_PlanoSaude (NomePlanoSaude)
VALUES ('Sulamérica'),('Porto Seguro'),('Unimed'),('NotreDame')

INSERT INTO TB_Prontuario (Descricao)
VALUES ('Primeira consulta do paciente.')

INSERT INTO TB_Usuario (IdTipoDeUsuario, NomeCompleto, Email, Senha, DataNascimento, CPF, Sexo)
VALUES (1, 'Guilherme Sousa Oliveira', 'guilherme@email.com', 'guilherme123', '2002-04-26', '12345678907', 0),
		(2, 'Ana Beatriz Soares', 'ana@email.com', 'ana123', '1998-06-11',  '7654321098', 1),
		(3, 'Eder Roberto Lopes', 'eder@email.com', 'eder123', '2002-04-26', '8989878765', 0)

INSERT INTO TB_Medico (IdClinica, IdUsuario,IdEspecialidade, CRM)
VALUES(1, 2, 3, '1234SP')

INSERT INTO TB_Adm (IdUsuario, Cargo)
VALUES(1, 'Secretário')

INSERT INTO TB_Paciente (IdUsuario, IdPlanoSaude, IdProntuario, Endereco)
VALUES (3, 1, 1, 'Rua cara e coroa, 193')

INSERT INTO TB_Feedback (IdPaciente, Descricao)
VALUES(1, 'Muito boa a consulta!')

INSERT INTO TB_Consulta(IdAdm, IdPaciente, IdMedico, IdFeedback, DataConsulta, HoraConsulta, DescricaoConsulta)
VALUES(1, 1, 1, 1, '2023-08-15', '09:30:00', 'Paciente com muitas dores de cabeça')