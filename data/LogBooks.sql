/*
SQLyog  v12.2.6 (64 bit)
MySQL - 5.6.17 : Database - LogBooks
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`LogBooks` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `LogBooks`;

/*Table structure for table `Project` */

DROP TABLE IF EXISTS `Project`;

CREATE TABLE `Project` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `Pnumber` varchar(32) DEFAULT NULL,
  `Item` int(11) DEFAULT NULL,
  `Pname` varchar(255) DEFAULT NULL,
  `CustomerID` varchar(32) DEFAULT NULL,
  `CustomerName` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `MProperty` varchar(255) DEFAULT NULL,
  `DDepartment1` varchar(32) DEFAULT NULL,
  `DDepartment2` varchar(32) DEFAULT NULL,
  `Design1` varchar(32) DEFAULT NULL,
  `Design2` varchar(32) DEFAULT NULL,
  `DelFlag` smallint(6) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PK_Project` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1209 DEFAULT CHARSET=utf8;

/*Data for the table `Project` */


/*Table structure for table `Users` */

DROP TABLE IF EXISTS `Users`;

CREATE TABLE `Users` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `UName` varchar(32) NOT NULL,
  `UPwd` varchar(16) NOT NULL,
  `RegTime` datetime NOT NULL,
  `DelFlag` smallint(6) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PK_Users` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `Users` */

insert  into `Users`(`ID`,`UName`,`UPwd`,`RegTime`,`DelFlag`) values (1,'admin','1','2017-07-20 08:53:09',0);

/*Table structure for table `WorkLogs` */

DROP TABLE IF EXISTS `WorkLogs`;

CREATE TABLE `WorkLogs` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `Pnumber` varchar(32) DEFAULT NULL,
  `Item` int(10) DEFAULT NULL,
  `Pname` varchar(255) DEFAULT NULL,
  `UID` int(10) NOT NULL,
  `CreateTime` datetime NOT NULL,
  `LogDesc` text NOT NULL,
  `DelFlag` smallint(6) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `PK_WorkLogs` (`ID`),
  KEY `UID` (`UID`),
  CONSTRAINT `worklogs_ibfk_1` FOREIGN KEY (`UID`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `WorkLogs` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
