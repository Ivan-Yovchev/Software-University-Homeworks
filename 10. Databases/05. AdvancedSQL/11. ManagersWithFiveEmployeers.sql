SELECT FirstName, LastName, 5 as [Employees count]
FROM Employees m
WHERE (SELECT COUNT(*) FROM Employees e WHERE m.EmployeeID = e.ManagerID) = 5