



USE student;


/* SELECT DISTINCT id, name FROM Specialties  */

SELECT students.name, spc_students.name  FROM students
  INNER JOIN (
    SELECT DISTINCT id, name FROM Specialties
  ) AS spc_students
  ON students.id_specialty = spc_students.id

  LIMIT 0, 1000


;