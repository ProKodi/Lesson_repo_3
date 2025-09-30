



CREATE TABLE resrarunt.timetable (
  id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 11,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'График работы';


CREATE TABLE resrarunt.roles (
  id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  name varchar(50) NOT NULL COMMENT 'Название должности',
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 41,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Должности';

ALTER TABLE resrarunt.roles
ADD UNIQUE INDEX name (name);


CREATE TABLE resrarunt.restatunts (
  id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  adress varchar(255) NOT NULL,
  name varchar(50) NOT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 11,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Рестораны';

ALTER TABLE resrarunt.restatunts
ADD UNIQUE INDEX name (name);


CREATE TABLE resrarunt.peoples (
  id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  id_roles bigint UNSIGNED NOT NULL,
  id_restatunts bigint UNSIGNED NOT NULL,
  selary int UNSIGNED DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Сотрудники';

ALTER TABLE resrarunt.peoples
ADD CONSTRAINT FK_peoples_id_restatunts FOREIGN KEY (id_restatunts)
REFERENCES resrarunt.restatunts (id);

ALTER TABLE resrarunt.peoples
ADD CONSTRAINT FK_peoples_id_roles FOREIGN KEY (id_roles)
REFERENCES resrarunt.roles (id);



CREATE TABLE resrarunt.dish (
  id bigint UNSIGNED NOT NULL,
  id_restorant bigint UNSIGNED NOT NULL,
  state_dish tinyint(1) DEFAULT NULL,
  cost int UNSIGNED DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Блюда';

ALTER TABLE resrarunt.dish
ADD CONSTRAINT FK_dish_id_restorant FOREIGN KEY (id_restorant)
REFERENCES resrarunt.restatunts (id);




/* Заполнение ролей */

INSERT INTO resrarunt.roles(name)
VALUES
("роль 1"),
("роль 2"),
("роль 3"),
("роль 4"),
("роль 5"),
("роль 6"),
("роль 7"),
("роль 8"),
("роль 9"),
("роль 10")
;


/* Заполнение График работы */

INSERT INTO resrarunt.timetable(id)
VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10)
;


/* Заполнение Ресторан */

INSERT INTO resrarunt.restatunts(adress, name)
VALUES
("адрес 1", "название 1"),
("адрес 2", "название 2"),
("адрес 3", "название 3"),
("адрес 4", "название 4"),
("адрес 5", "название 5"),
("адрес 1", "название 6"),
("адрес 2", "название 7"),
("адрес 3", "название 8"),
("адрес 4", "название 9"),
("адрес 5", "название 10")
;


/* Заполнение Сотрудники */

INSERT INTO resrarunt.peoples(id_roles, id_restatunts, selary)
VALUES
(31, 1, 2000),
(40, 2, 4000),
(32, 3, 5000),
(33, 6, 3000)
;

