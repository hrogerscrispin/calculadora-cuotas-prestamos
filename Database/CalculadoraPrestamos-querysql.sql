Create Database CalculadoraPrestamos;

use CalculadoraPrestamos;


CREATE TABLE Tasa(
	Id int not null Identity(1,1) PRIMARY KEY,
	Edad int not null Unique,
	TasaFija decimal(6,2) not null
);


CREATE TABLE RegistroConsultas(
	IdConsulta int not null identity(1,1) PRIMARY KEY,
	FechaConsulta DATETIME not null default getDate(),
	Edad int not null,
	Monto decimal(18,2) not null,
	Meses int not null, 
	ValorCuota decimal(18,2) not null,
	IP_de_Consulta nvarchar(50) not null
)
go;



--PROCEDIMIENTOS

--obtener tasa por edad
CREATE proc sp_ObtenerTasaPorEdad
	@Edad int
AS
set nocount on;

	Select TasaFija
	from Tasa
	where Edad = @Edad
GO;

-- registrar logs
CREATE proc sp_InsertarRegistroConsulta(
	@Edad int,
	@Monto decimal(18,2),
	@Meses int,
	@ValorCuota decimal(18,2),
	@IP nvarchar(50)
)
AS
set nocount on;
	INSERT INTO RegistroConsultas(Edad,Monto,Meses,ValorCuota,IP_de_Consulta) values (@Edad,@Monto,@Meses,@ValorCuota,@IP)
GO;
