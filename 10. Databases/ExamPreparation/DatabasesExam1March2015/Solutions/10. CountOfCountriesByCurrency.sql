SELECT
	cur.CurrencyCode,
	MIN(cur.Description) as Currency,
	COUNT(c.CountryCode) as NumberOfCountries
FROM Currencies cur
LEFT JOIN Countries c
	ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode
ORDER BY NumberOfCountries DESC, Currency ASC