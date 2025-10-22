



/* Удаление базы данных Restaurants*/

DROP DATABASE restaurants; 

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
  1) 'Код должности' - id
  2) 'Название должности' - title
  3) 'Образование для должности' - education
  /* 4) 'Название отдела' - department_name */
  5) 'Описание должности' - description
  6) 'Должность являеется опасной'- is_dangerous
*/
CREATE TABLE restaurants.positions (
  id bigint UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Код должности',
  title varchar(255) NOT NULL COMMENT 'Название должности',
  education varchar(255) DEFAULT NULL COMMENT 'Образование для должности',
  /*department_name varchar(255) NOT NULL COMMENT 'Название отдела',*/
  description text DEFAULT NULL COMMENT 'Описание должности',
  is_dangerous tinyint(1) DEFAULT 0 COMMENT 'Должность являеется опасной',
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

Количество часов работы для каждого дня
время начала работы для каждого дня

Атрибуты:
  1) 'Код графика работы' - id

  2) 'Время работы в понедельник' - time_monday
  2) 'Время работы в вторник' - time_tuesday
  3) 'Время работы в среда' - time_wednesday
  4) 'Время работы в четверг' - time_thursday
  5) 'Время работы в пятница' - time_friday
  6) 'Время работы в суббота' - time_saturday
  7) 'Время работы в воскресенье' - time_sunday
*/

/* ------------ */




/*
3
Создание таблицы Диапазон блюд - range_dishes
  1) 'Код блюда' - id
  2) 'Пригодно для упоребления несовершенолетними' - for_children
  3) 'название' - name
  4) 'Описание блюда' - describe

*/


/* ------------ */



/*
4(Ссылка на 2)
Создание таблицы Рестораны - restaurants
  1) 'Код ресторана' - id
  2) 'Количество звез мишлена' - cout_star
  3) 'Оценка по отзывам' - mark_feedback
  4) 'название' - name
  5) 'адрес' - address
  6) 'ID графика работы' - id_schedule

*/


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