ALTER TABLE `RoleRightAssignment`
ADD CONSTRAINT `fk_RoleRightAssignment_Role`
    FOREIGN KEY (`RoleId` )
    REFERENCES `Role` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_RoleRightAssignment_Right`
    FOREIGN KEY (`RightId` )
    REFERENCES `Right` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_RoleRightAssignment_Application`
    FOREIGN KEY (`ApplicationId` )
    REFERENCES `Application` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_RoleRightAssignment_SecurableObjectType`
    FOREIGN KEY (`SecurableObjectTypeId` )
    REFERENCES `SecurableObjectType` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
