



USE student;


/* SELECT id_student FROM exams  */

SELECT * FROM students 
    WHERE NOT(id = ANY(SELECT id_student FROM exams))


;