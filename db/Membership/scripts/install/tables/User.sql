CREATE TABLE `User` (
  `Id` bigint  NOT NULL AUTO_INCREMENT,
  `LoginName` varchar(50)  NOT NULL,
  `FirstName` varchar(50)  NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `PasswordSalt` varchar(128) NOT NULL,
  `PasswordHash` varchar(128) NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = InnoDB;

