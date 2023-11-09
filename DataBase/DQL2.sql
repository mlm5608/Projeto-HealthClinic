--EXIBIR:
--ID CONSULTA,DATA DA CONSULTA, HORARIO DA CONSULTA, NOME CLINICA, NOME DO PACIENTE, NOME DO MEDICO, ESPECIALIDADE DO MEDICO, CRM, COMENTARIO.

USE Health_Clinic_Miguel

SELECT 
	Consulta.IdConsulta,
	Consulta.[Data],
	Consulta.Horario,
	Clinica.NomeFantasia AS Clínica,
	P.Nome AS Paciente,
	M.Nome AS Médico,
	Especialidade.Nome AS Especialidade,
	Medico.CRM,
	Comentario.Descricao AS Comentário
FROM
	Consulta
INNER JOIN Comentario ON Comentario.IdConsulta = Consulta.IdConsulta
INNER JOIN Medico ON Consulta.IdMedico = Medico.IdMedico
INNER JOIN Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
INNER JOIN Clinica ON Consulta.IdClinica = Clinica.IdClinica
INNER JOIN Usuario P ON Medico.IdUsuario = P.IdUsuario
INNER JOIN Usuario M ON Paciente.IdUsuario = M.IdUsuario
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade

--==========================================================================================================

--Criar função para retornar os médicos de uma determinada especialidade

SELECT 
	Usuario.Nome AS Médico,
	Especialidade.Nome AS Especialidade
FROM 
	Medico
RIGHT JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
LEFT JOIN Usuario ON Medico.IdUsuario = Usuario.IdUsuario
WHERE 
	Especialidade.IdEspecialidade = 1

--==========================================================================================================

--DESAFIO
go
create procedure BuscarIdade
@BuscaIdade varchar(200)
as
select Usuario.DataDeNascimento from Usuario
select Usuario.Nome from Usuario
where @BuscaIdade = Usuario.Nome

execute BuscarIdade 'Pedro';

drop procedure BuscarIdade
