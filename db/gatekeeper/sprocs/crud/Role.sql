DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_Role_Select$$
CREATE PROCEDURE csp_Role_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM `Role`
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_Role_Insert$$
CREATE PROCEDURE csp_Role_Insert
(
	_name varchar(50),
	_description varchar(500),
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	INSERT INTO `Role`
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
	FROM `Role`
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_Role_Update$$
CREATE PROCEDURE csp_Role_Update
(
	_id bigint,
	_name varchar(50),
	_description varchar(500),
	_applicationId bigint,
	_securableObjectTypeId bigint
)
BEGIN
	UPDATE 	`Role`
	SET 	Name = _name,
		Description = _description,
		ApplicationId = _applicationId,
		SecurableObjectTypeId = _securableObjectTypeId
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_Role_Delete$$
CREATE PROCEDURE csp_Role_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM `Role`
	WHERE Id = _id;
END$$

DELIMITER ;

