
/* 1 запрос */

SELECT * FROM resrarunt.restatunts
  INNER JOIN resrarunt.timetable ON resrarunt.restatunts.id_timetable = resrarunt.timetable.id;


/* 2 запрос */

SELECT * FROM resrarunt.dish
  WHERE resrarunt.dish.id_restorant = 3
  
;
   
/* 3 запрос */
SELECT * FROM resrarunt.order
  WHERE resrarunt.order.id_client = (
    SELECT id FROM resrarunt.client
      WHERE resrarunt.client.email = "Почта 1"
  )

;

/* 4 запрос */
SELECT * FROM  (
  SELECT COUNT(*), id_dish FROM resrarunt.order_dish
    group by id_dish
    order by COUNT(*) DESC
) AS result_groupe
  INNER JOIN resrarunt.dish ON resrarunt.dish.id = result_groupe.id_dish


/* 5 запрос */
SET @my_date = '2025-09-29'; /*CURDATE() - текущая дата*/

SELECT SUM(cost) FROM resrarunt.dish
  INNER JOIN 
  (
    SELECT id_dish FROM resrarunt.order_dish 
    WHERE resrarunt.order_dish.id_order IN (
      SELECT id FROM resrarunt.order 
        WHERE (resrarunt.order.id_restatuant = 2) AND (DATEDIFF(@my_date, resrarunt.order.date) < 7)
    )
  ) AS selecte_id 
  ON selecte_id.id_dish = resrarunt.dish.id


/* 6 запрос */
SELECT * FROM  resrarunt.peoples
  WHERE 
    id_roles = (
      SELECT id FROM  resrarunt.roles
        WHERE resrarunt.roles.name = "роль 1"
    )
    AND
    id_restatunts = (
      SELECT id FROM  resrarunt.restatunts
        WHERE resrarunt.restatunts.name = "название 1"
    )

/* 7 запрос */
SELECT * FROM resrarunt.order
  WHERE state = FALSE

/* 8 запрос */
insert into resrarunt.dish(id_restorant, state_dish, cost)
  values(9, TRUE, 100); /* Добавление данных для все столбцов*/


/* 9 запрос */
UPDATE resrarunt.order
  set state = TRUE
  WHERE id_client = 3


/* 10 запрос */
UPDATE resrarunt.dish
  set state_dish = FALSE
  WHERE id_restorant = 3