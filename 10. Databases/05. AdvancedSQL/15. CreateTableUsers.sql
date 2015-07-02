CREATE TABLE Users
(
        Id INT PRIMARY KEY IDENTITY NOT NULL,
        Username VARCHAR(30) NOT NULL UNIQUE,
        Password VARCHAR(20) NOT NULL,
        FullName nvarchar(60) NULL,
        LastLoggedIn datetime NOT NULL,
        CONSTRAINT chk_Password CHECK (LEN(Password) > 5)
)
GO