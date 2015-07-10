ALTER TABLE Leagues
ADD IsSeasonal BIT NOT NULL DEFAULT 0
GO

INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES 
(
	(SELECT Id FROM Teams WHERE TeamName = 'Empoli'),
	(SELECT Id FROM Teams WHERE TeamName = 'Parma'),
	2,
	2,
	'19-Apr-2015 16:00',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A')
)
GO

INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
VALUES 
(
	(SELECT Id FROM Teams WHERE TeamName = 'Internazionale'),
	(SELECT Id FROM Teams WHERE TeamName = 'AC Milan'),
	0,
	0,
	'19-Apr-2015 21:45',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A')
)
GO

UPDATE Leagues
SET IsSeasonal = 1
WHERE Id IN 
(
	SELECT l.Id
	FROM Leagues l
	JOIN TeamMatches tm 
		ON tm.LeagueId = l.Id
	GROUP BY l.Id
	HAVING COUNT(tm.Id) > 0
)
GO

SELECT
	ht.TeamName as [Home Team],
	tm.HomeGoals as [Home Goals],
	at.TeamName as [Away Team],
	tm.AwayGoals as [Away Goals],
	l.LeagueName as [League Name]
FROM TeamMatches tm
JOIN Leagues l
	ON tm.LeagueId = l.Id
JOIN Teams ht
	ON ht.Id = tm.HomeTeamId
JOIN Teams at
	ON at.Id = tm.AwayTeamId
WHERE tm.MatchDate > '10-Apr-2015' AND l.IsSeasonal = 1
ORDER BY l.LeagueName, tm.HomeGoals DESC, tm.AwayGoals DESC