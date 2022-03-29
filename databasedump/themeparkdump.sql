CREATE DATABASE  IF NOT EXISTS `theme_park` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `theme_park`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: theme_park
-- ------------------------------------------------------
-- Server version	8.0.28

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
  `rideID` int unsigned NOT NULL,
  `employeeID` int unsigned NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `type` varchar(45) NOT NULL,
  PRIMARY KEY (`rideID`,`employeeID`),
  KEY `staffClosing_idx` (`employeeID`),
  CONSTRAINT `rideClosed` FOREIGN KEY (`rideID`) REFERENCES `rides` (`rideID`),
  CONSTRAINT `staffClosing` FOREIGN KEY (`employeeID`) REFERENCES `staff` (`employeeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `closes`
--

LOCK TABLES `closes` WRITE;
/*!40000 ALTER TABLE `closes` DISABLE KEYS */;
/*!40000 ALTER TABLE `closes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hotel`
--

DROP TABLE IF EXISTS `hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hotel` (
  `hotelID` int unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `location` varchar(45) NOT NULL,
  `petsAllowed` bit(1) NOT NULL,
  `capacity` int DEFAULT NULL,
  `rating` int DEFAULT NULL,
  `totalHotelMaintenanceCost` double DEFAULT NULL,
  PRIMARY KEY (`hotelID`),
  UNIQUE KEY `hotelID_UNIQUE` (`hotelID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hotel`
--

LOCK TABLES `hotel` WRITE;
/*!40000 ALTER TABLE `hotel` DISABLE KEYS */;
/*!40000 ALTER TABLE `hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maintenance`
--

DROP TABLE IF EXISTS `maintenance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `maintenance` (
  `maintenanceID` int NOT NULL,
  `maintenanceTime` datetime NOT NULL,
  `maintenanceCost` double NOT NULL,
  `numRidesBroken` int DEFAULT NULL,
  `RideMaintained` int unsigned DEFAULT NULL,
  `CostOfRideMaintenance` double DEFAULT NULL,
  PRIMARY KEY (`maintenanceID`),
  UNIQUE KEY `maintenanceID_UNIQUE` (`maintenanceID`),
  KEY `RideWorkedOn_idx` (`RideMaintained`),
  CONSTRAINT `RideWorkedOn` FOREIGN KEY (`RideMaintained`) REFERENCES `rides` (`rideID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maintenance`
--

LOCK TABLES `maintenance` WRITE;
/*!40000 ALTER TABLE `maintenance` DISABLE KEYS */;
/*!40000 ALTER TABLE `maintenance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `restaurant`
--

DROP TABLE IF EXISTS `restaurant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `restaurant` (
  `restaurauntID` int NOT NULL,
  `name` varchar(45) NOT NULL,
  `location` varchar(45) NOT NULL,
  `numVisitors` int NOT NULL DEFAULT '0',
  `capacity` int DEFAULT NULL,
  `totalRestMaintenanceCost` double DEFAULT NULL,
  PRIMARY KEY (`restaurauntID`),
  UNIQUE KEY `restaurauntID_UNIQUE` (`restaurauntID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `restaurant`
--

LOCK TABLES `restaurant` WRITE;
/*!40000 ALTER TABLE `restaurant` DISABLE KEYS */;
/*!40000 ALTER TABLE `restaurant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rides`
--

DROP TABLE IF EXISTS `rides`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rides` (
  `rideID` int unsigned NOT NULL,
  `capacity` int unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `maxWeight` int unsigned NOT NULL,
  `minHeight` int unsigned NOT NULL,
  `minAge` int unsigned NOT NULL,
  `location` varchar(45) NOT NULL,
  PRIMARY KEY (`rideID`),
  UNIQUE KEY `rideID_UNIQUE` (`rideID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rides`
--

LOCK TABLES `rides` WRITE;
/*!40000 ALTER TABLE `rides` DISABLE KEYS */;
/*!40000 ALTER TABLE `rides` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `employeeID` int unsigned NOT NULL,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `jobDescription` varchar(45) NOT NULL,
  `gender` char(1) NOT NULL,
  `weeklySalary` int unsigned NOT NULL,
  `jobCategory` varchar(45) NOT NULL,
  `maintainsRide` int unsigned DEFAULT NULL,
  `workAtRide` int unsigned DEFAULT NULL,
  `workAtRestaurant` int unsigned DEFAULT NULL,
  `workAtHotel` int unsigned DEFAULT NULL,
  PRIMARY KEY (`employeeID`),
  UNIQUE KEY `employeeID_UNIQUE` (`employeeID`),
  KEY `mainainsRide_idx` (`maintainsRide`),
  KEY `worksAtRide_idx` (`workAtRide`),
  KEY `worksAtHotel_idx` (`workAtHotel`),
  CONSTRAINT `mainainsRide` FOREIGN KEY (`maintainsRide`) REFERENCES `rides` (`rideID`),
  CONSTRAINT `worksAtHotel` FOREIGN KEY (`workAtHotel`) REFERENCES `hotel` (`hotelID`),
  CONSTRAINT `worksAtRide` FOREIGN KEY (`workAtRide`) REFERENCES `rides` (`rideID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visit_hotel`
--

DROP TABLE IF EXISTS `visit_hotel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visit_hotel` (
  `amountSpent` double NOT NULL DEFAULT '0',
  `daysStayed` int NOT NULL,
  `roomNumber` int NOT NULL,
  `hotelVisit` int unsigned DEFAULT NULL,
  KEY `hotelVisited_idx` (`hotelVisit`),
  CONSTRAINT `hotelVisited` FOREIGN KEY (`hotelVisit`) REFERENCES `hotel` (`hotelID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visit_hotel`
--

LOCK TABLES `visit_hotel` WRITE;
/*!40000 ALTER TABLE `visit_hotel` DISABLE KEYS */;
/*!40000 ALTER TABLE `visit_hotel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visit_restaurant`
--

DROP TABLE IF EXISTS `visit_restaurant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visit_restaurant` (
  `restVisited` int DEFAULT NULL,
  `ticketID` int NOT NULL,
  `amountSpent` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`ticketID`),
  UNIQUE KEY `ticketID_UNIQUE` (`ticketID`),
  UNIQUE KEY `restaurantID_UNIQUE` (`restVisited`),
  KEY `visitorTicket_idx` (`ticketID`),
  CONSTRAINT `restaurantVisited` FOREIGN KEY (`restVisited`) REFERENCES `restaurant` (`restaurauntID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `visitorTicketR` FOREIGN KEY (`ticketID`) REFERENCES `visitor` (`ticketID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visit_restaurant`
--

LOCK TABLES `visit_restaurant` WRITE;
/*!40000 ALTER TABLE `visit_restaurant` DISABLE KEYS */;
/*!40000 ALTER TABLE `visit_restaurant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visitor`
--

DROP TABLE IF EXISTS `visitor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visitor` (
  `ticketID` int NOT NULL,
  `visitDate` date NOT NULL,
  `month` int NOT NULL,
  `day` int NOT NULL,
  `year` int NOT NULL,
  `ticketType` varchar(16) NOT NULL,
  `ticketCost` double NOT NULL,
  `RideVisit` int unsigned DEFAULT NULL,
  PRIMARY KEY (`ticketID`),
  UNIQUE KEY `ticketID_UNIQUE` (`ticketID`),
  KEY `rideVisited_idx` (`RideVisit`),
  CONSTRAINT `rideVisited` FOREIGN KEY (`RideVisit`) REFERENCES `rides` (`rideID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visitor`
--

LOCK TABLES `visitor` WRITE;
/*!40000 ALTER TABLE `visitor` DISABLE KEYS */;
/*!40000 ALTER TABLE `visitor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-11 20:54:09
