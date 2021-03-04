/**********************************************
 * Script de inicialização do banco de dados  *
 * Necessário para executar a aplicação para  *
 * desenvolvimento do desafio.                *
 *                                            *
 * Sugerimos que você coloque aqui os scripts *
 * necessários para que o banco de dados      *
 * esteja pronto para executar sua aplicação! *
 **********************************************/

CREATE DATABASE TesteSeletivo;

DROP TABLE IF EXISTS Empresas;

CREATE TABLE Empresas
(
    ID int NOT NULL PRIMARY KEY,
    RAZAO_SOCIAL varchar(100),
    CNPJ varchar(18)
);

INSERT INTO Empresas
    (ID, RAZAO_SOCIAL, CNPJ)
VALUES  
    (1, 'Alterdata Tecnologia em Informática Ltda.', '36.462.778/0001-60'),
    (2, 'Padaria do Zé Ltda.', '00.000.000/0000-00')