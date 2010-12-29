ALTER TABLE `SecurableObjectType`
ADD CONSTRAINT `fk_SecurableObjectType_Application`
    FOREIGN KEY (`ApplicationId` )
    REFERENCES `Application` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;
