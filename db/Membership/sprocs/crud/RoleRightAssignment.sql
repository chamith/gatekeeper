DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_RoleRightAssignment_Select$$
CREATE PROCEDURE csp_RoleRightAssignment_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM `RoleRightAssignment`
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_RoleRightAssignment_Insert$$
CREATE PROCEDURE csp_RoleRightAssignment_Insert
(
	_roleId bigint,
	_rightId bigint,
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	INSERT INTO `RoleRightAssignment`
	(
		RoleId,
		RightId,
		Applicationid,
		SecurableObjectTypeId
	)
	VALUES
	(
		_roleId,
		_rightId,
		_applicationId,
		_securableObjectTypeId
	);

	SELECT *
	FROM `RoleRightAssignment`
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_RoleRightAssignment_Update$$
CREATE PROCEDURE csp_RoleRightAssignment_Update
(
	_id bigint,
	_roleId bigint,
	_rightId bigint,
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	UPDATE 	`RoleRightAssignment`
	SET 	RoleId = _roleId,
		RightId = _rightId,
		ApplicationId = _applicationId,
		SecurableObjectTypeId = _securableObjectTypeId
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_RoleRightAssignment_Delete$$
CREATE PROCEDURE csp_RoleRightAssignment_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM `RoleRightAssignment`
	WHERE Id = _id;
END$$

DELIMITER ;

