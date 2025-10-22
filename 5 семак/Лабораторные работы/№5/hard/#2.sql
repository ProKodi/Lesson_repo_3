



USE student;


/* SELECT * FROM exams */

/* SELECT id, name FROM disciplines */

/* SELECT id_student, date, mark, discp.name FROM exams
  INNER JOIN(
    SELECT id, name FROM disciplines
  ) AS discp
  ON exams.id_discipline = discp.id

*/

USE student;


SELECT students.name, `group`, date, mark, exam_discp.name  FROM students
    INNER JOIN(
        SELECT id_student, date, mark, discp.name FROM exams
        INNER JOIN(
            SELECT id, name FROM disciplines
        ) AS discp
        ON exams.id_discipline = discp.id
        WHERE mark >= 3
    ) AS exam_discp
    ON students.id = exam_discp.id_student
    

;