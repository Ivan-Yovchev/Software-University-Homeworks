SELECT
	a.Title,
	t.Name as Town
FROM Ads a
LEFT JOIN Towns t
	ON t.Id = a.TownId
ORDER BY a.Id