SELECT
	Title,
	Date,
	CASE
		WHEN ImageDataURL IS NULL THEN 'no' ELSE 'yes'
	END as [Has Image]
FROM Ads
ORDER BY Id