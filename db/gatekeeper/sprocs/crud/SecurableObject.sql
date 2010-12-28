DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_SecurableObject_Select$$
CREATE PROCEDURE csp_SecurableObject_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM `SecurableObject`
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_SecurableObject_Insert$$
CREATE PROCEDURE csp_SecurableObject_Insert
(
	_guid char(36),
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	INSERT INTO `SecurableObject`
	(
		Guid,
		Applicationid,
		SecurableObjectTypeId
	)
	VALUES
	(
		_guid,
		_applicationId,
		_securableObjectTypeId
	);

	SELECT *
	FROM `SecurableObject`
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_SecurableObject_Update$$
CREATE PROCEDURE csp_SecurableObject_Update
(
	_id bigint,
	_guid char(36),
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	UPDATE 	`SecurableObject`
	SET 	Guid = _guid,
		ApplicationId = _applicationId,
		SecurableObjectTypeId = _securableObjectTypeId
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_SecurableObject_Delete$$
CREATE PROCEDURE csp_SecurableObject_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM `SecurableObject`
	WHERE Id = _id;
END$$

DELIMITER ;

