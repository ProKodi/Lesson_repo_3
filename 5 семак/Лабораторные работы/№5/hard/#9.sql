



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



;
;