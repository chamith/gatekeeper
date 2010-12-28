CREATE TABLE `SecurableObject` (
  `Id` bigint  NOT NULL AUTO_INCREMENT,
  `Guid` char(36)  NOT NULL,
  `ApplicationId` bigint NOT NULL,
  `SecurableObjectTypeId` bigint NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = InnoDB;

