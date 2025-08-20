CREATE TABLE IF NOT EXISTS `books` (
  `id` INT(10) NOT NULL AUTO_INCREMENT,
  `author` varchar(100) NOT NULL,
  `launch_date` datetime(6) NOT NULL,
  `price` decimal(65,2) NOT NULL,
  `title` varchar(500) NOT NULL,
   PRIMARY KEY (`id`)
)