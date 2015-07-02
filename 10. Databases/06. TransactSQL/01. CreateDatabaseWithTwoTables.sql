USE [Transact-SQL]
GO

CREATE TABLE Persons
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN NVARCHAR(20) NOT NULL
)
GO

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PersonId INT FOREIGN KEY REFERENCES Persons(Id) NOT NULL,
	Balance MONEY NOT NULL
)
GO

INSERT INTO Persons(FirstName, LastName, SSN)
		VALUES('Ivan', 'Ivanov', '8921121223')
INSERT INTO Persons(FirstName, LastName, SSN)
		VALUES('Pesho', 'Peshev', '89245125523')
INSERT INTO Persons(FirstName, LastName, SSN)
		VALUES('Gosho', 'Georgiev', '9101192223')

INSERT INTO Accounts(PersonId, Balance)
		VALUES(1, 1200.35)
INSERT INTO Accounts(PersonId, Balance)
		VALUES(2, 35.72)
INSERT INTO Accounts(PersonId, Balance)
		VALUES(3, 5126.05)
GO

CREATE PROCEDURE usp_PersonsFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName as [Full Name] FROM Persons
END
GO

EXEC usp_PersonsFullName