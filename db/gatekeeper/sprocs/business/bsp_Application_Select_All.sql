DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_Application_Select_All$$
CREATE PROCEDURE bsp_Application_Select_All
(
)
BEGIN
	SELECT * 
	FROM Application;
END$$

DELIMITER ;

