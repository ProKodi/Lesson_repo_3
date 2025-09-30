-- cafe_schema_and_queries.sql
-- Схема БД и набор SQL-запросов, удовлетворяющих требованиям пользователя (предметная область: кафе)
-- Код написан для MySQL (InnoDB), кодировка utf8mb4.

-- ===== SCHEMA =====


CREATE DATABASE IF NOT EXISTS cafe CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci;
USE cafe;

-- Рестораны / кафе
CREATE TABLE restaurants (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  description TEXT,
  created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Адреса ресторанов (один ресторан - один адрес, но можно расширить)
CREATE TABLE addresses (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  restaurant_id BIGINT UNSIGNED NOT NULL,
  street VARCHAR(255) NOT NULL,
  city VARCHAR(100) NOT NULL,
  postal_code VARCHAR(20),
  country VARCHAR(100) DEFAULT 'Россия',
  FOREIGN KEY (restaurant_id) REFERENCES restaurants(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- График работы по дням недели (обычный базовый график)
CREATE TABLE restaurant_schedule (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  restaurant_id BIGINT UNSIGNED NOT NULL,
  day_of_week TINYINT UNSIGNED NOT NULL COMMENT '1=Monday ... 7=Sunday',
  open_time TIME DEFAULT NULL,
  close_time TIME DEFAULT NULL,
  is_closed BOOLEAN NOT NULL DEFAULT FALSE,
  FOREIGN KEY (restaurant_id) REFERENCES restaurants(id) ON DELETE CASCADE,
  UNIQUE KEY ux_restaurant_day (restaurant_id, day_of_week)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Клиенты
CREATE TABLE customers (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  full_name VARCHAR(255),
  email VARCHAR(255) NOT NULL,
  phone VARCHAR(50),
  created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  UNIQUE KEY ux_customers_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Сотрудники
CREATE TABLE staff (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  restaurant_id BIGINT UNSIGNED NOT NULL,
  full_name VARCHAR(255) NOT NULL,
  position VARCHAR(100) NOT NULL,
  hire_date DATE,
  salary DECIMAL(10,2) DEFAULT NULL,
  is_active BOOLEAN NOT NULL DEFAULT TRUE,
  FOREIGN KEY (restaurant_id) REFERENCES restaurants(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Меню (блюда)
CREATE TABLE menu_items (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  restaurant_id BIGINT UNSIGNED NOT NULL,
  name VARCHAR(255) NOT NULL,
  description TEXT,
  price DECIMAL(10,2) NOT NULL,
  is_available BOOLEAN NOT NULL DEFAULT TRUE COMMENT 'Пометка доступности (soft delete)',
  created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY (restaurant_id) REFERENCES restaurants(id) ON DELETE CASCADE,
  INDEX (restaurant_id),
  INDEX (is_available)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Заказы
CREATE TABLE orders (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  restaurant_id BIGINT UNSIGNED NOT NULL,
  customer_id BIGINT UNSIGNED DEFAULT NULL,
  order_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  status VARCHAR(50) NOT NULL DEFAULT 'New', -- New, Preparing, Ready, Delivered, Cancelled
  delivery_address VARCHAR(255) DEFAULT NULL,

  FOREIGN KEY (restaurant_id) REFERENCES restaurants(id) ON DELETE CASCADE,
  FOREIGN KEY (customer_id) REFERENCES customers(id) ON DELETE SET NULL,
  INDEX (restaurant_id),
  INDEX (customer_id),
  INDEX (order_date),
  INDEX (status)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Позиции в заказе
CREATE TABLE order_items (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  order_id BIGINT UNSIGNED NOT NULL,
  menu_item_id BIGINT UNSIGNED NOT NULL,
  price DECIMAL(10,2) NOT NULL, -- цена на момент заказа
  quantity INT UNSIGNED NOT NULL DEFAULT 1,
  FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE CASCADE,
  FOREIGN KEY (menu_item_id) REFERENCES menu_items(id) ON DELETE RESTRICT,
  INDEX (order_id),
  INDEX (menu_item_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дополнительно: метки / категории (необязательно)
CREATE TABLE categories (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE menu_item_categories (
  menu_item_id BIGINT UNSIGNED NOT NULL,
  category_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY (menu_item_id, category_id),
  FOREIGN KEY (menu_item_id) REFERENCES menu_items(id) ON DELETE CASCADE,
  FOREIGN KEY (category_id) REFERENCES categories(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;




-- ========== QUERIES (соответствуют пунктам задачи) ==========

-- 1) Вывести все рестораны с их адресами и временем работы
-- (время работы выводим как агрегированный список по дням недели)
SELECT r.id AS restaurant_id, r.name AS restaurant_name,
       CONCAT(a.street, ', ', a.city, IFNULL(CONCAT(', ', a.postal_code), '')) AS address,
       rs.day_of_week, rs.open_time, rs.close_time, rs.is_closed
FROM restaurants r
LEFT JOIN addresses a ON a.restaurant_id = r.id
LEFT JOIN restaurant_schedule rs ON rs.restaurant_id = r.id
ORDER BY r.id, rs.day_of_week;

-- 2) Найти все доступные блюда в определённом ресторане (пример restaurant_id = 1)
SELECT *
FROM menu_items
WHERE restaurant_id = 1 AND is_available = TRUE;

-- 3) Показать список всех заказов клиента по его email
-- параметр: client_email
SET @client_email := 'client@example.com';
SELECT o.*
FROM orders o
JOIN customers c ON c.id = o.customer_id
WHERE c.email = @client_email
ORDER BY o.order_date DESC;

-- 4) Найти самые популярные блюда (по количеству заказов)
SELECT mi.id, mi.name, mi.restaurant_id, SUM(oi.quantity) AS total_orders_count
FROM order_items oi
JOIN menu_items mi ON mi.id = oi.menu_item_id
GROUP BY mi.id, mi.name, mi.restaurant_id
ORDER BY total_orders_count DESC;

-- 5) Рассчитать общую выручку ресторана за последнюю неделю
-- параметр: restaurant_id
SET @rest_id := 1;
SELECT r.id AS restaurant_id, r.name,
       SUM(oi.price * oi.quantity) AS revenue_last_7_days
FROM orders o
JOIN order_items oi ON oi.order_id = o.id
JOIN restaurants r ON r.id = o.restaurant_id
WHERE o.restaurant_id = @rest_id
  AND o.order_date >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
GROUP BY r.id, r.name;

-- 6) Найти официантов, которые работают в ресторане с названием "Уголок вкуса"
SELECT s.*
FROM staff s
JOIN restaurants r ON r.id = s.restaurant_id
WHERE r.name = 'Уголок вкуса' AND LOWER(s.position) LIKE '%официант%';

-- 7) Показать заказы, которые ещё не доставлены
SELECT * FROM orders WHERE status <> 'Delivered' AND status <> 'Cancelled' ORDER BY order_date DESC;

-- 8) Добавить новое блюдо в меню
-- параметры: @rest_id, @name, @descr, @price
SET @rest_id = 1;
SET @name = 'Новый суп Том Ям';
SET @descr = 'Острый тайский суп с креветками';
SET @price = 499.00;
INSERT INTO menu_items (restaurant_id, name, description, price, is_available)
VALUES (@rest_id, @name, @descr, @price, TRUE);
-- Получить id вставленного блюда
SELECT LAST_INSERT_ID() AS new_menu_item_id;

-- 9) Обновить статус заказа на "Готов" (Ready)
-- параметр: @order_id
SET @order_id = 123;
UPDATE orders SET status = 'Ready' WHERE id = @order_id;
SELECT ROW_COUNT() AS affected_rows;

-- 10) Удалить блюдо из меню (по метке, т.е. пометить как недоступное)
-- параметр: @menu_item_id
SET @menu_item_id = 10;
UPDATE menu_items SET is_available = FALSE WHERE id = @menu_item_id;
SELECT ROW_COUNT() AS affected_rows;

-- 11) Найти средний чек заказа по ресторанам
SELECT r.id AS restaurant_id, r.name,
       AVG(o.total_amount) AS avg_check
FROM restaurants r
LEFT JOIN orders o ON o.restaurant_id = r.id
GROUP BY r.id, r.name
ORDER BY avg_check DESC;

-- 12) Сколько заказов сделал каждый клиент?
SELECT c.id AS customer_id, c.email, c.full_name, COUNT(o.id) AS orders_count
FROM customers c
LEFT JOIN orders o ON o.customer_id = c.id
GROUP BY c.id, c.email, c.full_name
ORDER BY orders_count DESC;

-- 14) Показать топ-3 клиента по сумме заказов (по всем ресторанам)
SELECT c.id AS customer_id, c.email, c.full_name, SUM(o.total_amount) AS total_spent
FROM customers c
JOIN orders o ON o.customer_id = c.id
GROUP BY c.id, c.email, c.full_name
ORDER BY total_spent DESC
LIMIT 3;

-- 15) Найти всех сотрудников с зарплатой выше средней по их ресторану
SELECT s.id AS staff_id, s.full_name, s.position, s.salary, s.restaurant_id
FROM staff s
JOIN (
  SELECT restaurant_id, AVG(salary) AS avg_salary
  FROM staff
  WHERE salary IS NOT NULL
  GROUP BY restaurant_id
) AS avg_tbl ON avg_tbl.restaurant_id = s.restaurant_id
WHERE s.salary > avg_tbl.avg_salary;

