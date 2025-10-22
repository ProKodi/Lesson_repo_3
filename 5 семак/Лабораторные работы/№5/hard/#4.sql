


USE student;


/* SELECT * FROM disciplines */

/* SELECT id_discipline FROM exams */



SELECT * FROM disciplines
  WHERE NOT(id = ANY(SELECT id_discipline FROM exams))

;