SELECT a1.Date as FirstDate, a2.Date as SecondDate
FROM Ads a1, Ads a2
WHERE a1.Date < a2.Date AND DATEDIFF(HOUR, a1.Date, a2.Date) < 12 AND a1.Date <> a2.Date
ORDER BY a1.Date, a2.Date