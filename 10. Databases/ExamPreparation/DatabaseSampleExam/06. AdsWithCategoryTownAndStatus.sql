SELECT
	a.Title,
	c.Name as CategoryName,
	t.Name as TownName,
	s.Status
FROM Ads a
LEFT JOIN Categories c
	ON a.CategoryId = c.Id
LEFT JOIN Towns t
	ON a.TownId = t.Id
LEFT JOIN AdStatuses s
	ON a.StatusId = s.Id
ORDER BY a.Id