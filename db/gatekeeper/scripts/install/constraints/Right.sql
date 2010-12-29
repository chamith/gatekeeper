ALTER TABLE `Right`
ADD CONSTRAINT `fk_Right_Application`
    FOREIGN KEY (`ApplicationId` )
    REFERENCES `Application` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Right_SecurableObjectType`
    FOREIGN KEY (`SecurableObjectTypeId` )
    REFERENCES `SecurableObjectType` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
