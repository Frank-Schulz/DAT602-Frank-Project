-- Procedure for adding an initial admin
DROP PROCEDURE IF EXISTS `addAdmin`
delimiter //
CREATE PROCEDURE `addAdmin`()
BEGIN
	insert into `tblAccount` (`Username`, `Password`, `Email`, `Admin`)
	values ('admin1', 'password123', 'testAdmin@mail.com', 1);
END //
delimiter ;

-- Procedure for starting a game
DROP PROCEDURE IF EXISTS `startGame`;
delimiter //
CREATE PROCEDURE `startGame`()
begin
	-- food
	INSERT INTO `tblFood` (`X`, `Y`)
	VALUES  (1, 5),
			(15, 20),
			(9, 12),
			(14, 8);
	-- snake
	INSERT INTO `tblSnake` (`SnakeLength`, `SnakeDirection`)
	VALUES (2, 1);
	-- snake segement
	INSERT INTO `tblSnakeSegment` (`SnakeID`, `X`, `Y`)
	VALUES  (1, 1, 19),
			(1, 1, 20),
			(2, 20, 19),
			(2, 20, 20);
end //
delimiter ;

-- Login
DROP PROCEDURE IF EXISTS `login`
DELIMITER //
CREATE PROCEDURE `login`(IN username char, IN password char)
BEGIN
	SELECT a.`Username`
	FROM `tblAccount` as a
	WHERE a.`Username` = username AND a.`Password` = password;

	UPDATE `tblAccount` as a
	SET a.`UserOnline` = 1
	WHERE a.`Username` = username AND a.`Password` = password;
END //
DELIMITER ;





-- snake move steps
-- 1. get position of head
DROP PROCEDURE IF EXISTS `getSnakeHead`
DELIMITER //
CREATE PROCEDURE `getSnakeHead`(IN account INT)
BEGIN 
	SELECT `s.head` 
	FROM `tblSnakeSegement` as ss
	
END //
DELIMITER ;

-- 2. get current direction
DROP PROCEDURE IF EXISTS `getTileAhead`
DELIMITER //
CREATE PROCEDURE `getTileAhead`()
BEGIN 
	SELECT `s.head` 
	FROM `tblSnakeSegement` as ss
	
END //
DELIMITER ;

-- 3. get tile ahead
-- 4. move snake forward
DROP PROCEDURE IF EXISTS `move`;
DELIMITER //
CREATE PROCEDURE `move`()
BEGIN
	
END //
DELIMITER ;

























