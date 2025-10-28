



USE student;

/* select * FROM students  */

/* SELECT * FROM disciplines   */

/*
SELECT id_student, id_discipline, mark FROM exams
  WHERE mark = (SELECT max(mark) FROM exams)

*/

/* SELECT id_student, id_discipline, MAX(mark) FROM exams  */


SELECT students.name, mark, disp.name FROM students
  INNER JOIN (
  SELECT id_student, id_discipline, mark FROM exams
    WHERE mark = (SELECT max(mark) FROM exams)
  ) AS max_mark
  ON students.id = max_mark.id_student
  
  INNER JOIN (
    SELECT id, name FROM disciplines
  ) AS disp
  ON max_mark.id_discipline = disp.id


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




;
;