-- 16) Вывести количество заказов по дням недели
SELECT DAYNAME(o.order_date) AS day_name, WEEKDAY(o.order_date) AS weekday_index, COUNT(*) AS orders_count
FROM orders o
GROUP BY weekday_index, day_name
ORDER BY weekday_index;

-- 17) Показать все заказы, в которых было заказано более 3 блюд (позиций)
SELECT o.id AS order_id, o.customer_id, o.order_date, SUM(oi.quantity) AS items_count
FROM orders o
JOIN order_items oi ON oi.order_id = o.id
GROUP BY o.id
HAVING SUM(oi.quantity) > 3
ORDER BY items_count DESC;

-- 18) Рассчитать общую сумму заказа (на примере order_id = @order_id)
SET @order_id = 123;
SELECT o.id AS order_id, SUM(oi.price * oi.quantity) AS order_total
FROM orders o
JOIN order_items oi ON oi.order_id = o.id
WHERE o.id = @order_id
GROUP BY o.id;

-- ===== Дополнения: полезные представления и триггер =====
-- View: быстрый доступ к сумме заказа
CREATE OR REPLACE VIEW order_totals AS
SELECT o.id AS order_id, o.restaurant_id, o.customer_id, o.order_date, SUM(oi.price * oi.quantity) AS total
FROM orders o
JOIN order_items oi ON oi.order_id = o.id
GROUP BY o.id;

-- Optionally: триггер, чтобы фиксировать total_amount в orders при вставке/обновлении
-- (Делать аккуратно с generated column; данный триггер — пример и может быть отключён)
DELIMITER $$
CREATE TRIGGER trg_update_order_total AFTER INSERT ON order_items
FOR EACH ROW
BEGIN
  UPDATE orders SET /* total_amount рассчитан виртуально, но если нужно физическое поле, можно обновлять */
    /* Здесь можно выполнять дополнительные действия, например запись истории */
    order_date = order_date; -- no-op placeholder
END$$
DELIMITER ;

-- Конец файла
