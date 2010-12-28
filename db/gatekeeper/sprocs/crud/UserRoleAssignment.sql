DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_UserRoleAssignment_Select$$
CREATE PROCEDURE csp_UserRoleAssignment_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM `UserRoleAssignment`
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_UserRoleAssignment_Insert$$
CREATE PROCEDURE csp_UserRoleAssignment_Insert
(
	_roleId bigint,
	_userId bigint,
	_applicationId bigint,
	_securableObjectId bigint
)
BEGIN
	INSERT INTO `UserRoleAssignment`
	(
		RoleId,
		UserId,
		Applicationid,
		SecurableObjectId
	)
	VALUES
	(
		_roleId,
		_userId,
		_applicationId,
		_securableObjectId
	);

	SELECT *
	FROM `UserRoleAssignment`
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_UserRoleAssignment_Update$$
CREATE PROCEDURE csp_UserRoleAssignment_Update
(
	_id bigint,
	_roleId bigint,
	_userId bigint,
	_applicationId bigint,
	_securableObjectId bigint
)
BEGIN
	UPDATE 	`UserRoleAssignment`
	SET 	RoleId = _roleId,
		UserId = _userId,
		ApplicationId = _applicationId,
		SecurableObjectId = _securableObjectId
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_UserRoleAssignment_Delete$$
CREATE PROCEDURE csp_UserRoleAssignment_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM `UserRoleAssignment`
	WHERE Id = _id;
END$$

DELIMITER ;

