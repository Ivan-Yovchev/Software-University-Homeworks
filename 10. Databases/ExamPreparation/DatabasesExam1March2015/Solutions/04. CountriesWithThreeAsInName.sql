SELECT
	CountryName as [Country Name],
	IsoCode as [ISO Code]
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode