DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_Application_Select$$
CREATE PROCEDURE csp_Application_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM Application
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_Application_Insert$$
CREATE PROCEDURE csp_Application_Insert
(
	_guid char(36),
	_name varchar(50),
	_description varchar(500)
)
BEGIN
	INSERT INTO Application
	(
		Guid,
		Name,
		Description
	)
	VALUES
	(
		_guid,
		_name,
		_description
	);

	SELECT *
	FROM Application
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_Application_Update$$
CREATE PROCEDURE csp_Application_Update
(
	_id bigint,
	_guid char(36),
	_name varchar(50),
	_description varchar(500)
)
BEGIN
	UPDATE 	Application
	SET 	Guid = _guid,
		Name = _name,
		Description = _description
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_Application_Delete$$
CREATE PROCEDURE csp_Application_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM Application
	WHERE Id = _id;
END$$

DELIMITER ;

