



USE student;


/* SELECT * FROM disciplines */

/* SELECT * FROM exams */


SELECT discp.name, IFNULL(COUNT(*), 0)  FROM exams 
  LEFT JOIN(
    SELECT id, name FROM disciplines
  )AS discp
  ON exams.id_discipline = discp.id

  GROUP BY discp.name
  
  LIMIT 0, 1000

SELECT disciplines.name, IFNULL(COUNT(*), 0)  FROM exams 
  LEFT JOIN disciplines
  ON exams.id_discipline = disciplines.id

  GROUP BY disciplines.name
  
  LIMIT 0, 1000

;