



USE student;

/* select * FROM students  */

/* SELECT * FROM disciplines   */

/*
SELECT id_student, id_discipline, mark FROM exams
  WHERE mark = (SELECT max(mark) FROM exams)

*/

/* SELECT id_student, id_discipline, MAX(mark) FROM exams  */


/*
/* select * FROM students  */

/* SELECT * FROM disciplines   */

/*
SELECT id_discipline, MAX(mark) AS max_mark FROM exams
  GROUP BY id_discipline

*/

/*
SELECT id_discipline, MAX(mark) AS max_mark FROM exams
  INNER JOIN (SELECT * FROM disciplines) AS sl_dicp
  ON sl_dicp.id = exams.id_discipline

  GROUP BY id_discipline
*/

SELECT sl_dicp.name, MAX(mark) FROM exams
  INNER JOIN (select * FROM students) AS sl_stud
  ON sl_stud.id = exams.id_student

  INNER JOIN (SELECT * FROM disciplines) AS sl_dicp
  ON sl_dicp.id = exams.id_discipline

  GROUP BY exams.id_discipline




*/

SELECT sl_dicp.name, sl_stud.name, mark FROM exams
  INNER JOIN (SELECT * FROM disciplines) AS sl_dicp
  ON sl_dicp.id = exams.id_discipline

  INNER JOIN (select * FROM students) AS sl_stud
  ON sl_stud.id = exams.id_student

  WHERE mark = (
    SELECT MAX(mark) FROM exams AS new_exam
      WHERE new_exam.id_discipline = exams.id_discipline
  )
  LIMIT 0, 1000


;
;