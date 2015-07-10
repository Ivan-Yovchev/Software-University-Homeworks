SELECT
	CountryName,
	CountryCode,
	(CASE
		WHEN CurrencyCode = 'EUR' THEN 'Inside' ELSE 'Outside'
	 END) as Eurozone
FROM Countries
ORDER BY CountryName