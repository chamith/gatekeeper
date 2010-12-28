CREATE TABLE `RoleRightAssignment` (
  `Id` bigint  NOT NULL AUTO_INCREMENT,
  `RoleId` bigint  NOT NULL,
  `RightId` bigint  NOT NULL,
  `ApplicationId` bigint NOT NULL,
  `SecurableObjectTypeId` bigint NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = InnoDB;

