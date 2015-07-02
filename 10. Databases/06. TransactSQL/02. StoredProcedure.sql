USE [Transact-SQL]
GO

CREATE PROCEDURE usp_PeopleWithGreaterBalance(@balance MONEY)
AS
BEGIN
  SELECT p.FirstName, p.LastName, a.Balance
  FROM Persons p JOIN Accounts a
    ON p.Id = a.PersonId
  WHERE a.Balance > @balance
END
GO

EXEC usp_PeopleWithGreaterBalance 5000