CREATE TABLE `UserRoleAssignment` (
  `Id` bigint  NOT NULL AUTO_INCREMENT,
  `RoleId` bigint  NOT NULL,
  `UserId` bigint  NOT NULL,
  `ApplicationId` bigint NOT NULL,
  `SecurableObjectId` bigint NOT NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = InnoDB;

