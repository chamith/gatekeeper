CREATE INDEX `fk_UserRoleAssignment_User` ON `UserRoleAssignment` (`UserId` ASC) ;
CREATE INDEX `fk_UserRoleAssignment_Role` ON `UserRoleAssignment` (`RoleId` ASC) ;
CREATE INDEX `fk_UserRoleAssignment_Application` ON `UserRoleAssignment` (`ApplicationId` ASC) ;
CREATE INDEX `fk_UserRoleAssignment_SecurableObject` ON `UserRoleAssignment` (`SecurableObjectId` ASC) ;
