USE [FundamentosCSharp]
GO

create table cerveza (
id int not null primary key identity,
nombre varchar(100) not null,
marca varchar(100) not null,
alcohol int not null,
cantidad int not null
)

INSERT INTO [dbo].[cerveza]
           ([nombre]
           ,[marca]
           ,[alcohol]
           ,[cantidad])
     VALUES
           ( 'Cerveza de trigo'
           ,'Pilsen'
           ,20
           ,5),
		   ( 'Cerveza de Cebada'
           ,'Cristal'
           ,15
           ,10),
		   ( 'Cerveza de Malta'
           ,'Cusqueña'
           ,16
           ,20)
GO

SELECT * FRom dbo.cerveza;
SELECT * FROM cerveza_clon;

insert into cerveza(nombre, marca, alcohol, cantidad) select nombre, marca, alcohol, cantidad from cerveza_clon;

update dbo.cerveza set dbo.cerveza.id=4 where alcohol=6

drop table cerveza;


