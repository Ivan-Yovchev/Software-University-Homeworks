CREATE VIEW [Users Logged Today] AS
SELECT *
FROM Users
WHERE 
  DAY(LastLoggedIn) = DAY(GETDATE()) 
  AND MONTH(LastLoggedIn) = MONTH(GETDATE()) 
  AND YEAR(LastLoggedIn) = YEAR(GETDATE())