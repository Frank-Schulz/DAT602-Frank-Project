
-- 1. Get player row col
DROP PROCEDURE IF EXISTS `getPlayerPosition`
DELIMITER //
CREATE PROCEDURE `getPlayerPosition`()
BEGIN
	SELECT row, col
	FROM 
		tblPlayer as p JOIN tblTile as t
		on p.tile_id = t.id
	WHERE
		p.id = 123;
END //
DELIMITER ;
	
	
-- 2. Get neighbours tile_id
DROP PROCEDURE IF EXISTS `getNeighbours`
DELIMITER //
CREATE PROCEDURE `getNeighbours`()
BEGIN
	SELECT tile.tile_id
	FROM 
		tblPlayer as p JOIN tblTile as t
		on p.tile_id = t.id
		JOIN tblTile as t2 on p.tile_id <> t.id
	WHERE
		((t2.row = t.row + 1) OR (t2.row = t.row - 1) OR (t2.row = t.row)) AND 
		((t2.col = t.col + 1) OR (t2.col = t.col - 1) OR (t2.col = t.col)) AND
		p.id = 123;
END //
DELIMITER ;	
	
	
-- 3. Try move player
DROP PROCEDURE IF EXISTS `movePlayer`
DELIMITER //
CREATE PROCEDURE `movePlayer`(IN `newTile` int) 
BEGIN

	UPDATE tblPlayer as p
		SET p.tile_id = `newTile`
		WHERE `newtile` = (
			SELECT tile.tile_id
			FROM 
				tblPlayer as p JOIN tblTile as t
				on p.tile_id = t.id
				JOIN tblTile as t2 on p.tile_id <> t.id
			WHERE
				((t2.row = t.row + 1) OR (t2.row = t.row - 1) OR (t2.row = t.row)) AND 
				((t2.col = t.col + 1) OR (t2.col = t.col - 1) OR (t2.col = t.col)) AND
				p.id = 123);
END //
DELIMITER ;
