
/* 1 запрос*/

SELECT * FROM resrarunt.restatunts
  INNER JOIN resrarunt.timetable ON resrarunt.restatunts.id_timetable = resrarunt.timetable.id;