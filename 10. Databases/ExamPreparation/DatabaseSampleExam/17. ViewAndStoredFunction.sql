CREATE VIEW AllAds AS
SELECT
	a.Id,
	a.Title,
	u.UserName as Author,
	a.Date,
	t.Name as Town,
	c.Name as Category,
	s.Status
FROM Ads a
LEFT JOIN AspNetUsers u
	ON a.OwnerId = u.Id
LEFT JOIN Towns t
	ON a.TownId = t.Id
LEFT JOIN Categories c
	ON a.CategoryId = c.Id
LEFT JOIN AdStatuses s
	ON a.StatusId = s.Id
GO

IF OBJECT_ID('fn_ListUsersAds') IS NOT NULL
DROP FUNCTION fn_ListUsersAds
GO

CREATE FUNCTION fn_ListUsersAds()
RETURNS @usersAdsTable TABLE
(
	UserName NVARCHAR(MAX),
	AdDates NVARCHAR(MAX)
)
AS
BEGIN
	DECLARE UserCursor CURSOR FOR
	SELECT UserName
	FROM AspNetUsers
	ORDER BY UserName DESC

	OPEN UserCursor;
	DECLARE @username NVARCHAR(MAX);

	FETCH NEXT FROM UserCursor
	INTO @username;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @ads NVARCHAR(MAX) = NULL
		SELECT
			@ads = CASE
				WHEN @ads IS NULL THEN CONVERT(NVARCHAR(MAX), Date, 112)
				ELSE @ads + '; ' + CONVERT(NVARCHAR(MAX), Date, 112)
			END
		FROM AllAds
		WHERE Author = @username
		ORDER BY Date ASC

		INSERT INTO @usersAdsTable
		VALUES(@username, @ads)

		FETCH NEXT FROM UserCursor
		INTO @username;
	END

	CLOSE UserCursor
    DEALLOCATE UserCursor

	RETURN
END
GO

SELECT * FROM fn_ListUsersAds()