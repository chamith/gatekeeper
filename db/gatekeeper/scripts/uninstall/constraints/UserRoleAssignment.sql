ALTER TABLE `UserRoleAssignment`
DROP FOREIGN KEY `fk_UserRoleAssignment_User`,
DROP FOREIGN KEY `fk_UserRoleAssignment_Role`,
DROP FOREIGN KEY `fk_UserRoleAssignment_Application`,
DROP FOREIGN KEY `fk_UserRoleAssignment_SecurableObject`;

