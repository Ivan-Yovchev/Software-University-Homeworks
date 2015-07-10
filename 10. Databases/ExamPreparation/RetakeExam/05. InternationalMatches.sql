SELECT
	hc.CountryName as [Home Team],
	ac.CountryName as [Away Team],
	im.MatchDate as [Match Date]
FROM InternationalMatches im
JOIN Countries hc
	ON hc.CountryCode = im.HomeCountryCode
JOIN Countries ac
	ON ac.CountryCode = im.AwayCountryCode
ORDER BY [Match Date] DESC