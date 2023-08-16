

SELECT
	TB_Consulta.IdConsulta,
	TB_Consulta.DataConsulta,
	TB_Consulta.HoraConsulta,
	TB_Clinica.NomeFantasia,
	TB_Usuario.NomeCompleto,
	TB_Usuario.NomeCompleto,
	TB_Medico.CRM,
	TB_Prontuario.Descricao,
	TB_Feedback.Descricao
FROM
	TB_Consulta
	INNER JOIN
	TB_Medico ON TB_Consulta.IdMedico = TB_Medico.IdMedico
	INNER JOIN
	TB_Clinica ON TB_Medico.IdClinica = TB_Clinica.IdClinica
	INNER JOIN
	TB_Paciente ON TB_Paciente.IdPaciente = TB_Consulta.IdPaciente
	INNER JOIN
	TB_Usuario ON TB_Usuario.IdUsuario = TB_Medico.IdUsuario OR TB_Usuario.IdUsuario = TB_Paciente.IdUsuario
	INNER JOIN
	TB_Prontuario ON TB_Prontuario.IdProntuario = TB_Paciente.IdProntuario
	INNER JOIN
	TB_Feedback ON TB_Feedback.IdPaciente = TB_Paciente.IdPaciente


	SELECT NomeCompleto,TB_Medico.IdMedico,IdConsulta FROM TB_Usuario
	INNER JOIN TB_Paciente
	ON TB_Paciente.IdUsuario = TB_Usuario.IdUsuario
	INNER JOIN TB_Consulta
	ON TB_Consulta.IdPaciente = TB_Paciente.IdPaciente
	INNER JOIN TB_Medico
	ON  TB_Consulta.IdMedico =  TB_Medico.IdMedico
	WHERE TB_Paciente.IdUsuario = TB_Usuario.IdUsuario



