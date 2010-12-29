ALTER TABLE `ApplicationUser` 
ADD CONSTRAINT `fk_ApplicationUser_Application`
    FOREIGN KEY (`ApplicationId` )
    REFERENCES `Application` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_ApplicationUser_User`
    FOREIGN KEY (`UserId` )
    REFERENCES `User` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION;

