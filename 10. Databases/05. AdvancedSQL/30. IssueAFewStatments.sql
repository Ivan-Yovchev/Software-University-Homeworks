INSERT INTO WorkHours VALUES (GETDATE(), 'Do stuff', 4, 'do more stuff')
INSERT INTO WorkHours VALUES (GETDATE(), 'Rest', 4, 'rest some more')
UPDATE WorkHours SET TaskDate = DATEADD(MONTH, 2, GETDATE()) WHERE Id = 2
-- DELETE FROM WorkHours WHERE Id = 1