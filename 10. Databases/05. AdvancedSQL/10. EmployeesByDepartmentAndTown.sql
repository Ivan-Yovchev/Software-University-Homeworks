SELECT t.Name as Town, d.Name as Department, COUNT(e.EmployeeID) as [Employees count]
FROM Employees e 
JOIN Addresses a
  ON a.AddressID = e.AddressID
JOIN Towns t
  ON t.TownID = a.TownID
JOIN Departments d
  ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, t.Name
ORDER BY t.Name