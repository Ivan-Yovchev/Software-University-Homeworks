SELECT
	TeamName as [Team Name],
	CountryCode as [Country Code]
FROM Teams
WHERE TeamName LIKE '%[0-9]%'
ORDER BY CountryCode