SELECT 
	t.TeamName as Team,
	COUNT(t.Id) as [Matches Count]
FROM TeamMatches tm
LEFT JOIN Teams t
	ON tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id
GROUP BY t.TeamName
HAVING COUNT(t.Id) > 1
ORDER BY Team
