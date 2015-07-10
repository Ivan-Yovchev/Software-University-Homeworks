SELECT
	l.LeagueName as [League Name],
	COUNT(DISTINCT lt.TeamId) as [Teams],
	COUNT(DISTINCT tm.Id) as [Matches],
	AVG(ISNULL(tm.HomeGoals, 0) + ISNULL(tm.AwayGoals, 0)) as [Average Goals]
FROM Leagues l
LEFT JOIN Leagues_Teams lt 
	ON l.Id = lt.LeagueId
LEFT JOIN TeamMatches tm
	ON tm.LeagueId = l.Id
GROUP BY l.LeagueName
ORDER BY Teams DESC, Matches DESC