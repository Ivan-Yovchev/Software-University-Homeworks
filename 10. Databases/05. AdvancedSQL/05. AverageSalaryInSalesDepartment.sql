SELECT AVG(e.Salary) as [Average Salary In Sales Department]
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'