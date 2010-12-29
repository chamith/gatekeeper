ALTER TABLE `RoleRightAssignment`
DROP INDEX `fk_RoleRightAssignment_Role`,
DROP INDEX `fk_RoleRightAssignment_Right`,
DROP INDEX `fk_RoleRightAssignment_Application`,
DROP INDEX `fk_RoleRightAssignment_SecurableObjectType`;

