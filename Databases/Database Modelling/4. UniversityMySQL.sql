CREATE DATABASE  IF NOT EXISTS `university` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `university`;
-- MySQL dump 10.13  Distrib 5.6.12, for Win64 (x86_64)
--
-- Host: localhost    Database: university
-- ------------------------------------------------------
-- Server version	5.6.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) DEFAULT NULL,
  `DepartmentId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Courses_Departments1_idx` (`DepartmentId`),
  CONSTRAINT `fk_Courses_Departments1` FOREIGN KEY (`DepartmentId`) REFERENCES `departments` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES (1,'Fundamentals of nuclear engineering',1),(2,'Statistics',2),(3,'Observational microbiology',5),(4,'Ancient Egyptian History and Culture',9),(6,'Functional Programming',8);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `FacultyId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Departments_Faculties_idx` (`FacultyId`),
  CONSTRAINT `fk_Departments_Faculties` FOREIGN KEY (`FacultyId`) REFERENCES `faculties` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (1,'Nuclear physics',1),(2,'Applied mathematics',2),(3,'Quantum physics',1),(5,'Microbiology',4),(6,'Histology',4),(8,'Informatics',2),(9,'Ancient history',3),(10,'History of Europe',3);
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
INSERT INTO `faculties` VALUES (1,'Physics'),(2,'Mathematics'),(3,'History'),(4,'Biology');
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(75) NOT NULL,
  `LastName` varchar(75) NOT NULL,
  `DepartmentId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
INSERT INTO `professors` VALUES (7,'John','Morrison',1),(8,'Matthew','Dowes',2),(9,'Peter','Stein',5),(10,'George','Samuel',8);
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professorscourses`
--

DROP TABLE IF EXISTS `professorscourses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professorscourses` (
  `ProfessorId` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL,
  PRIMARY KEY (`ProfessorId`,`CourseId`),
  KEY `fk_ProfessorsCourses_Courses1_idx` (`CourseId`),
  KEY `fk_ProfessorsCourses_Professors1_idx` (`ProfessorId`),
  CONSTRAINT `fk_ProfessorsCourses_Courses1` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsCourses_Professors1` FOREIGN KEY (`ProfessorId`) REFERENCES `professors` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professorscourses`
--

LOCK TABLES `professorscourses` WRITE;
/*!40000 ALTER TABLE `professorscourses` DISABLE KEYS */;
INSERT INTO `professorscourses` VALUES (7,1),(8,2),(9,2),(7,3),(9,3);
/*!40000 ALTER TABLE `professorscourses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professorstitles`
--

DROP TABLE IF EXISTS `professorstitles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professorstitles` (
  `ProfessorId` int(11) NOT NULL,
  `TitleId` int(11) NOT NULL,
  PRIMARY KEY (`ProfessorId`,`TitleId`),
  KEY `fk_ProfessorsTitles_Professors1_idx` (`ProfessorId`),
  KEY `fk_ProfessorsTitles_Titles1_idx` (`TitleId`),
  CONSTRAINT `fk_ProfessorsTitles_Professors1` FOREIGN KEY (`ProfessorId`) REFERENCES `professors` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsTitles_Titles1` FOREIGN KEY (`TitleId`) REFERENCES `titles` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professorstitles`
--

LOCK TABLES `professorstitles` WRITE;
/*!40000 ALTER TABLE `professorstitles` DISABLE KEYS */;
INSERT INTO `professorstitles` VALUES (7,1),(7,3),(8,1),(8,3),(9,2),(9,4),(10,4);
/*!40000 ALTER TABLE `professorstitles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(75) DEFAULT NULL,
  `LastName` varchar(75) NOT NULL,
  `FacultyId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Students_Faculties1_idx` (`FacultyId`),
  CONSTRAINT `fk_Students_Faculties1` FOREIGN KEY (`FacultyId`) REFERENCES `faculties` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (2,'John','Simons',3),(4,'Michael','Collins',1),(5,'Leslie','Bartson',2),(6,'George','Tower',4),(7,'Mary','Wellington',2),(8,'Nathan','Dowes',1),(9,'Anne','Roberts',4),(10,'Daniel','Buren',3);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studentscourses`
--

DROP TABLE IF EXISTS `studentscourses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `studentscourses` (
  `StudentId` int(11) NOT NULL,
  `CourseId` int(11) NOT NULL,
  PRIMARY KEY (`StudentId`,`CourseId`),
  KEY `fk_StudentsCourses_Students1_idx` (`StudentId`),
  KEY `fk_StudentsCourses_Courses1_idx` (`CourseId`),
  CONSTRAINT `fk_StudentsCourses_Courses1` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentsCourses_Students1` FOREIGN KEY (`StudentId`) REFERENCES `students` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studentscourses`
--

LOCK TABLES `studentscourses` WRITE;
/*!40000 ALTER TABLE `studentscourses` DISABLE KEYS */;
INSERT INTO `studentscourses` VALUES (2,4),(4,1),(4,2),(4,6),(7,6);
/*!40000 ALTER TABLE `studentscourses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
INSERT INTO `titles` VALUES (1,'Assistant Professor'),(2,'Chief Assistant Professor'),(3,'Associate Professor'),(4,'Full Professor');
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-14 18:10:54
