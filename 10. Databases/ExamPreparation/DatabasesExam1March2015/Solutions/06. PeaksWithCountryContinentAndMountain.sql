SELECT
	p.PeakName,
	m.MountainRange as Mountain,
	c.CountryName,
	con.ContinentName
FROM Countries c
JOIN MountainsCountries mc
	ON c.CountryCode = mc.CountryCode
JOIN Mountains m
	ON mc.MountainId = m.Id
JOIN Peaks p
	ON p.MountainId = m.Id
JOIN Continents con
	ON c.ContinentCode = con.ContinentCode
ORDER BY p.PeakName, c.CountryName