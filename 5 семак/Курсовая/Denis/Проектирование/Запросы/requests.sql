



/* --------- 1 ------------- */
USE restaurants; 

SELECT * FROM restaurants
  JOIN schedule 
  ON restaurants.id_schedule = schedule.id
;


/* --------- 2 ------------- */
SELECT * FROM menu_item
  JOIN range_dishes
  ON range_dishes.id = id_range_dishes
  
  WHERE id_restaurants IN (
    SELECT id FROM restaurants
      WHERE name = 'Sakura Sushi' 
  )
;


/* --------- 3 ------------- */
SELECT * FROM orders
  WHERE id_clients IN (
    SELECT id FROM clients
      WHERE email = 'ivanov.sergey@example.com'
  )
;


/* --------- 4 ------------- */
SELECT range_dishes.name, COUNT(*) AS count_ord FROM order_dish
  JOIN menu_item
  ON id_menu_item = menu_item.id

  JOIN range_dishes
  ON id_range_dishes = range_dishes.id


  GROUP BY range_dishes.name

  ORDER BY count_ord
;


/* --------- 5 ? ------------- */
SELECT SUM(cost) FROM order_dish
  JOIN menu_item  
  ON order_dish.id_menu_item = menu_item.id

  JOIN orders 
  ON order_dish.id_orders = orders.id  

  WHERE date >= DATE_SUB(CURDATE(), INTERVAL 11 MONTH);


/* --------- 6 ------------- */
SELECT * FROM workers
  JOIN restaurants
  ON workers.id_restaurants = restaurants.id

  JOIN positions
  ON workers.id_positions = positions.id

  WHERE (
    restaurants.name = 'La Belle Vie' AND
    positions.title = "Официант"
  )


/* --------- 7 ------------- */
SELECT * FROM orders 
  WHERE NOT state
;


/* --------- 8 ------------- */
INSERT INTO range_dishes (name, `describe`, for_children)
VALUES
  ("Пивко", "Пивка для рывка", TRUE)
;

INSERT INTO menu_item (id_range_dishes, cost, weight, id_restaurants)
VALUES
  ((
    SELECT id FROM range_dishes
      WHERE name = "Пивко"
  ), 
  100, 1000,
  (
    SELECT id FROM restaurants
      WHERE name = "La Belle Vie"
  ))
;


/* --------- 9 ------------- */
UPDATE orders
  SET state = TRUE

  WHERE name = "Заказ №1002"
;


/* --------- 10 ------------- */
UPDATE menu_item
  SET in_stock = FALSE

  WHERE id_range_dishes IN (
    SELECT id FROM range_dishes
      WHERE name = "Пивко"
  ) AND 
  id_restaurants IN (
    SELECT id FROM restaurants
      WHERE name = "La Belle Vie"
  )
;


/* --------- 11 ------------- */
SELECT restaurants.name, AVG(cost) FROM order_dish
  JOIN menu_item
  ON menu_item.id = order_dish.id_menu_item

  JOIN restaurants  
  ON menu_item.id_restaurants = restaurants.id

  GROUP BY restaurants.name
;


/* --------- 12 ------------- */
SELECT clients.name, COUNT(*) FROM orders
  JOIN clients 
  
  ON orders.id_clients = clients.id

  GROUP BY id_clients
;


/* --------- 14 ------------- */
SELECT clients.name, SUM(menu_item.cost)  FROM order_dish
  JOIN orders 
  ON order_dish.id_orders = orders.id

  JOIN clients 
  ON orders.id_clients = clients.id

  JOIN menu_item 
  ON order_dish.id_menu_item = menu_item.id

  GROUP BY clients.id
;


/* --------- 15 ------------- */
SELECT * FROM workers
  WHERE salary >= (
    SELECT AVG(salary) FROM workers AS avg_sal
      WHERE avg_sal.id_restaurants =  workers.id_restaurants
      GROUP BY avg_sal.id_restaurants
  )
;


/* --------- 16 ------------- */
SELECT 
   CASE
       when WEEKDAY(date) = 0 THEN 'Понедельник'
       when WEEKDAY(date) = 1 THEN 'Вторник'
       when WEEKDAY(date) = 2 THEN 'Среда'
       when WEEKDAY(date) = 3 THEN 'Четверг'
       when WEEKDAY(date) = 4 THEN 'Пятница'
       when WEEKDAY(date) = 5 THEN 'Суббота'
       WHEN WEEKDAY(date) = 6 THEN 'Воскресенье'
       ELSE null
   END AS NameDay,
   COUNT(*)
FROM orders
   GROUP BY NameDay
;


/* --------- 17 ------------- */
SELECT orders.name, COUNT(*) AS CnOr  FROM order_dish
  JOIN orders 
  ON order_dish.id_orders = orders.id
  
  GROUP BY id_orders
  HAVING CnOr > 1
;


/* --------- 18 ------------- */
SELECT orders.name, SUM(menu_item.cost) FROM orders
  JOIN order_dish 
  ON order_dish.id_orders = orders.id

  JOIN menu_item 
  ON order_dish.id_menu_item = menu_item.id

  GROUP BY orders.id
;