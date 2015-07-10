SELECT
	t.TeamName as [Team Name],
	l.LeagueName as [League],
	(ISNULL(c.CountryName, 'International')) as [League Country]
FROM Teams t
LEFT JOIN Leagues_Teams lt
	ON lt.TeamId = t.Id
LEFT JOIN Leagues l
	ON lt.LeagueId = l.Id
LEFT JOIN Countries c
	ON l.CountryCode = c.CountryCode
ORDER BY [Team Name], League