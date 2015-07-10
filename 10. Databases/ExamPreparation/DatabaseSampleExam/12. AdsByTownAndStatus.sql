SELECT
	t.Name as [Town Name],
	s.Status,
	COUNT(a.id) as [Count]
FROM Ads a
JOIN Towns t
	ON a.TownId = t.Id
JOIN AdStatuses s
	ON a.StatusId = s.Id
GROUP BY t.Name, s.Status
ORDER BY t.Name, s.Status