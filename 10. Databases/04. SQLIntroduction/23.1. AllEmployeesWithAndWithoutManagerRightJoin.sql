SELECT e.FirstName + ' ' + e.LastName as [Full Name],
m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees m
RIGHT OUTER JOIN Employees e
	ON m.EmployeeID = e.ManagerID