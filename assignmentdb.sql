-- MySQL dump 10.13  Distrib 5.7.16, for Win32 (AMD64)
--
-- Host: localhost    Database: assignmentdb
-- ------------------------------------------------------
-- Server version	5.7.16-log

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
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project` (
  `name` varchar(45) NOT NULL,
  `code_name` varchar(45) DEFAULT NULL,
  `description` varchar(250) DEFAULT NULL,
  `poss_start_date` varchar(45) DEFAULT NULL,
  `poss_end_date` varchar(45) DEFAULT NULL,
  `duration` int(11) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
INSERT INTO `project` VALUES ('Library Management System','LSM','A software to manage all the work of a Library.','30/11/2017','30/12/2017',30,'Not-Started'),('Online Recruitment System','ORS','An online system to recruit employee.','30/11/2017','30/12/2017',30,'Not-Started'),('Project Management System','PSM','A software to manage all the work of a software firm.','27/11/2017','29/11/2017',2,'Started'),('Student Management System','LMS','A software to manage all the work of a School.','26/09/2017','23/11/2017',58,'Not-Started');
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resperson`
--

DROP TABLE IF EXISTS `resperson`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `resperson` (
  `project_name` varchar(45) NOT NULL,
  `res_person` varchar(45) DEFAULT NULL,
  `designation` varchar(45) DEFAULT NULL,
  `assigned_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resperson`
--

LOCK TABLES `resperson` WRITE;
/*!40000 ALTER TABLE `resperson` DISABLE KEYS */;
INSERT INTO `resperson` VALUES ('Project Management System','Avijit Hazra','Developer','Nazrul Islam'),('Project Management System','Fahim Ruhi','UX Engineer ','Nazrul Islam'),('Project Management System','Shiddiki','QA Engineer','Nazrul Islam'),('Library Management System','Avijit Hazra','Developer','Nazrul Islam'),('Library Management System','Shiddiki','QA Engineer','Nazrul Islam'),('Student Management System','Fahim Ruhi','UX Engineer ','Nazrul Islam'),('Student Management System','Shiddiki','QA Engineer','Nazrul Islam'),('Online Recruitment System','Nazrul Islam','Team Lead','Sujit Kumar Chanda'),('Online Recruitment System','Fahim Ruhi','UX Engineer ','Sujit Kumar Chanda'),('Online Recruitment System','Avijit Hazra','Developer','Sujit Kumar Chanda');
/*!40000 ALTER TABLE `resperson` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `task` (
  `project_name` varchar(45) DEFAULT NULL,
  `assignto` varchar(45) DEFAULT NULL,
  `description` varchar(250) DEFAULT NULL,
  `due_date` varchar(45) DEFAULT NULL,
  `priority` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task`
--

LOCK TABLES `task` WRITE;
/*!40000 ALTER TABLE `task` DISABLE KEYS */;
INSERT INTO `task` VALUES ('Project Management System','Avijit Hazra','Do simple code for login','30/11/2017','High'),('Project Management System','Fahim Ruhi','Do good design.','30/11/2017','High'),('Project Management System','Shiddiki','Test the code sincerely.','30/11/2017','High'),('Student Management System','Shiddiki','Test the code sincerely.','30/11/2017','High'),('Student Management System','Fahim Ruhi','Make a good design of the system.','30/11/2017','Medium');
/*!40000 ALTER TABLE `task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task_comment`
--

DROP TABLE IF EXISTS `task_comment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `task_comment` (
  `comment` varchar(250) DEFAULT NULL,
  `comment_by` varchar(45) DEFAULT NULL,
  `comment_time` varchar(45) DEFAULT NULL,
  `project_name` varchar(45) DEFAULT NULL,
  `task` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task_comment`
--

LOCK TABLES `task_comment` WRITE;
/*!40000 ALTER TABLE `task_comment` DISABLE KEYS */;
INSERT INTO `task_comment` VALUES ('Submit with in deadline.','Avijit Hazra','29/11/2017 20:30:26','Project Management System','Do simple code for login'),('Submit with in deadline.','Avijit Hazra','29/11/2017 20:30:35','Project Management System','Do good design.'),('Submit with in deadline.','Avijit Hazra','29/11/2017 20:30:38','Project Management System','Test the code sincerely.'),('Submit with in deadline.','Avijit Hazra','29/11/2017 20:30:48','Student Management System','Make a good design of the system.'),('Submit with in deadline.','Avijit Hazra','29/11/2017 20:30:52','Student Management System','Test the code sincerely.');
/*!40000 ALTER TABLE `task_comment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `name` varchar(45) DEFAULT NULL,
  `email` varchar(45) NOT NULL,
  `default_pass` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `designation` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('Avijit Hazra','Avijit@gmail.com','Avijit@gmail.com123','active','Developer'),('Fahim Ruhi','fahim@gmail.com','fahim@gmail.com123','inactive','UX Engineer '),('Nazrul Islam','nazrulcse@gmail.com','nazrulcse@gmail.com123','inactive','Team Lead'),('Shiddiki','shiddiki@gmail.com','shiddiki@gmail.com123','active','QA Engineer'),('Sujit Kumar Chanda','sujitcsecuet12@gmail.com','sujitcsecuet12@gmail.com123','active','Project Manager');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-11-29 22:55:07
