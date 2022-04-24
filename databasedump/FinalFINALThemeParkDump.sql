CREATE DATABASE  IF NOT EXISTS `theme_park` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `theme_park`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: rnrthemepark-db3380.mysql.database.azure.com    Database: theme_park
-- ------------------------------------------------------
-- Server version	5.6.47.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `closes`
--

DROP TABLE IF EXISTS `closes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `closes` (
  `closeID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `rideID` int(10) unsigned NOT NULL,
  `employeeID` int(10) unsigned NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `type` varchar(45) NOT NULL DEFAULT 'n/a',
  `cost` int(10) unsigned NOT NULL DEFAULT '0',
  `month` int(2) unsigned DEFAULT NULL,
  `year` int(4) unsigned DEFAULT NULL,
  PRIMARY KEY (`closeID`,`rideID`,`employeeID`),
  KEY `closedRide_idx` (`rideID`),
  KEY `closingStaff_idx` (`employeeID`),
  CONSTRAINT `closedRide` FOREIGN KEY (`rideID`) REFERENCES `rides` (`rideID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `closingStaff` FOREIGN KEY (`employeeID`) REFERENCES `staff` (`employeeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `closes`
--

LOCK TABLES `closes` WRITE;
/*!40000 ALTER TABLE `closes` DISABLE KEYS */;
INSERT INTO `closes` VALUES (6,401,109,'2022-04-18','04:53:54','maintenance',200,4,2022),(7,401,109,'2022-04-10','04:54:46','weather',100,4,2022),(8,417,113,'2022-01-04','08:00:00','maintenance',300,1,2022),(9,417,113,'2022-02-13','05:00:00','weather',0,2,2022),(10,411,123,'2022-04-19','12:00:00','weather',0,2,2022),(11,417,113,'2022-04-19','12:00:00','weather',0,2,2022),(12,410,122,'2022-04-10','05:00:00','maintenance',400,4,2022),(22,420,102,'2022-04-19','00:17:25','maintenance',350,4,2022),(23,420,102,'2022-04-21','00:22:03','maintenance',350,4,2022),(24,420,102,'2022-04-21','00:22:13','maintenance',400,4,2022),(25,3,101,'2022-04-24','10:00:00','maintenance',10,4,2022);
/*!40000 ALTER TABLE `closes` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`courtney`@`%`*/ /*!50003 trigger rideClosure
after insert on closes
for each row
begin
	insert into emailq (email, subject, type, relatedID) values ('staff', 'Ride closure', 'rideClosure', new.closeID);
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `credentials`
--

DROP TABLE IF EXISTS `credentials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `credentials` (
  `userID` int(11) unsigned NOT NULL,
  `userName` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `jobCategory` varchar(45) NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userName_UNIQUE` (`userName`),
  CONSTRAINT `staffID` FOREIGN KEY (`userID`) REFERENCES `staff` (`employeeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credentials`
--

LOCK TABLES `credentials` WRITE;
/*!40000 ALTER TABLE `credentials` DISABLE KEYS */;
INSERT INTO `credentials` VALUES (101,'admin','cosc3380!','HR'),(102,'mod','cosc3340.','HR'),(130,'hotelSQL','hotel3380!','hotel'),(131,'restaurantSQL','rest3380!','restaurant'),(132,'rideSQL','ride3380!','ride');
/*!40000 ALTER TABLE `credentials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emailq`
--

DROP TABLE IF EXISTS `emailq`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `emailq` (
  `idEmail` int(4) NOT NULL AUTO_INCREMENT,
  `email` varchar(40) NOT NULL,
  `subject` varchar(45) NOT NULL,
  `type` varchar(10) NOT NULL,
  `relatedID` int(20) DEFAULT NULL,
  PRIMARY KEY (`idEmail`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emailq`
--

LOCK TABLES `emailq` WRITE;
/*!40000 ALTER TABLE `emailq` DISABLE KEYS */;
/*!40000 ALTER TABLE `emailq` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hotel`
--

DROP TABLE IF EXISTS `hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hotel` (
  `hotelID` int(11) unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `h_locID` int(6) unsigned NOT NULL,
  `capacity` int(11) DEFAULT NULL,
  `h_expenditure` double NOT NULL DEFAULT '0',
  `rating` int(1) DEFAULT NULL,
  `h_revenue` double NOT NULL DEFAULT '0',
  `archived` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`hotelID`),
  UNIQUE KEY `hotelID_UNIQUE` (`hotelID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotel`
--

LOCK TABLES `hotel` WRITE;
/*!40000 ALTER TABLE `hotel` DISABLE KEYS */;
INSERT INTO `hotel` VALUES (501,'Welcome Hotel',903,200,5050,4,325,0),(502,'Hilltop Hotel',910,300,8000,5,0,0),(503,'Suburban Simulation',904,100,9001,4,0,0),(504,'Apartmentland',903,150,4500,3,0,0),(505,'CEO Condominiums Inc.',903,30,10000,5,12000,0),(506,'Spicy Resort',911,125,6125,4,502,0),(507,'Bilgewater Resorts',906,70,5300,5,0,0),(508,'Voyager of the Seas',906,300,9050,4,400,0),(45612,'Courtney\'s Hotel',911,1000,1000,5,0,0);
/*!40000 ALTER TABLE `hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `location`
--

DROP TABLE IF EXISTS `location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `location` (
  `locationID` int(11) unsigned NOT NULL,
  `locationName` varchar(45) NOT NULL,
  PRIMARY KEY (`locationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `location`
--

LOCK TABLES `location` WRITE;
/*!40000 ALTER TABLE `location` DISABLE KEYS */;
INSERT INTO `location` VALUES (901,'Perry\'s Plaza'),(902,'Randy\'s Road'),(903,'Cindy\'s City'),(904,'Terry\'s Town'),(905,'Ezra\'s Entrance'),(906,'Sally\'s Seaport'),(907,'Jerry\'s Jungle'),(908,'Mike\'s Mountain'),(909,'Zoe\'s Zoo'),(910,'Hilda\'s Hill'),(911,'Courtney Country');
/*!40000 ALTER TABLE `location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `restaurant`
--

DROP TABLE IF EXISTS `restaurant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `restaurant` (
  `restaurantID` int(11) unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `rest_locID` int(11) unsigned NOT NULL,
  `capacity` int(11) NOT NULL DEFAULT '0',
  `r_revenue` double NOT NULL DEFAULT '0',
  `r_expenditure` double NOT NULL DEFAULT '0',
  `archived` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`restaurantID`),
  UNIQUE KEY `restaurauntID_UNIQUE` (`restaurantID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `restaurant`
--

LOCK TABLES `restaurant` WRITE;
/*!40000 ALTER TABLE `restaurant` DISABLE KEYS */;
INSERT INTO `restaurant` VALUES (601,'Perry\'s Pizza',903,20,100,900,0),(602,'Bubba Gump',906,50,156,1100,0),(603,'Sakura\'s Sushi',906,25,40,800,0),(604,'Home Cooked Goods!',904,20,125,750,0),(605,'Plump Pot Pies',904,30,49,1100,0),(606,'Francie\'s Funnel Cakes',905,2,0,300,0),(607,'Hilltop Bakery',910,30,0,900,0),(608,'Brisket Express',904,30,175,900,0),(609,'Juicy Sausage and Creamy Oysters',904,40,0,900,0),(610,'Pufferfish Plate',911,30,0,1500,0),(611,'Hilltop Creamery',910,20,0,800,0),(612,'Hilltop Dinery',910,50,124,1300,0),(613,'Veg-Out Gupta\'s',903,30,0,600,0),(614,'Latte Lounge',907,30,0,600,0),(615,'Peak Experience',908,30,150,1250,0),(616,'Infernal Wings',911,50,0,1150,0);
/*!40000 ALTER TABLE `restaurant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rides`
--

DROP TABLE IF EXISTS `rides`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rides` (
  `rideID` int(11) unsigned NOT NULL,
  `capacity` int(10) unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `maxWeight` int(10) unsigned NOT NULL,
  `minHeight` int(10) unsigned NOT NULL,
  `minAge` int(10) unsigned NOT NULL,
  `r_locID` int(10) NOT NULL,
  `archived` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`rideID`),
  UNIQUE KEY `rideID_UNIQUE` (`rideID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rides`
--

LOCK TABLES `rides` WRITE;
/*!40000 ALTER TABLE `rides` DISABLE KEYS */;
INSERT INTO `rides` VALUES (3,30,'allin',200,140,8,101,1),(401,18,'Roland\'s Rollercoaster',300,130,10,902,0),(402,8,'Rocky\'s Rock Climbing',250,110,15,902,0),(403,20,'Mary\'s Merry-Go-Round',300,60,2,901,0),(404,100,'The Error-Infested Haunted House',600,60,4,903,0),(405,100,'Finn\'s Hedge Maze',600,60,2,907,0),(406,2,'Wally\'s Waterslide',250,80,6,906,0),(407,4,'Rita\'s River Rapids',250,60,6,906,0),(408,1,'Faust\'s Fast Slide',250,110,10,906,0),(409,4,'Manny\'s Raft-Slide',250,80,5,906,0),(410,17,'Trisha\'s Tram',500,0,0,902,0),(411,18,'Tasha\'s Train',350,0,0,902,0),(412,10,'Billy\'s Bumper Cars',250,60,4,901,0),(413,20,'Vivian\'s Vine Swings',250,40,7,907,0),(414,10,'Richard\'s Racetrack',300,60,8,901,0),(415,7,'Splinter Bridge',200,60,5,907,0),(416,50,'Mirabel\'s Mirror Maze',600,0,0,903,0),(417,20,'Eternal Coaster',300,140,10,908,0),(418,8,'Gondola',300,0,0,908,0),(419,2,'Bobby\'s Bobsled',250,110,10,908,0),(420,100,'Aromatic Garden',600,60,18,910,0),(42069,30,'Death Thriller',200,135,8,42069,1);
/*!40000 ALTER TABLE `rides` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `employeeID` int(11) unsigned NOT NULL,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `gender` char(1) NOT NULL,
  `weeklySalary` int(10) unsigned NOT NULL,
  `jobCategory` varchar(45) NOT NULL,
  `archived` tinyint(4) NOT NULL DEFAULT '0',
  `email` varchar(45) NOT NULL DEFAULT '0',
  PRIMARY KEY (`employeeID`),
  UNIQUE KEY `employeeID_UNIQUE` (`employeeID`),
  KEY `staffJobIndex` (`jobCategory`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (101,'Courtney','Nguyen','f',1000,'HR',0,'courtney@gmail.com'),(102,'Axit','Garcia','m',500,'HR',0,'medinaitsai@gmail.com'),(103,'Elon','Musk','m',300,'hotel',0,'itsai500@gmail.com'),(109,'John','Doe','m',200,'ride',0,'johndoe@email.com'),(113,'Alejandro','Gonzales','m',500,'ride',0,'ag40250@gmail.com'),(116,'Potato','Head','u',400,'restaurant',0,'potato@head.com'),(117,'Jeffery','Einstein','m',500,'restaurant',0,'bigbrain150@gmail.com'),(118,'Jonas','Hill','m',700,'restaurant',0,'jonashill@outlook.com'),(119,'Adam','Savage','m',450,'restaurant',0,'asavage@mythbuster.com'),(120,'Jeff','Bezos','m',10000,'hotel',0,'owner@amazon.com'),(121,'Queen','Elizabeth','f',200,'ride',0,'ukqueen@email.com'),(122,'Trisha','Walker','f',400,'ride',0,'twalker232@outlook.com'),(123,'Tasha','Smith','f',400,'ride',0,'tsmith450@outlook.com'),(124,'Scrooge','McDuck','m',3000,'hotel',0,'fatstackofcash@disneycorp.com'),(125,'Jake','Ter','m',400,'hotel',0,'jaketer@outlook.com'),(126,'Wallace','Anulola','m',300,'ride',0,'walauki@histate.com'),(127,'Holly','Teller','f',600,'hotel',0,'jollyholly@gmail.com'),(129,'Jimmy','Castillo','m',700,'hotel',0,'castleofjim@outlook.com'),(130,'Gianno','Tirado','m',400,'hotel',0,'giannotirado@gmail.com'),(131,'Krunal','Kalathiya','m',400,'restaurant',0,'krunalkalathiya35@gmail.com'),(132,'Ziyan','Maknojia','m',400,'ride',0,'ziyanmak@gmail.com'),(789,'Itsai','Medina','u',125,'restaurant',0,'medinaitsai@gmail.com');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visit_hotel`
--

DROP TABLE IF EXISTS `visit_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visit_hotel` (
  `visitID` int(11) NOT NULL AUTO_INCREMENT,
  `tickID_h` int(11) unsigned NOT NULL,
  `hotID` int(11) unsigned NOT NULL,
  `dateVisited` date NOT NULL,
  `amountSpent` double NOT NULL DEFAULT '0',
  `daysStayed` int(11) NOT NULL DEFAULT '1',
  `roomNumber` int(11) NOT NULL,
  PRIMARY KEY (`visitID`),
  KEY `hotelVisited_idx` (`hotID`),
  KEY `visitHotel_idx` (`tickID_h`),
  CONSTRAINT `atHotel` FOREIGN KEY (`hotID`) REFERENCES `hotel` (`hotelID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `visitHotel` FOREIGN KEY (`tickID_h`) REFERENCES `visitor` (`ticketID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visit_hotel`
--

LOCK TABLES `visit_hotel` WRITE;
/*!40000 ALTER TABLE `visit_hotel` DISABLE KEYS */;
INSERT INTO `visit_hotel` VALUES (8,20,501,'2022-04-22',325,5,105),(9,27,508,'2022-04-22',400,4,203),(10,26,505,'2022-04-22',12000,12,1104),(11,37,506,'2022-04-18',200,3,404),(12,38,506,'2022-04-18',302,3,403);
/*!40000 ALTER TABLE `visit_hotel` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`courtney`@`%`*/ /*!50003 TRIGGER hotel_rev_update 
AFTER INSERT ON visit_hotel
FOR EACH ROW
UPDATE hotel SET h_revenue = h_revenue + NEW.amountSpent WHERE hotelID = NEW.hotID */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `visit_restaurant`
--

DROP TABLE IF EXISTS `visit_restaurant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visit_restaurant` (
  `visitID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `tickID_r` int(11) unsigned NOT NULL,
  `restID` int(11) unsigned NOT NULL,
  `dateVisited` date NOT NULL,
  `amountSpent` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`visitID`),
  KEY `ticketRestaurant_idx` (`tickID_r`),
  KEY `atRestaurant_idx` (`restID`),
  CONSTRAINT `atRestaurant` FOREIGN KEY (`restID`) REFERENCES `restaurant` (`restaurantID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ticketVisiting` FOREIGN KEY (`tickID_r`) REFERENCES `visitor` (`ticketID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visit_restaurant`
--

LOCK TABLES `visit_restaurant` WRITE;
/*!40000 ALTER TABLE `visit_restaurant` DISABLE KEYS */;
INSERT INTO `visit_restaurant` VALUES (6,21,615,'2022-03-25',150),(8,21,615,'2022-03-25',124),(9,21,608,'2022-03-25',175),(10,21,604,'2022-03-25',80),(15,18,601,'2022-04-17',100),(16,29,603,'2022-04-21',40),(17,29,604,'2022-04-21',45),(18,23,602,'2022-04-18',100),(19,23,605,'2022-02-17',49),(20,23,602,'2022-04-19',56);
/*!40000 ALTER TABLE `visit_restaurant` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`courtney`@`%`*/ /*!50003 TRIGGER rest_rev_update 
AFTER INSERT ON visit_restaurant
FOR EACH ROW
UPDATE restaurant SET r_revenue = r_revenue + NEW.amountSpent WHERE restaurantID = NEW.restID */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `visitor`
--

DROP TABLE IF EXISTS `visitor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visitor` (
  `ticketID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `visitDate` date NOT NULL,
  `month` int(2) NOT NULL,
  `day` int(2) NOT NULL,
  `year` int(4) NOT NULL,
  `ticketType` varchar(16) NOT NULL,
  `ticketCost` double NOT NULL,
  `email` varchar(45) NOT NULL,
  PRIMARY KEY (`ticketID`),
  UNIQUE KEY `ticketID_UNIQUE` (`ticketID`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visitor`
--

LOCK TABLES `visitor` WRITE;
/*!40000 ALTER TABLE `visitor` DISABLE KEYS */;
INSERT INTO `visitor` VALUES (18,'2022-04-17',4,17,2022,'general',50,'rocknrolllover@gmail.com'),(19,'2022-04-17',4,17,2022,'general',50,'normie@gmail.com'),(20,'2022-01-01',4,18,2022,'seasonal',200,'first@email.com'),(21,'2022-03-25',4,18,2022,'general',50,'foodeater@outlook.com'),(22,'2022-04-18',4,18,2022,'general',50,'foodlover@yahoo.com'),(23,'2022-04-18',4,18,2022,'general',50,'riderider@gmail.com'),(26,'2022-04-18',4,18,2022,'seasonal',200,'notascam@realorg.com'),(27,'2022-04-18',4,18,2022,'seasonal',200,'scumbagsam@realorg.com'),(29,'2022-04-21',4,21,2022,'general',50,'court@eh.com'),(30,'2022-02-28',2,28,2022,'seasonal',200,'giannotirado@gmail.com'),(32,'2022-03-14',2,28,2022,'general',50,'freddy@falseemail.com'),(37,'2022-04-19',4,19,2022,'general',50,'courtneysemail@gmail.com'),(38,'2022-04-11',4,11,2022,'general',50,'counguyen2@outlook.com'),(39,'2022-04-18',4,18,2022,'general',50,'medinaitsai@gmail.com'),(40,'2022-04-19',4,19,2022,'general',50,'medinaitsai@gmail.com');
/*!40000 ALTER TABLE `visitor` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`courtney`@`%`*/ /*!50003 trigger emailVisitor
after insert on visitor
for each row
begin
	insert into emailq (email, subject, type, relatedID) values (new.email, 'Ticket Confirmation', 'visitor', new.ticketID); 
end */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `works_hotel`
--

DROP TABLE IF EXISTS `works_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `works_hotel` (
  `staID` int(11) unsigned NOT NULL,
  `hotID` int(11) unsigned NOT NULL,
  `archived` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`staID`,`hotID`),
  KEY `workAtHotel_idx` (`hotID`),
  KEY `hStaffArchived_idx` (`archived`),
  CONSTRAINT `staffHotel` FOREIGN KEY (`staID`) REFERENCES `staff` (`employeeID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `workAtHotel` FOREIGN KEY (`hotID`) REFERENCES `hotel` (`hotelID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `works_hotel`
--

LOCK TABLES `works_hotel` WRITE;
/*!40000 ALTER TABLE `works_hotel` DISABLE KEYS */;
INSERT INTO `works_hotel` VALUES (103,505,0),(120,505,0),(124,505,0),(125,504,0),(127,502,0),(129,508,0),(130,506,0);
/*!40000 ALTER TABLE `works_hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `works_restaurant`
--

DROP TABLE IF EXISTS `works_restaurant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `works_restaurant` (
  `staID` int(11) unsigned NOT NULL,
  `restID` int(11) unsigned NOT NULL,
  `archived` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`staID`,`restID`),
  KEY `workAtRestaurant_idx` (`restID`),
  CONSTRAINT `staffRestaurant` FOREIGN KEY (`staID`) REFERENCES `staff` (`employeeID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `workAtRestaurant` FOREIGN KEY (`restID`) REFERENCES `restaurant` (`restaurantID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `works_restaurant`
--

LOCK TABLES `works_restaurant` WRITE;
/*!40000 ALTER TABLE `works_restaurant` DISABLE KEYS */;
INSERT INTO `works_restaurant` VALUES (116,613,0),(117,615,0),(118,615,0),(119,616,0),(131,613,0),(789,601,0);
/*!40000 ALTER TABLE `works_restaurant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `works_ride`
--

DROP TABLE IF EXISTS `works_ride`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `works_ride` (
  `staID` int(11) unsigned NOT NULL,
  `rID` int(11) unsigned NOT NULL,
  `archived` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`staID`,`rID`),
  KEY `workAtRide_idx` (`rID`),
  CONSTRAINT `staffRide` FOREIGN KEY (`staID`) REFERENCES `staff` (`employeeID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `workAtRide` FOREIGN KEY (`rID`) REFERENCES `rides` (`rideID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `works_ride`
--

LOCK TABLES `works_ride` WRITE;
/*!40000 ALTER TABLE `works_ride` DISABLE KEYS */;
INSERT INTO `works_ride` VALUES (109,401,0),(113,417,0),(121,403,0),(122,410,0),(123,411,0),(126,407,0),(132,417,0);
/*!40000 ALTER TABLE `works_ride` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'theme_park'
--

--
-- Dumping routines for database 'theme_park'
--
/*!50003 DROP PROCEDURE IF EXISTS `InsertClose` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertClose`(
    IN p_rideID INT(10),
    IN p_employeeID INT(10),
    IN p_date DATE,
    IN p_time TIME,
    IN p_type VARCHAR(45),
    IN p_cost INT(10)
)
BEGIN
	INSERT INTO closes (rideID, employeeID, date, time, type, cost) VALUES (p_closeID, p_rideID, p_employeeID, p_date, p_time, p_type, p_cost);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertHotel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertHotel`(
	IN p_hotelID INT(10),
	IN p_name VARCHAR(45),
	IN p_hlocID INT(6),
	IN p_capacity INT(11),
	IN p_rating INT(1),
    IN p_exp DOUBLE)
BEGIN
	INSERT INTO hotel (hotelID, name, h_locID, capacity, rating, h_expenditure)
	VALUES (p_hotelID, p_name, p_hlocID, p_capacity, p_rating, p_exp);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertRestaurant` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertRestaurant`(
	IN p_restaurantID INT(11),
    IN p_name VARCHAR(45),
    IN p_restlocID INT(6),
    IN p_capacity INT(11),
    IN p_exp DOUBLE
)
BEGIN
	INSERT INTO restaurant(restaurantID, name, rest_locID, capacity, r_expenditure) VALUES (p_restaurantID, p_name, p_restlocID, p_capacity, p_exp);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertRide` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertRide`(
	IN p_rideID INT(10),
    IN p_capacity INT(10),
    IN p_name VARCHAR(45),
    IN p_maxWeight INT(10),
    IN p_minHeight INT(10),
    IN p_minAge INT(10),
    IN p_rlocID INT(10)
)
BEGIN
	INSERT INTO rides(rideID, capacity, name, maxWeight, minHeight, minAge, r_locID) VALUES (p_rideID, p_capacity, p_name, p_maxWeight, p_minHeight, p_minAge, p_rlocID);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertStaff` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertStaff`(
	IN p_employeeID INT(11),
    IN p_firstName VARCHAR(45),
    IN p_lastName VARCHAR(45),
    IN p_gender CHAR(1),
    IN p_salary INT(10),
    IN p_category VARCHAR(45),
    IN p_email VARCHAR(45)
)
BEGIN
	INSERT INTO staff (employeeID, firstName, lastName, gender, weeklySalary, jobCategory, email) VALUES (p_employeeID, p_firstName, p_lastName, p_gender, p_salary, p_category, p_email);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertVisitHotel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertVisitHotel`(
	IN p_tickIDh INT(10),
    IN p_hotID INT(10),
    IN p_dateVisited DATE,
    IN p_amountSpent DOUBLE,
    IN p_daysStayed INT(11),
    IN p_roomNumber INT(11)
)
BEGIN
	INSERT INTO visit_hotel(tickID_h, hotID, dateVisited, amountSpent, daysStayed, roomNumber) VALUES (p_tickIDh, p_hotID, p_dateVisited, p_amountSpent, p_daysStayed, p_roomNumber);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertVisitor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertVisitor`(
	IN p_visitDate DATE, 
	IN p_month INT(2), 
	IN p_day INT(2), 
	IN p_year INT(4), 
	IN p_ticketType VARCHAR(16), 
	IN p_ticketCost DOUBLE, 
	IN p_email VARCHAR(45)
)
BEGIN
	INSERT INTO visitor(visitDate, month, day, year, ticketType, ticketCost, email) 
    VALUES (p_visitDate, p_month, p_day, p_year, p_ticketType, p_ticketCost, p_email);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertVisitRestaurant` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`courtney`@`%` PROCEDURE `InsertVisitRestaurant`(
	IN p_ticketIDr INT(10),
    IN p_restID INT(10),
    IN p_dateVisited DATE,
    IN p_amountSpent DOUBLE
)
BEGIN
	INSERT INTO visit_restaurant(tickID_r, restID, dateVisited, amountSpent) VALUES (p_ticketIDr, p_restID, p_dateVisited, p_amountSpent);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-24 18:01:34
