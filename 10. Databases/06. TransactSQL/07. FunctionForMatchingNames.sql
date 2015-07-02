USE SoftUni
GO

CREATE FUNCTION ufn_CheckIFWordExistsInString(@word nvarchar(MAX),  @string nvarchar(MAX)) 
RETURNS bit
AS
BEGIN
DECLARE @wordLen int = LEN(@word)
DECLARE @index int = 1
DECLARE @currentChar char(1)
	WHILE  (@index <= @wordLen)
		BEGIN
		SET @currentChar = SUBSTRING(@word, @index, 1)
		IF (CHARINDEX(@currentChar, @string) > 0)
			BEGIN
				SET @index = @index + 1
			END 
		ELSE 
			BEGIN
				RETURN 0
			BREAK
		END
	END
	RETURN 1
END
GO

CREATE FUNCTION ufn_EmployeesAndTownsComprisedOfGivenSetOfLetters(@string nvarchar(MAX))
RETURNS @tbl_MatchingWords TABLE (
	MatchingName nvarchar(100) NULL)
AS
BEGIN
INSERT INTO @tbl_MatchingWords
SELECT FirstName
 FROM Employees 
 WHERE dbo.ufn_CheckIFWordExistsInString(FirstName, @string) = 1
 INSERT INTO @tbl_MatchingWords
SELECT MiddleName
 FROM Employees 
  WHERE dbo.ufn_CheckIFWordExistsInString(MiddleName, @string) = 1
  INSERT INTO @tbl_MatchingWords
SELECT LastName
 FROM Employees
   WHERE dbo.ufn_CheckIFWordExistsInString(LastName, @string) = 1
  INSERT INTO @tbl_MatchingWords
SELECT Name
 FROM Towns
   WHERE dbo.ufn_CheckIFWordExistsInString(Name, @string) = 1
  RETURN
END
GO

SELECT *
 FROM ufn_EmployeesAndTownsComprisedOfGivenSetOfLetters('oistmiahf' )
GO