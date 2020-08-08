CREATE DATABASE TarefaDB;
GO

USE TarefaDB;
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tarefa]') AND type in (N'U'))
DROP TABLE [dbo].[Tarefa]
GO

CREATE TABLE Tarefa
(
Id NUMERIC(4) PRIMARY KEY UNIQUE ,
Nome VARCHAR(10) NOT NULL,
Concluida BIT NOT NULL DEFAULT 0,
) 

CREATE VIEW TarefasConcluidas
AS
SELECT t.Nome AS 'Tarefa', U.Nome AS 'Usuario', Concluida FROM Tarefa AS T LEFT JOIN Usuario AS U ON U.Id = Tarefa.UsuarioId WHERE Concluida=1;


INSERT INTO Tarefa (Codigo, Nome, Concluida) VALUES (001, 'E001', 1);
INSERT INTO Tarefa (Codigo, Nome, Concluida) VALUES (002, 'E002', 1);
INSERT INTO Tarefa (Codigo, Nome, Concluida) VALUES (003, 'E003', 1);
INSERT INTO Tarefa (Codigo, Nome, Concluida) VALUES (004, 'E004', 1);
INSERT INTO Tarefa (Codigo, Nome, Concluida) VALUES (005, 'E005', 1);
INSERT INTO Tarefa (Codigo, Nome) VALUES (006, 'E006');
INSERT INTO Tarefa (Codigo, Nome) VALUES (007, 'E007');
INSERT INTO Tarefa (Codigo, Nome) VALUES (008, 'E008');
INSERT INTO Tarefa (Codigo, Nome) VALUES (009, 'E009');
INSERT INTO Tarefa (Codigo, Nome) VALUES (010, 'E010');
INSERT INTO Tarefa (Codigo, Nome) VALUES (011, 'E011');
INSERT INTO Tarefa (Codigo, Nome) VALUES (022, 'E012');
INSERT INTO Tarefa (Codigo, Nome) VALUES (013, 'E013');
INSERT INTO Tarefa (Codigo, Nome) VALUES (014, 'E014');
INSERT INTO Tarefa (Codigo, Nome) VALUES (015, 'E015');
INSERT INTO Tarefa (Codigo, Nome) VALUES (016, 'E016');
INSERT INTO Tarefa (Codigo, Nome) VALUES (017, 'E017');
INSERT INTO Tarefa (Codigo, Nome) VALUES (018, 'E018');
INSERT INTO Tarefa (Codigo, Nome) VALUES (019, 'E019');
INSERT INTO Tarefa (Codigo, Nome) VALUES (020, 'E020');