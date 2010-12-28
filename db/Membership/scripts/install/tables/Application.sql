CREATE TABLE `Application` (
  `Id` bigint  NOT NULL AUTO_INCREMENT,
  `Guid` char(36)  NOT NULL,
  `Name` varchar(50)  NOT NULL,
  `Description` varchar(500) ,
  PRIMARY KEY (`Id`)
)
ENGINE = InnoDB;

