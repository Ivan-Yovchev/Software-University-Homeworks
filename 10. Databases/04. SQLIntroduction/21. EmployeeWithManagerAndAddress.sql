SELECT e.FirstName + ' ' + e.LastName as [Employee], m.FirstName + ' ' + m.LastName as [Manager], a.AddressText as [Address]
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID
JOIN Addresses a
	ON e.AddressID = a.AddressID