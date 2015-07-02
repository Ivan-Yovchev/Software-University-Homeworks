CREATE TABLE WorkHours
(
        Id INT PRIMARY KEY IDENTITY NOT NULL,
        TaskDate datetime NULL,
        Task nvarchar(125) NOT NULL,
        Hours SMALLINT NOT NULL,
        Comments VARCHAR(MAX) NULL
)
GO