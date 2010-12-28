DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_ApplicationUser_Select$$
CREATE PROCEDURE csp_ApplicationUser_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM ApplicationUser
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_ApplicationUser_Insert$$
CREATE PROCEDURE csp_ApplicationUser_Insert
(
	_applicationId bigint,
	_userId bigint
)
BEGIN
	INSERT INTO ApplicationUser
	(
		ApplicationId,
		UserId
	)
	VALUES
	(
		_applicationId,
		_userId
	);

	SELECT *
	FROM ApplicationUser
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_ApplicationUser_Update$$
CREATE PROCEDURE csp_ApplicationUser_Update
(
	_id bigint,
	_applicationId bigint,
	_userId bigint
)
BEGIN
	UPDATE 	ApplicationUser
	SET 	ApplicationId = _applicationId,
		UserId = _userId
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_ApplicationUser_Delete$$
CREATE PROCEDURE csp_ApplicationUser_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM ApplicationUser
	WHERE Id = _id;
END$$

DELIMITER ;

