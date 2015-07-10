SELECT
	t.TeamName,
	ISNULL(SUM(tm1.HomeGoals), 0) + ISNULL(SUM(tm2.AwayGoals), 0) as [Total Goals]
FROM Teams t
LEFT JOIN TeamMatches tm1
	ON tm1.HomeTeamId = t.Id
LEFT JOIN TeamMatches tm2
	ON tm2.AwayTeamId = t.id
GROUP BY t.TeamName
ORDER BY [Total Goals] DESC, t.TeamName
