CREATE DATABASE JennyPirir_GA1;
USE JennyPirir_GA1;

CREATE TABLE TablaLogin 
(
    NombreDeUsuario varchar(35) NOT NULL PRIMARY KEY,
	Contraseña varchar(35) NOT NULL,
	RolDeUsuario varchar(20) NOT NULL  
);

INSERT INTO TablaLogin VALUES ('Jenny', 'abc123', 'Usuario');
INSERT INTO TablaLogin VALUES ('Allison', 'bcd234', 'Secretaria');
INSERT INTO TablaLogin VALUES ('Cristopher', 'cde345', 'Administrador');

SELECT *FROM TablaLogin;

CREATE TABLE TablaRegistros
(
    ID int identity NOT NULL PRIMARY KEY,
	Nombre varchar(35) NOT NULL,
	Correo varchar(70) NOT NULL,
	País varchar(25) NOT NULL,
	Ocupación varchar(45) NOT NULL
);


INSERT INTO TablaRegistros VALUES ('Jennifer Pirir', 'jenniferpirir@email.com', 'Guatemala', 'Estudiante');
INSERT INTO TablaRegistros VALUES ('Allison Juarez', 'allisonjuarez@email.com', 'Guatemala', 'Estudiante');

SELECT *FROM TablaLogin;
SELECT *FROM TablaRegistros;
