CREATE INDEX `fk_RoleRightAssignment_Role` ON `RoleRightAssignment` (`RoleId` ASC) ;
CREATE INDEX `fk_RoleRightAssignment_Right` ON `RoleRightAssignment` (`RightId` ASC) ;
CREATE INDEX `fk_RoleRightAssignment_Application` ON `RoleRightAssignment` (`ApplicationId` ASC) ;
CREATE INDEX `fk_RoleRightAssignment_SecurableObjectType` ON `RoleRightAssignment` (`SecurableObjectTypeId` ASC) ;
