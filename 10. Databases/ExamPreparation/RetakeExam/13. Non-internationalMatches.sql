IF OBJECT_ID('FriendlyMatches') IS NOT NULL
	DROP TABLE FriendlyMatches
CREATE TABLE FriendlyMatches
(
        Id INT PRIMARY KEY IDENTITY NOT NULL,
		HomeTeamId INT FOREIGN KEY (HomeTeamId) REFERENCES Teams(Id) NOT NULL,
		AwayTeamId INT FOREIGN KEY (AwayTeamId) REFERENCES Teams(Id) NOT NULL,
		MatchDate DATETIME NULL
)
GO

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO

SELECT
	ht.TeamName as [Home Team],
	at.TeamName as [Away Team],
	fm.MatchDate as [Match Date]
FROM FriendlyMatches fm
JOIN Teams ht
	ON fm.HomeTeamId = ht.Id
JOIN Teams at
	ON fm.AwayTeamId = at.Id
UNION
SELECT
	ht.TeamName as [Home Team],
	at.TeamName as [Away Team],
	tm.MatchDate as [Match Date]
FROM TeamMatches tm
JOIN Teams ht
	ON tm.HomeTeamId = ht.Id
JOIN Teams at
	ON tm.AwayTeamId = at.Id
ORDER BY [Match Date] DESC
GO