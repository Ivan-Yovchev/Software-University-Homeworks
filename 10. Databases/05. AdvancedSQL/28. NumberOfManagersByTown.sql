SELECT 
  t.Name as Town,
  COUNT(m.EmployeeID) as [Number of managers]
FROM Employees m
JOIN Addresses a
  ON m.AddressID = a.AddressID
JOIN Towns t
  ON a.TownID = t.TownID
WHERE EXISTS (SELECT * FROM Employees e WHERE e.ManagerID = m.EmployeeID)
GROUP BY t.Name
ORDER BY t.Name