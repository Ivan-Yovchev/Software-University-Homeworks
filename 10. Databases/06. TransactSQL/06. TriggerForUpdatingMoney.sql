USE [Transact-SQL]
GO

CREATE TABLE Logs
(
        Id INT PRIMARY KEY IDENTITY NOT NULL,
		AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
		OldSum MONEY NOT NULL,
		NewSum MONEY NOT NULL
)
GO

DROP TRIGGER money_change
GO

CREATE TRIGGER money_change
ON Accounts
AFTER UPDATE
AS
BEGIN
  INSERT INTO Logs(AccountId, OldSum, NewSum)
  SELECT d.Id, d.Balance, i.Balance
  FROM deleted d, inserted i
END
GO

EXEC usp_DepositMoney 2, 20.52