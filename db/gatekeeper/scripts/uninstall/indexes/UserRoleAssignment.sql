ALTER TABLE `UserRoleAssignment`
DROP INDEX `fk_UserRoleAssignment_User`,
DROP INDEX `fk_UserRoleAssignment_Role`,
DROP INDEX `fk_UserRoleAssignment_Application`,
DROP INDEX `fk_UserRoleAssignment_SecurableObject`;

