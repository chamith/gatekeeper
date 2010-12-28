CREATE TABLE `Role` (
  `Id` bigint  NOT NULL AUTO_INCREMENT,
  `Name` varchar(50)  NOT NULL,
  `Description` varchar(250)  NOT NULL,
  `ApplicationId` bigint NOT NULL,
  `SecurableObjectTypeId` bigint NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = InnoDB;

