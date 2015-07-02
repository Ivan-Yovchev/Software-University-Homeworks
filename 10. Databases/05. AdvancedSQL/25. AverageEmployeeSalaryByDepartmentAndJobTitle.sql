SELECT 
  d.Name as Department,
  e.JobTitle as [Job Title],
  AVG(Salary) as [Average Salary]
FROM Employees e JOIN Departments d
  ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY e.JobTitle