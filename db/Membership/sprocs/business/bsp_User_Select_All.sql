DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_User_Select_All$$
CREATE PROCEDURE bsp_User_Select_All
(
)
BEGIN
	SELECT * 
	FROM `User`;
END$$

DELIMITER ;
