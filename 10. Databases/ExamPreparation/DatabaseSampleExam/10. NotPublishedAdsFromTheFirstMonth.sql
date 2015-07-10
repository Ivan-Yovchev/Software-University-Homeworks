SELECT 
	a.Id,
	a.Title,
	a.Date,
	s.Status
FROM Ads a
JOIN AdStatuses s
	ON a.StatusId = s.Id
WHERE 
	s.Status <> 'Published' 
	AND ((SELECT MONTH(MIN(Date)) FROM Ads) = MONTH(a.Date))
	AND ((SELECT YEAR(MIN(Date)) FROM Ads) = YEAR(a.Date))
ORDER BY a.Id