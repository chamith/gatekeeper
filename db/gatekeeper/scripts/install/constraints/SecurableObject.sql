ALTER TABLE `SecurableObject`
ADD CONSTRAINT `fk_SecurableObject_Application`
    FOREIGN KEY (`ApplicationId` )
    REFERENCES `Application` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_SecurableObject_SecurableObjectType`
    FOREIGN KEY (`SecurableObjectTypeId` )
    REFERENCES `SecurableObjectType` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

