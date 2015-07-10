SELECT
	s.Status,
	COUNT(a.Id) as [Count]
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
GROUP BY s.Status