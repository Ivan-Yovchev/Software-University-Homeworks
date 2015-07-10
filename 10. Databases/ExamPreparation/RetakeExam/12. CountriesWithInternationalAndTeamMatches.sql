SELECT 
	c.CountryName as [Country Name],
	COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) as [International Matches],
	COUNT(DISTINCT tm.Id) as [Team Matches]
FROM Countries c
LEFT JOIN InternationalMatches im1
	ON im1.HomeCountryCode = c.CountryCode
LEFT JOIN InternationalMatches im2
	ON im2.AwayCountryCode = c.CountryCode
LEFT JOIN Leagues l
	ON l.CountryCode = c.CountryCode
LEFT JOIN TeamMatches tm
	ON l.Id = tm.LeagueId
GROUP BY c.CountryName
HAVING COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) > 0 OR COUNT(DISTINCT tm.Id) > 0
ORDER BY [International Matches] DESC, [Team Matches] DESC, [Country Name]