ALTER TABLE `RoleRightAssignment`
DROP FOREIGN KEY `fk_RoleRightAssignment_Role`,
DROP FOREIGN KEY `fk_RoleRightAssignment_Right`,
DROP FOREIGN KEY `fk_RoleRightAssignment_Application`,
DROP FOREIGN KEY `fk_RoleRightAssignment_SecurableObjectType`;
