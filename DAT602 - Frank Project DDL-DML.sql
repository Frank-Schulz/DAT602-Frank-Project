drop database if exists DAT602_Frank_Project;
create database DAT602_Frank_Project;
use DAT602_Frank_Project;

-- ----------------------------------------------- DDL -----------------------------------------------
drop procedure if exists `createTables`;
delimiter //
create procedure `createTables`()
begin
	DROP TABLE IF EXISTS `Food`;
	DROP TABLE IF EXISTS `SnakeSegment`;
	DROP TABLE IF EXISTS `Snake`;
	DROP TABLE IF EXISTS `Account_Grid`;
	DROP TABLE IF EXISTS `Account`;
	DROP TABLE IF EXISTS `Grid`;

	CREATE TABLE `Account` (
		`AccountID` INT NOT NULL AUTO_INCREMENT,
		`Username` VARCHAR(50) NOT NULL,
		`Password` VARCHAR(50) NOT NULL,
		`Email` VARCHAR(50) NOT NULL,
		`AccountLocked` BOOL NOT NULL DEFAULT FALSE,
		`Admin` BOOL NOT NULL DEFAULT FALSE,
		`LoginAttempts` TINYINT(1) NOT NULL DEFAULT 0,
		`UserOnline` BOOL DEFAULT TRUE,
		`Highscore` INTEGER(10) DEFAULT 0,
		PRIMARY KEY (`AccountID`)
	);

	CREATE TABLE `Grid` (
		`GridID` INT NOT NULL AUTO_INCREMENT,
        PRIMARY KEY (`GridID`)
	);
    
    CREATE TABLE `Account_Grid` (
        `GridID` INTEGER(10) NOT NULL,
		`AccountID` INTEGER(10) NOT NULL,
        `Score` INTEGER(10),
		FOREIGN KEY (`GridID`) 
			REFERENCES `Grid` (`GridID`)
            ON DELETE CASCADE,
		FOREIGN KEY (`AccountID`) REFERENCES `Account` (`AccountID`)
    );
    
    CREATE TABLE `Food` (
		`GridID` INTEGER(10) NOT NULL,
        `X` TINYINT(2),
        `Y` TINYINT(2),
        FOREIGN KEY (`GridID`) 
			REFERENCES `Grid` (`GridID`)
            ON DELETE CASCADE
    );
    
    CREATE TABLE `Snake` (
		`SnakeID` INT NOT NULL AUTO_INCREMENT,
        `GridID` INTEGER(10) NOT NULL,
        `AccountID` INTEGER(10) NOT NULL,
        `SnakeLength` TINYINT(3) NOT NULL,
        `SnakeDirection` TINYINT(3) NOT NULL,
        PRIMARY KEY (`SnakeID`),
        FOREIGN KEY (`GridID`) 
			REFERENCES `Grid` (`GridID`)
            ON DELETE CASCADE,
        FOREIGN KEY (`AccountID`) REFERENCES `Account` (`AccountID`)
    );
    
    CREATE TABLE `SnakeSegment` (
		`SnakeID` INTEGER(10) NOT NULL,
        `Head` TINYINT(1),
        `Tail` TINYINT(1),
        `X` TINYINT(3) NOT NULL,
        `Y` TINYINT(3) NOT NULL,
        FOREIGN KEY (`SnakeID`) 
			REFERENCES `Snake` (`SnakeID`)
            ON DELETE CASCADE
	);
end //
delimiter ;
call createTables;

-- ----------------------------------------------- DML -----------------------------------------------
-- --------------------------- INSERT
drop procedure if exists `dataInsert`;
delimiter //
create procedure `dataInsert`()
begin
	-- account
		-- admin
	insert into `Account` (`Username`, `Password`, `Email`, `Admin`)
	values ('admin1', 'password123', 'testAdmin@mail.com', 1);
        -- regular user
	insert into `Account` (`Username`, `Password`, `Email`)
	values ('player1', 'password123', 'testPlayer@mail.com');
	insert into `Account` (`Username`, `Password`, `Email`)
	values ('player2', 'password123', 'test2Player@mail.com');
    
    -- grid
    INSERT INTO `Grid` (`GridID`)
    VALUES (1);
    
    INSERT INTO `Account_Grid` (`GridID`, `AccountID`, `Score`)
    VALUES (1, 1, 0), (1, 2, 40);
    
    -- food
	INSERT INTO `Food` (`GridID`, `X`, `Y`)
	VALUES  (1, 1, 5),
			(1, 15, 20),
			(1, 9, 12),
			(1, 14, 8);
    
    -- snake
	INSERT INTO `Snake` (`GridID`, `AccountID`, `SnakeLength`, `SnakeDirection`)
	VALUES (1, 1, 2, 1), (1, 2, 2, 1);
    
	-- snake segement
	INSERT INTO `SnakeSegment` (`SnakeID`, `Head`, `Tail`, `X`, `Y`)
	VALUES  (1, 1, 0, 1, 19),
			(1, 0, 1, 1, 20),
			(2, 1, 0, 20, 19),
			(2, 0, 1, 20, 20);
END //
delimiter ;

-- --------------------------- UPDATE
DROP PROCEDURE IF EXISTS `dataUpdate`;
delimiter //
CREATE PROCEDURE `dataUpdate`() 
BEGIN
	-- account
	UPDATE `Account` 
	SET 
		`Email` = 'player@mail.com'
	WHERE
		`AccountID` = 2;
        
    -- grid
    UPDATE `Account_Grid`
    SET
		`Score` = `Score`+1
	WHERE
		`AccountID` = 1;
    
    -- food
    UPDATE `Food`
    SET
		`X` = 15,
        `Y` = 17
	WHERE
		`GridID` = 1;
    
    -- snake
    UPDATE `Snake`
    SET 
		`SnakeLength` = `SnakeLength`+1
    WHERE
		`AccountID` = 1;
    
	-- snake segement
    UPDATE `SnakeSegment`
    SET
		`X` = 15,
        `Y` = 16
	WHERE `Tail` = 1;
END //
delimiter ;

-- --------------------------- SELECT
DROP PROCEDURE IF EXISTS `dataSelect`;
delimiter //
CREATE PROCEDURE `dataSelect`()
BEGIN
	-- account
    SELECT `Username`, `Email`, `Highscore`
    FROM `Account`;
    
    -- grid
    SELECT `Username`, `Score`
    FROM `Account` as A
    RIGHT JOIN `Account_Grid` as AG
		on A.AccountID = AG.AccountID;
    
    -- food
    SELECT `X`, `Y`
    FROM `Food`;
        
	-- snake
    SELECT `SnakeLength`
    FROM Snake;
    
	-- snake segement
    SELECT `X`, `Y`
    FROM `SnakeSegment` as SS
    WHERE SS.`Head` = 1;
END //
delimiter ;

-- --------------------------- DELETE
DROP PROCEDURE IF EXISTS `dataDelete`;
delimiter //
CREATE PROCEDURE `dataDelete`()
BEGIN
	-- account
    DELETE FROM `Account`
    WHERE `AccountID` = 3;
    
    -- grid
    DELETE FROM `Grid`
    WHERE `GridID` = 1;
    
    -- food
		-- Deleted through cascade
    -- snake
		-- Deleted through cascade
	-- snake segement
		-- Deleted through cascade
end //
delimiter ;

call createTables();
call dataInsert();
CALL dataUpdate();
CALL dataSelect();
CALL dataDelete();