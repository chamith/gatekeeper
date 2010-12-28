DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_Application_Select_by_Guid$$
CREATE PROCEDURE bsp_Application_Select_by_Guid
(
	_guid char(36)
)
BEGIN
	SELECT * 
	FROM Application
	WHERE Guid = _guid;
END$$

DELIMITER ;

