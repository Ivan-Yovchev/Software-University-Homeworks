SELECT COUNT(EmployeeID) as [Employees without manager] FROM Employees
WHERE ManagerID IS NULL