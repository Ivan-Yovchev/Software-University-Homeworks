INSERT INTO Users
SELECT 
  FirstName + ' ' + LastName,
  SUBSTRING(FirstName, 1, 1) + LEFT(LOWER(LastName) + 'pass', 5),
  SUBSTRING(FirstName, 1, 1) + LOWER(LastName),
  GETDATE(),
  5
FROM Employees