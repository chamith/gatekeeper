CREATE TABLE `ApplicationUser` (
  `Id` bigint  NOT NULL AUTO_INCREMENT,
  `ApplicationId` bigint  NOT NULL,
  `UserId` bigint  NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = InnoDB;

