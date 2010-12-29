ALTER TABLE `UserRoleAssignment`
ADD CONSTRAINT `fk_UserRoleAssignment_User`
    FOREIGN KEY (`UserId` )
    REFERENCES `User` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_UserRoleAssignment_Role`
    FOREIGN KEY (`RoleId` )
    REFERENCES `Role` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_UserRoleAssignment_Application`
    FOREIGN KEY (`ApplicationId` )
    REFERENCES `Application` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_UserRoleAssignment_SecurableObject`
    FOREIGN KEY (`SecurableObjectId` )
    REFERENCES `SecurableObject` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
