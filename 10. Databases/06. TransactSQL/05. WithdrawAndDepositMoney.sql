USE [Transact-SQL]
GO

CREATE PROCEDURE usp_WithdrawMoney(@accountId INT, @money MONEY)
AS
BEGIN
  DECLARE @accountBalance MONEY
  SELECT @accountBalance = Balance
  FROM Accounts
  WHERE Id = @accountId
  IF(@accountBalance - @money <= 0)
    BEGIN
	  DECLARE @error NVARCHAR(max) = 'Not enough money in account. Balance: ' + CONVERT(NVARCHAR(50), @accountBalance)
      RAISERROR (@error, -1, -1, 'usp_WithDrawMoney');
    END
  ELSE IF(@money <= 0)
  BEGIN
    RAISERROR ('Money withdrawn must be non-negative, more than 0', -1, -1, 'usp_WithdrawMoney');
  END
  ELSE
    BEGIN
	  UPDATE Accounts
	  SET Balance = @accountBalance - @money
	  WHERE Id = @accountId
      SELECT
	    p.FirstName,
		p.LastName,
		a.Balance
      FROM Accounts a JOIN Persons p
	    ON a.PersonId = p.Id
      WHERE a.Id = @accountId
  END
END
GO

EXEC usp_WithdrawMoney 2, 0.1
GO

CREATE PROCEDURE usp_DepositMoney(@accountId INT, @money MONEY)
AS
BEGIN
  DECLARE @accountBalance MONEY
  SELECT @accountBalance = Balance
  FROM Accounts
  WHERE Id = @accountId
  IF(@money <= 0)
    BEGIN
      RAISERROR ('Money deposited must be non-negative, more than 0', -1, -1, 'usp_DepositMoney');
    END
  ELSE
    BEGIN
	  UPDATE Accounts
	  SET Balance = @accountBalance + @money
	  WHERE Id = @accountId
      SELECT
	    p.FirstName,
		p.LastName,
		a.Balance
      FROM Accounts a JOIN Persons p
	    ON a.PersonId = p.Id
      WHERE a.Id = @accountId
  END
END
GO

EXEC usp_DepositMoney 2, 20.52