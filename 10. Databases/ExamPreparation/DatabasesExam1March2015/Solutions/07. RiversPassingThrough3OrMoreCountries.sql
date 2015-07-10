SELECT
	r.RiverName as River,
	COUNT(c.CountryName) as [Countries Count]
FROM Rivers r
JOIN CountriesRivers cr
	ON cr.RiverId =  r.Id
JOIN Countries c
	ON cr.CountryCode = c.CountryCode
GROUP BY r.RiverName
HAVING COUNT(c.CountryName) >= 3
ORDER BY r.RiverName