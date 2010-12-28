DELIMITER $$

-- Select --
DROP PROCEDURE IF EXISTS bsp_SecurableObject_Select_by_Guid$$
CREATE PROCEDURE bsp_SecurableObject_Select_by_Guid
(
	_guid char(36)
)
BEGIN
	SELECT * 
	FROM SecurableObject
	WHERE Guid = _guid;
END$$

DELIMITER ;

