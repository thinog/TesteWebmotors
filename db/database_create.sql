CREATE DATABASE teste_webmotors
GO 

CREATE TABLE teste_webmotors..tb_AnuncioWebmotors
( 
	Id INT IDENTITY NOT NULL, 
	Marca VARCHAR(45) NOT NULL, 
	Modelo VARCHAR(45) NOT NULL, 
	Versao VARCHAR(45) NOT NULL, 
	Ano INT NOT NULL, 
	Quilometragem INT NOT NULL, 
	Observacao TEXT NOT NULL
)