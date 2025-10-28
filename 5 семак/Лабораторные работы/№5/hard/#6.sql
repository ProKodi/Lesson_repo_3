



USE student;


/*
SELECT id_student FROM exams
*/
/*
SELECT * FROM students 
*/
SELECT * FROM students 
  LEFT JOIN (SELECT id_student FROM exams) AS id_st
  ON id_st.id_student = students.id
  WHERE id_st.id_student IS NULL
  LIMIT 0, 1000

;