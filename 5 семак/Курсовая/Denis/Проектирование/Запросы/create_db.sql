



/* Удаление базы данных Restaurants*/
DROP DATABASE IF EXISTS restaurants; 
/* ------------ */




/* Создание базы данных Restaurants*/

CREATE DATABASE restaurants
CHARACTER SET utf8mb4
COLLATE utf8mb4_0900_ai_ci;

/* ------------ */



/*
1
Создание таблицы Должности - positions
Атрибуты:
  1) 'Код должности' BIGINT - id

  2) 'Название должности' VARCHAR(100) - title
  3) 'Описание должности' TEXT - description
  4) 'Образование для должности' VARCHAR(255) - education
  5) 'Должность являеется опасной' BOOL - is_dangerous
*/
CREATE TABLE restaurants.positions (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Код должности',
  
  title VARCHAR(100) NOT NULL COMMENT 'Название должности',
  description TEXT DEFAULT NULL COMMENT 'Описание должности',
  education VARCHAR(255) DEFAULT NULL COMMENT 'Образование для должности',
  is_dangerous BOOL DEFAULT 0 COMMENT 'Должность являеется опасной',
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Должности';
/* ------------ */



/*
2
Создание таблицы График работы - schedule
Атрибуты:
  1) 'Код графика работы' BIGINT - id

  2) 'Время работы в понедельник' VARCHAR(13) - time_monday
  2) 'Время работы в вторник' VARCHAR(13) - time_tuesday
  3) 'Время работы в среда' VARCHAR(13) - time_wednesday
  4) 'Время работы в четверг' VARCHAR(13) - time_thursday
  5) 'Время работы в пятница' VARCHAR(13) - time_friday
  6) 'Время работы в суббота' VARCHAR(13) - time_saturday
  7) 'Время работы в воскресенье' VARCHAR(13) - time_sunday

Формат времени: 
Начало - конец
чч.мм - чч.мм
*/
CREATE TABLE restaurants.schedule (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Код графика работы',
  
  time_monday VARCHAR(13) DEFAULT "08.00 - 18.00" COMMENT "Время работы в понедельник",
  time_tuesday VARCHAR(13) DEFAULT "08.00 - 18.00" COMMENT "Время работы в вторник",
  time_wednesday VARCHAR(13) DEFAULT "08.00 - 18.00" COMMENT "Время работы в среду",
  time_thursday VARCHAR(13) DEFAULT "08.00 - 18.00" COMMENT "Время работы в четверг",
  time_friday VARCHAR(13) DEFAULT "08.00 - 18.00" COMMENT "Время работы в пятницу",
  time_saturday VARCHAR(13) DEFAULT "08.00 - 18.00" COMMENT "Время работы в субботу",
  time_sunday VARCHAR(13) DEFAULT "08.00 - 18.00" COMMENT "Время работы в воскресенье",

  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'График работы';

/* ------------ */




/*
3
Создание таблицы Диапазон блюд - range_dishes
  1) 'Код блюда' BIGINT - id

  2) 'название' VARCHAR(100) - name
  3) 'Описание блюда' TEXT - describe
  4) 'Пригодно для упоребления несовершенолетними' BOOL - for_children
*/

CREATE TABLE restaurants.range_dishes (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Код блюда',
  
  name VARCHAR(100) COMMENT "Название",
  `describe` TEXT COMMENT "Описание блюда",
  for_children BOOL COMMENT "Пригодно для упоребления несовершенолетними",

  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Диапазон блюд';

/* ------------ */



/*
4(Ссылка на 2)
Создание таблицы Рестораны - restaurants
  1) 'Код ресторана' BIGINT - id

  2) 'название' VARCHAR(100) - name
  3) 'Оценка' FLOAT - mark_feedback
  4) 'адрес' VARCHAR(255) - address
  5) 'Количество звез мишлена' TINYINT - cout_star
  6) 'ID графика работы' BIGINT - id_schedule

*/
CREATE TABLE restaurants.restaurants (
  id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Код ресторана',
  
  name VARCHAR(100) COMMENT "Название",
  mark_feedback FLOAT DEFAULT 0 COMMENT "Оценка",
  address VARCHAR(255) COMMENT "Адрес",
  cout_star TINYINT DEFAULT 0 COMMENT "Количество звез мишлена",
  id_schedule BIGINT UNSIGNED NOT NULL COMMENT "Код графика работы",

  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Рестораны';

ALTER TABLE restaurants.restaurants
ADD CONSTRAINT FK_restaurants_id_schedule FOREIGN KEY (id_schedule)
REFERENCES restaurants.schedule (id);


/* ------------ */


/*
4.1(ссылка на 1, 4)
Создание таблицы Работники - workers
  1) 'Код работника' - id
  2) 'ФИО' - name
  3) 'Описание' - describe
  4) 'Зарплата' - salary
  5) 'Дата рождения' - birthday_date
  6) 'ID должности' - id_positions
  7) 'ID ресторана' - id_restaurants

*/


/* ------------ */



/*
5(ссылка 3, 4)
Создание таблицы Позиции меню - menu_item
  1) 'Код Позиции меню' - id
  2) 'стоимость' - cost
  3) 'грамовка' - weight
  4) 'ID блюда' - id_range_dishes
  5) 'ID ресторана' - id_restaurants


*/


/* ------------ */



/*
6
Создание таблицы Клиенты - clients
  1) 'Код клиента' - id
  2) 'Дата рождения' - birthday_date
  3) 'ФИО' - name
  4) 'Дата регистрации' - date_registration
  5) 'email' - email


*/


/* ------------ */



/*
6.1(ссылка 5)
Создание таблицы Заказы - orders
  1) 'Код заказа' - id
  2) 'название' - name
  3) 'Статус заказа' - state
  4) 'Дата заказа' - date
  5) 'ID клиента' - id_clients


*/


/* ------------ */


/*
7 (ссылка 5, 6.1)
Создание таблицы Заказаные блюда - order_dish
  1) 'Код заказа' - id_orders
  2) 'Код Позиции меню' - id_menu_item

*/


/* ------------ */