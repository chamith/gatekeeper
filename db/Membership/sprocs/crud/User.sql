DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS csp_User_Select$$
CREATE PROCEDURE csp_User_Select
(
	_id bigint
)
BEGIN
	SELECT * 
	FROM `User`
	WHERE Id = _id;
END$$

-- Insert --
DROP PROCEDURE IF EXISTS csp_User_Insert$$
CREATE PROCEDURE csp_User_Insert
(
	_loginName varchar(50),
	_firstName varchar(50),
	_lastName varchar(50),
	_passwordSalt varchar(128),
	_passwordHash varchar(128)
)
BEGIN
	INSERT INTO `User`
	(
		LoginName,
		FirstName,
		LastName,
		PasswordSalt,
		PasswordHash
	)
	VALUES
	(
		_loginName,
		_firstName,
		_lastName,
		_passwordSalt,
		_passwordHash
	);

	SELECT *
	FROM `User`
	WHERE Id = last_insert_id();	
	
END$$

-- Update --
DROP PROCEDURE IF EXISTS csp_User_Update$$
CREATE PROCEDURE csp_User_Update
(
	_id bigint,
	_loginName varchar(50),
	_firstName varchar(50),
	_lastName varchar(50),
	_passwordSalt varchar(128),
	_passwordHash varchar(128)
)
BEGIN
	UPDATE 	`User`
	SET 	LoginName = _loginName,
		FirstName = _firstName,
		LastName = _lastName,
		PasswordSalt = _passwordSalt,
		PasswordHash = _passwordHash
	WHERE	Id = _id;
END$$

-- Delete --
DROP PROCEDURE IF EXISTS csp_User_Delete$$
CREATE PROCEDURE csp_User_Delete
(
	_id bigint
)
BEGIN
	DELETE FROM `User`
	WHERE Id = _id;
END$$

DELIMITER ;

