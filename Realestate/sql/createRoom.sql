DROP DATABASE IF EXISTS `Room_db`;
CREATE DATABASE IF NOT EXISTS `Room_db`;

USE Room_db;

CREATE TABLE IF NOT EXISTS `roomInfo` (
    `col` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `displayName` VARCHAR(50) NOT NULL,
    `saveName` VARCHAR(50) NOT NULL,
    `price` int(11),
    `latitude` decimal(20,17),
    `longtitude` decimal(20,17),
    `fullAddress` VARCHAR(100),
    `showWindowHTML` VARCHAR(500),
    `imageURL` VARCHAR(100)
)ENGINE = MyISAM;



