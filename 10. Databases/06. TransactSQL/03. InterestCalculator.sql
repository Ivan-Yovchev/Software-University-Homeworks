USE [Transact-SQL]
GO

CREATE FUNCTION ufn_CalculateInterest(@money MONEY, @interest FLOAT, @months FLOAT)
RETURNS MONEY
AS
BEGIN
  RETURN @money + (@money * (@interest / 100)) * (@months / 12)
END
GO

SELECT dbo.ufn_CalculateInterest(500, 20, 5) as [MONEY]
