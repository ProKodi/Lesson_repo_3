
CREATE DATABASE Student
CHARACTER SET utf8mb4
COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE student.специальности (
  `Код специальности` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `Наименование специальности` varchar(50) DEFAULT NULL,
  `Описание специальности` text DEFAULT NULL,
  PRIMARY KEY (`Код специальности`)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE student.Дисциплины (
  `Код дисциплины` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `Наименование дисциплины` varchar(50) DEFAULT NULL,
  `Описание дисциплины` text DEFAULT NULL,
  PRIMARY KEY (`Код дисциплины`)
)
ENGINE = INNODB;



CREATE TABLE student.студенты (
  `Код студента` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  ФИО varchar(50) DEFAULT NULL,
  Пол varchar(10) DEFAULT NULL,
  Родители varchar(50) DEFAULT NULL,
  Адрес text DEFAULT NULL,
  Телефон varchar(15) DEFAULT NULL,
  `Паспортные данные` text DEFAULT NULL,
  Группа varchar(10) DEFAULT NULL,
  `Дата рождения` datetime DEFAULT NULL,
  `Дата поступления` datetime DEFAULT NULL,
  `Очная форма обучения` tinyint(1) DEFAULT NULL,
  `Номер зачетки` bigint DEFAULT NULL,
  Курс tinyint DEFAULT NULL,
  `Код специальности` bigint UNSIGNED NOT NULL,
  PRIMARY KEY (`Код студента`)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

ALTER TABLE student.студенты
ADD CONSTRAINT `FK_студенты_Код специальности` FOREIGN KEY (`Код специальности`)
REFERENCES student.специальности (`Код специальности`);






CREATE TABLE student.экзамены (
  `Код студента` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `Код дисциплины` bigint UNSIGNED NOT NULL,
  `Дата экзамена` datetime DEFAULT NULL,
  Оценка tinyint DEFAULT NULL,
  PRIMARY KEY (`Код студента`)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

ALTER TABLE student.экзамены
ADD CONSTRAINT `FK_экзамены_Код дисциплины` FOREIGN KEY (`Код дисциплины`)
REFERENCES student.дисциплины (`Код дисциплины`) ON DELETE NO ACTION;