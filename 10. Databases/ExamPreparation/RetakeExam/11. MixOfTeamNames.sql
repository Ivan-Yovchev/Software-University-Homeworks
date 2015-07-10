SELECT
	LOWER(SUBSTRING(t1.TeamName, 1, LEN(t1.TeamName) - 1) + REVERSE(t2.TeamName)) as Mix
FROM Teams t1, Teams t2
WHERE RIGHT(t1.TeamName, 1) = RIGHT(t2.TeamName, 1)
ORDER BY Mix