IF OBJECT_ID('fn_TeamsJSON') IS NOT NULL
DROP FUNCTION fn_TeamsJSON
GO

CREATE FUNCTION fn_TeamsJSON()
	RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @json NVARCHAR(MAX) = '{"teams":[';

	DECLARE teamCursor CURSOR FOR
	SELECT Id, TeamName
	FROM Teams
	WHERE CountryCode = 'BG'
	ORDER BY TeamName

	OPEN teamCursor
	DECLARE @teamName NVARCHAR(MAX);
	DECLARE @id INT;

	FETCH NEXT FROM teamCursor
	INTO @id, @teamName;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @json = @json + '{"name":"' + @teamName + '","matches":[';

		DECLARE matchesCursor CURSOR FOR
		SELECT
			ht.TeamName,
			tm.HomeGoals,
			at.TeamName,
			tm.AwayGoals,
			tm.MatchDate
		FROM TeamMatches tm
		JOIN Teams ht
			ON ht.Id = tm.HomeTeamId
		JOIN Teams at
			ON at.Id = tm.AwayTeamId
		WHERE ht.Id = @id OR at.Id = @id
		ORDER BY tm.MatchDate DESC

		OPEN matchesCursor
		DECLARE @hTeam NVARCHAR(MAX);
		DECLARE @hGoals INT;
		DECLARE @aTeam NVARCHAR(MAX);
		DECLARE @aGoals INT;
		DECLARE @date DATE;

		FETCH NEXT FROM matchesCursor
		INTO @hTeam, @hGoals, @aTeam, @aGoals, @date;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json = @json + '{"' + @hTeam + '":' + CONVERT(NVARCHAR(2), @hGoals) + ','
			+ '"' + @aTeam + '":' + CONVERT(NVARCHAR(2), @aGoals) + ','
			+ '"date":' + CONVERT(NVARCHAR(MAX), @date, 103) + '}';

			FETCH NEXT FROM matchesCursor
			INTO @hTeam, @hGoals, @aTeam, @aGoals, @date;
			IF @@FETCH_STATUS = 0
			BEGIN
				SET @json = @json + ','
			END
		END

		CLOSE matchesCursor;
		DEALLOCATE matchesCursor;

		SET @json = @json + ']}'

		FETCH NEXT FROM teamCursor
		INTO @id, @teamName;
		IF @@FETCH_STATUS = 0
		BEGIN 
			SET @json = @json + ','
		END
	END

	CLOSE teamCursor;
	DEALLOCATE teamCursor;

	SET @json = @json + ']}'
	RETURN @json
END
GO

SELECT dbo.fn_TeamsJSON()