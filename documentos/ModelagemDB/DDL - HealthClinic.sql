
--Cria��o do DB
CREATE DATABASE HealthClinic_Manha
USE HealthClinic_Manha

--Cria��o das tabelas
CREATE TABLE TB_TipoDeUsuario
(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,
	NomeTipoDeUsuario VARCHAR(255) NOT NULL UNIQUE
)

CREATE TABLE TB_Especialidade
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	NomeEspecialidade VARCHAR(255) NOT NULL UNIQUE
)

CREATE TABLE TB_Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(255) NOT NULL,
	RazaoSocial VARCHAR(255) NOT NULL UNIQUE,
	CNPJ VARCHAR(255) NOT NULL UNIQUE,
	HorarioDeAbertura TIME NOT NULL,
	HorarioDeFechamento TIME NOT NULL
)

CREATE TABLE TB_PlanoSaude
(
	IdPlanoSaude INT PRIMARY KEY IDENTITY,
	NomePlanoSaude VARCHAR(255) NOT NULL
)

CREATE TABLE TB_Prontuario
(
	IdProntuario INT PRIMARY KEY IDENTITY,
	Descricao TEXT NOT NULL
)

CREATE TABLE TB_Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES TB_TipoDeUsuario(IdTipoDeUsuario) NOT NULL,
	NomeCompleto VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL UNIQUE,
	Senha VARCHAR(400) NOT NULL,
	DataNascimento DATE NOT NULL,
	Idade TINYINT NOT NULL,
	CPF VARCHAR (11) NOT NULL UNIQUE,
	Sexo BIT NOT NULL UNIQUE
)

CREATE TABLE TB_Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES TB_Clinica(IdClinica) NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES TB_Usuario(IdUsuario) NOT NULL,
	IdEspecialidade INT FOREIGN KEY REFERENCES TB_Especialidade(IdEspecialidade) NOT NULL,
	CRM VARCHAR(6) NOT NULL UNIQUE
)

CREATE TABLE TB_Adm
(
	IdAdm INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES TB_Usuario(IdUsuario) NOT NULL,
	Cargo VARCHAR(100) NOT NULL
)

CREATE TABLE TB_Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES TB_Usuario(IdUsuario)NOT NULL,
	IdPlanoSaude INT FOREIGN KEY REFERENCES TB_PlanoSaude(IdPlanoSaude)NOT NULL,
	Endereco VARCHAR(255) NOT NULL
)

CREATE TABLE TB_Feedback
(
	IdFeedback INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES TB_Paciente(IdPaciente),
	Descricao VARCHAR(500) NOT NULL
)

CREATE TABLE TB_Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdAdm INT FOREIGN KEY REFERENCES TB_Adm(IdAdm) NOT NULL,
	IdPaciente INT FOREIGN KEY REFERENCES TB_Paciente(IdPaciente) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES TB_Medico(IdMedico) NOT NULL,
	IdFeedback INT FOREIGN KEY REFERENCES TB_Feedback(IdFeedback) NOT NULL,
	DataConsulta DATE NOT NULL,
	HoraConsulta TIME NOT NULL,
	DescricaoConsulta TEXT NOT NULL
)
