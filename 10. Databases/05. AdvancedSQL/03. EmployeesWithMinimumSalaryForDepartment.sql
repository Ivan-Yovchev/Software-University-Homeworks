SELECT 
  FirstName + ' ' + LastName as [Full Name],
  Salary,
  d.Name as Department
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees
   WHERE DepartmentID = e.DepartmentID)