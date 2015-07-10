SELECT tm1.MatchDate AS [First Date], tm2.MatchDate AS [Second Date]
FROM TeamMatches tm1, TeamMatches tm2
WHERE
  tm2.MatchDate > tm1.MatchDate AND
  DATEDIFF(day, tm1.MatchDate, tm2.MatchDate) < 1
ORDER BY tm1.MatchDate DESC, tm2.MatchDate DESC