CREATE DATABASE IF NOT EXISTS `mjv_marketplace` ;
USE `mjv_marketplace`;

CREATE TABLE IF NOT EXISTS `products` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(50) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Category` varchar(50) DEFAULT NULL,
  `Image` varchar(255) DEFAULT NULL,
  `Price` int(20) DEFAULT NULL,
  `Quantity` int(20) DEFAULT NULL,
  `store_id` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=UTF8MB4;


INSERT INTO `products` (`Id`, `ProductName`, `Description`, `Category`, `Image`, `Price`, `Quantity`, `store_id`) VALUES
	(1, 'GTX 1080 TI', 'Placa de video', 'Hardware', 'https://www.evga.com/articles/01092/images/header/ultimate.png', 3000, 100, '1'),
	(2, 'RTX 2080 TI', 'Placa de video', 'Hardware', 'https://bit.ly/2BQOQaA', 5000, 20, '1'),
	(3, 'GTX 1050 2GB', 'Placa de video low end', 'Hardware', 'https://bit.ly/2tFjMq0', 460, 500, '1'),
	(4, 'Geladeira', 'Geladeira consul com prateleiras', 'Eletrodomesticos', 'https://bit.ly/2tGeASF', 1000, 30, '2'),
	(5, 'Cama', 'Cama de casal', 'Moveis', 'https://bit.ly/2BWhJCc', 550, 20, '2'),
	(6, 'Escrivaninha', 'Escrivaninha para quarto', 'Moveis', 'https://linkficticiodaimagem.com/link', 200, 45, '2'),
	(7, 'Iphone SE 16gb', 'Iphone SE 16gb 2gbram ', 'Eletronicos', 'https://linkficticiodaimagem.com/link', 1000, 300, '3'),
	(8, 'Samsumg Galaxy S10', 'Smarthphone Samsumg S10', 'Eletronicos', 'https://linkficticiodaimagem.com/link', 7000, 48, '3'),
	(9, 'Xiaomi Mi X', 'Smarthphone Xiaomi Mi X com 10000gbram e 1290TB de armazenamento somente por 1000 reais!', 'Eletronicos', 'https://linkficticiodaimagem.com/link', 1000, 48, '3');

CREATE TABLE IF NOT EXISTS `stores` (
  `Id` int(10) NOT NULL AUTO_INCREMENT,
  `FantasyName` varchar(50) DEFAULT NULL,
  `Cnpj` varchar(50) DEFAULT NULL,
  `CorporateName` varchar(50) DEFAULT NULL,
  `Address` varchar(50) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `Responsible` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=UTF8MB4;

INSERT INTO `stores` (`Id`, `FantasyName`, `Cnpj`, `CorporateName`, `Address`, `Phone`, `Responsible`) VALUES
	(1, 'Pichau Informática', '1992912', 'Pichau Computadores LTDA', 'Rua: Aquidaban, Nº777, Bairro: Alto de cima', '(12)888776-7545', 'Allan Barry'),
	(2, 'Casas Bahia', '19928192891', 'Casas Bahia LTDA', 'Rua: Melio, Nº555, Bairro: Alto de baixo', '(12)123123-7545', 'San Holo'),
	(3, 'Magazine Luiza', '141231231', 'Magazine Luiza LTDA', 'Rua: Luizalab, Nº444, Bairro: loreal', '(12)009989-13123', 'Skywalker Luke');

CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `Login` varchar(50) NOT NULL,
  `AccessKey` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Login` (`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=UTF8MB4;


INSERT INTO `users` (`ID`, `Login`, `AccessKey`) VALUES
	(1, 'admin', '123');



