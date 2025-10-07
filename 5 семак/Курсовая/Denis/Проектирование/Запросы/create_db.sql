



/* Удаление базы данных Restaurants*/

DROP DATABASE restaurants; 

/* ------------ */




/* Создание базы данных Restaurants*/

CREATE DATABASE restaurants
CHARACTER SET utf8mb4
COLLATE utf8mb4_0900_ai_ci;

/* ------------ */



/*
Создание таблицы Должности - positions

Атрибуты:
  1) 'Код должности' - id
  2) 'Название должности' - title
  3) 'Образование для должности' - education
  4) 'Название отдела' - department_name
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
Создание таблицы График работы - schedule

Количество часов работы для каждого дня
время начала работы для каждого дня

Атрибуты:
  1) 'Код графика работы' - id
  2) 'Название должности' - title
  3) 'Образование для должности' - education
  4) 'Название отдела' - department_name
  5) 'Описание должности' - description
  6) 'Должность являеется опасной'- is_dangerous

'Время начала работы в понедельник' - time_start_monday
'Время конца  работы в понедельник' - time_end_monday

'Время начала работы в вторник' - time_start_tuesday
'Время конца  работы в вторник' - time_end_tuesday

'Время начала работы в среда'
'Время конца  работы в среда'

'Время начала работы в четверг'
'Время конца  работы в четверг'

'Время начала работы в пятница'
'Время конца  работы в пятница'

'Время начала работы в суббота'
'Время конца  работы в суббота'

'Время начала работы в воскресенье'
'Время конца  работы в воскресенье'
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