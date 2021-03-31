-- Procedure fo adding an initial admin
DROP PROCEDURE IF EXISTS `addAdmin`
delimiter //
CREATE PROCEDURE `addAdmin`()
BEGIN
	insert into `Account` (`Username`, `Password`, `Email`, `Admin`)
	values ('admin1', 'password123', 'testAdmin@mail.com', 1);
END //
delimiter ;

-- Procedure for starting a game
DROP PROCEDURE IF EXISTS `startGame`;
delimiter //
CREATE PROCEDURE `startGame`()
begin
	-- food
	INSERT INTO `Food` (`X`, `Y`)
	VALUES  (1, 5),
			(15, 20),
			(9, 12),
			(14, 8);
	-- snake
	INSERT INTO `Snake` (`SnakeLength`, `SnakeDirection`)
	VALUES (2, 1);
	-- snake segement
	INSERT INTO `SnakeSegment` (`SnakeID`, `X`, `Y`)
	VALUES  (1, 1, 19),
			(1, 1, 20),
			(2, 20, 19),
			(2, 20, 20);
end //
delimiter ;
