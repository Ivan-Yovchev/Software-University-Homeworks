SELECT e.FirstName, e.LastName, a.AddressText as [Address]
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID