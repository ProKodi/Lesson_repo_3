



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
  1) `ID должности` - id
  2) `Название должности` - title
  3) `Образование для должности` - education
  4) `Название отдела` - department_name
  5) `Описание должности` - description
  6) `Должность являеется опасной`- is_dangerous
*/

CREATE TABLE student.specialties (
  id bigint UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Код специальности',
  name varchar(50) DEFAULT NULL COMMENT 'Наименование специальности',
  `describe` text DEFAULT NULL COMMENT 'Описание специальности',
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Cпециальности';

/* ------------ */