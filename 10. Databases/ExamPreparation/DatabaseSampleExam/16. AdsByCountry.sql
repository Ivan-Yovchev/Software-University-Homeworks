CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(MAX) NOT NULL
)
GO

ALTER TABLE Towns
ADD CountryId INT NULL
FOREIGN KEY (CountryId) REFERENCES Countries(Id)
GO

INSERT INTO Countries(Name) VALUES ('Bulgaria'), ('Germany'), ('France')
UPDATE Towns SET CountryId = (SELECT Id FROM Countries WHERE Name='Bulgaria')
INSERT INTO Towns VALUES
('Munich', (SELECT Id FROM Countries WHERE Name='Germany')),
('Frankfurt', (SELECT Id FROM Countries WHERE Name='Germany')),
('Berlin', (SELECT Id FROM Countries WHERE Name='Germany')),
('Hamburg', (SELECT Id FROM Countries WHERE Name='Germany')),
('Paris', (SELECT Id FROM Countries WHERE Name='France')),
('Lyon', (SELECT Id FROM Countries WHERE Name='France')),
('Nantes', (SELECT Id FROM Countries WHERE Name='France'))
GO


UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Paris')
WHERE DATENAME(WEEKDAY, Date) = 'Friday'
GO

UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Hamburg')
WHERE DATENAME(WEEKDAY, Date) = 'Thursday'
GO


DELETE FROM Ads
FROM Ads a
LEFT JOIN AspNetUsers u
	ON a.OwnerId = u.Id
LEFT JOIN AspNetUserRoles ur
	ON u.Id = ur.UserId
LEFT JOIN AspNetRoles r
	ON r.Id = ur.RoleId
WHERE r.Name = 'Partner'
GO

INSERT INTO Ads(Title, Text, ImageDataURL, OwnerId, CategoryId, TownId, Date, StatusId)
VALUES 
(
	'Free Book',
	'Free C# Book',
	NULL,
	(SELECT Id FROM AspNetUsers WHERE UserName = 'nakov'),
	NULL,
	NULL,
	GETDATE(),
	(SELECT Id FROM AdStatuses WHERE Status = 'Waiting Approval')
)
GO

SELECT
	t.Name as Town,
	c.Name as Country,
	COUNT(a.Id) as AdsCount
FROM Towns t
FULL JOIN Countries c
	ON t.CountryId = c.Id
FULL JOIN Ads a
	ON a.TownId = t.Id
GROUP by t.Name, c.Name
ORDER BY t.Name, c.Name