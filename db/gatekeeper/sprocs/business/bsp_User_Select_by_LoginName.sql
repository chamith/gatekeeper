DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_User_Select_by_LoginName$$
CREATE PROCEDURE bsp_User_Select_by_LoginName
(
	_loginName varchar(50)
)
BEGIN
	SELECT * 
	FROM `User`
	WHERE LoginName = _loginName;
END$$

DELIMITER ;
