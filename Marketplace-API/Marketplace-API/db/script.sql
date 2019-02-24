CREATE DATABASE mjv_marketplace;
USE mjv_marketplace;
CREATE TABLE `stores`(
	`Id` int(10) UNSIGNED NULL DEFAULT NULL,
	`FantasyName` VARCHAR(50) NULL DEFAULT NULL,	
	`Cnpj` VARCHAR(50) NULL DEFAULT NULL, 
	`CorporateName` VARCHAR(50) NULL DEFAULT NULL,
	`Address` VARCHAR(50) NULL DEFAULT NULL,
	`Phone` VARCHAR(50) NULL DEFAULT NULL,
	`Responsible` VARCHAR(50) NULL DEFAULT NULL
)ENGINE=InnoDB;

ALTER TABLE stores CHANGE Id Id INT(10) AUTO_INCREMENT PRIMARY KEY;