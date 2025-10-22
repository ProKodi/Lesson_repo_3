



USE student;

/* SELECT * FROM specialties */

/* SELECT id_specialty FROM students   */

SELECT * FROM specialties
  WHERE NOT (id = any(SELECT id_specialty FROM students))
    

;