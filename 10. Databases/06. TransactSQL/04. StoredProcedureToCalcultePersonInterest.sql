USE [Transact-SQL]
GO

CREATE PROCEDURE usp_PersonsInterestCalculator(@personId INT, @interest FLOAT)
AS
BEGIN
  SELECT
    e.FirstName,
	e.LastName,
	a.Balance,
	(SELECT dbo.ufn_CalculateInterest(a.Balance, @interest, 1)) as [Interest]
  FROM Persons e JOIN Accounts a
    ON e.Id = a.PersonId
  WHERE e.Id = @personId
END
GO

EXEC usp_PersonsInterestCalculator 2, 1.5