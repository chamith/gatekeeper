DELIMITER $$

-- Update --
DROP PROCEDURE IF EXISTS bsp_User_Update_Details$$
CREATE PROCEDURE bsp_User_Update_Details
(
	_id bigint,
	_loginName varchar(50),
	_firstName varchar(50),
	_lastName varchar(50)
)
BEGIN
	UPDATE 	`User`
	SET 	LoginName = _loginName,
		FirstName = _firstName,
		LastName = _lastName
	WHERE	Id = _id;
END$$

DELIMITER ;

