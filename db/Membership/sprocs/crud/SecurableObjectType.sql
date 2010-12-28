DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_SecurableObjectType_Select$$
CREATE PROCEDURE csp_SecurableObjectType_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM `SecurableObjectType`
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_SecurableObjectType_Insert$$
CREATE PROCEDURE csp_SecurableObjectType_Insert
(
	_name varchar(50),
	_description varchar(500),
	_applicationId bigint
)
BEGIN
	INSERT INTO `SecurableObjectType`
	(
		Name,
		Description,
		Applicationid
	)
	VALUES
	(
		_name,
		_description,
		_applicationId
	);

	SELECT *
	FROM `SecurableObjectType`
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_SecurableObjectType_Update$$
CREATE PROCEDURE csp_SecurableObjectType_Update
(
	_id bigint,
	_name varchar(50),
	_description varchar(500),
	_applicationId bigint
)
BEGIN
	UPDATE 	`SecurableObjectType`
	SET 	Name = _name,
		Description = _description,
		ApplicationId = _applicationId
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_SecurableObjectType_Delete$$
CREATE PROCEDURE csp_SecurableObjectType_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM `SecurableObjectType`
	WHERE Id = _id;
END$$

DELIMITER ;

