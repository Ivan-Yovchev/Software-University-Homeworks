SELECT e.FirstName + ' ' + e.LastName as [Full Name],
m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
