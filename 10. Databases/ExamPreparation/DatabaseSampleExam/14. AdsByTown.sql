SELECT
	COUNT(a.Id) as AdsCount,
	ISNULL(t.Name, '(no town)') as Town
FROM Ads a
LEFT JOIN Towns t
	ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT(a.Id) = 2 OR COUNT(a.Id) = 3
ORDER BY t.Name