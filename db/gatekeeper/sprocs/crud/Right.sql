DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_Right_Select$$
CREATE PROCEDURE csp_Right_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM `Right`
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_Right_Insert$$
CREATE PROCEDURE csp_Right_Insert
(
	_name varchar(50),
	_description varchar(500),
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	INSERT INTO `Right`
	(
		Name,
		Description,
		Applicationid,
		SecurableObjectTypeId
	)
	VALUES
	(
		_name,
		_description,
		_applicationId,
		_securableObjectTypeId
	);

	SELECT *
	FROM `Right`
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_Right_Update$$
CREATE PROCEDURE csp_Right_Update
(
	_id bigint,
	_name varchar(50),
	_description varchar(500),
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	UPDATE 	`Right`
	SET 	Name = _name,
		Description = _description,
		ApplicationId = _applicationId,
		SecurableObjectTypeId = _securableObjectTypeId
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_Right_Delete$$
CREATE PROCEDURE csp_Right_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM `Right`
	WHERE Id = _id;
END$$

DELIMITER ;

