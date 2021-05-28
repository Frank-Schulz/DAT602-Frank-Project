DROP DATABASE IF EXISTS DAT602_Frank_Project;
CREATE DATABASE DAT602_Frank_Project;
USE DAT602_Frank_Project;

-- ----------------------------------------------- DDL -----------------------------------------------
DROP PROCEDURE IF EXISTS `createTables`;
DELIMITER //
CREATE PROCEDURE `createTables`()
BEGIN
	DROP TABLE IF EXISTS `tblTile`;
		-- Tile types
			-- empty
            -- home
            -- food
	DROP TABLE IF EXISTS `tblSnakeSegment`;
	DROP TABLE IF EXISTS `tblSnake`;
		-- direction
			-- y+1, y-1, x+1, x-1
    DROP TABLE IF EXISTS `tblInventory`;
	DROP TABLE IF EXISTS `tblMessages`;
	DROP TABLE IF EXISTS `tblAccount`;
	DROP TABLE IF EXISTS `tblGrid`;

	CREATE TABLE `tblAccount` (
		`AccountID` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
		`Username` VARCHAR(50) NOT NULL,
		`Password` VARCHAR(50) NOT NULL,
		`Email` VARCHAR(50),
		`Admin` BOOL NOT NULL DEFAULT FALSE,
		`LoginAttempts` INT NOT NULL DEFAULT 0,
		`Highscore` INTEGER(10) DEFAULT 0
	);
    
    CREATE TABLE `tblInventory` (
		`ItemID` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        `AccountID` INTEGER(10),
        FOREIGN KEY (`AccountID`)
			REFERENCES `tblAccount` (`AccountID`)
            ON DELETE CASCADE
    );
    
    CREATE TABLE `tblMessages` (
		`MessageID` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        `AccountID` INTEGER(10) NOT NULL,
        `From` VARCHAR(50) NOT NULL,
        `To` VARCHAR(50) NOT NULL,
        `Message` VARCHAR(50),
        `DateTime` DATETIME
    );

	CREATE TABLE `tblGrid` (
		`GridID` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        `GridSize` INTEGER(10) NOT NULL
	);
    
    CREATE TABLE `tblTile` (
		`TileID` INTEGER(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
		`GridID` INTEGER(10) NOT NULL,
        `TileType` VARCHAR(20) NOT NULL DEFAULT "",
        `X` INT,
        `Y` INT,
        FOREIGN KEY (`GridID`) 
			REFERENCES `tblGrid` (`GridID`)
            ON DELETE CASCADE
    );
    
    CREATE TABLE `tblSnake` (
		`SnakeID` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        `GridID` INT DEFAULT 0,
        `SnakeLength` INT DEFAULT 1,
        `SnakeDirX` VARCHAR(10) DEFAULT "0",
        `SnakeDirY` VARCHAR(10) DEFAULT "-1",
        FOREIGN KEY (`GridID`)
			REFERENCES `tblGrid` (`GridID`)
            ON DELETE CASCADE,
        FOREIGN KEY (`SnakeID`)
			REFERENCES `tblAccount` (`AccountID`)
            ON DELETE CASCADE
    );
    
    CREATE TABLE `tblSnakeSegment` (
		`SegmentID` INTEGER(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
		`SnakeID` INTEGER(10) NOT NULL,
        `X` INT NOT NULL,
        `Y` INT NOT NULL,
        FOREIGN KEY (`SnakeID`) 
			REFERENCES `tblSnake` (`SnakeID`)
            ON DELETE CASCADE
	);
END //
DELIMITER ;
CALL createTables;

-- ----------------------------------------------- DML -----------------------------------------------
-- --------------------------- INSERT
DROP PROCEDURE IF EXISTS `dataInsert`;
DELIMITER //
CREATE PROCEDURE `dataInsert`(
	IN pGridSize INT,
    IN pHomeX INT,
    IN pHomeY INT
)
BEGIN
    DECLARE pCol INT;
    DECLARE pRow INT;
    
    -- grid
    INSERT INTO `tblGrid` (`GridSize`)
    VALUES (0);
    INSERT INTO `tblGrid` (`GridSize`)
    VALUES (pGridSize);
    
    -- tiles
	SET pCol = 0;
    SET pRow = 0;
    WHILE pCol < (SELECT `GridSize` FROM `tblGrid` WHERE `GridID` = 2) do
		WHILE pRow < (SELECT `GridSize` FROM `tblGrid` WHERE `GridID` = 2) do
			INSERT INTO `tblTile` (`GridID`, `TileType`, `X`, `Y`)
			VALUES  (2, "", pCol+1, pRow+1);
			SET pRow = pRow + 1;
        END WHILE;
		SET pRow = 0;
		SET pCol = pCol + 1;
	END WHILE;
    
	UPDATE `tblTile`
	SET  `TileType` = "Home"
    WHERE `X` = pHomeX AND `Y` = pHomeY;
            
	-- account
		-- admin
	-- Create initail admins
	INSERT INTO `tblAccount` (`Username`, `Password`, `Email`, `Admin`)
	VALUES ('admin', 'P@ssword1', null,  1);
-- 	INSERT INTO `tblAccount` (`Username`, `Password`, `Email`, `Admin`)
-- 	VALUES ('admin1', 'password123', 'testAdmin@mail.com', 1);
        -- regular user
-- 	INSERT INTO `tblAccount` (`Username`, `Password`, `Email`)
-- 	VALUES ('player1', 'password123', 'testPlayer@mail.com');
-- 	INSERT INTO `tblAccount` (`Username`, `Password`, `Email`)
-- 	VALUES ('player2', 'password123', 'test2Player@mail.com');
    
    -- snake
	INSERT INTO `tblSnake` (`SnakeID`, `GridID`)
	VALUES (1, 1);
-- 	INSERT INTO `tblSnake` (`GridID`, `SnakeLength`, `SnakeDirection`)
-- 	VALUES (1, 2, 1), (1, 2, 1);
    
	-- snake segement
-- 	INSERT INTO `tblSnakeSegment` (`SnakeID`, `X`, `Y`)
-- 	VALUES  (1, 1, 20),
-- 			(1, 1, 19),
-- 			(2, 20, 20),
-- 			(2, 20, 19);
END //
DELIMITER ;

-- --------------------------- UPDATE
DROP PROCEDURE IF EXISTS `dataUpdate`;
DELIMITER //
CREATE PROCEDURE `dataUpdate`() 
BEGIN
	-- account
	UPDATE `tblAccount` 
	SET 
		`Email` = 'player@mail.com'
	WHERE
		`AccountID` = 2;
        
    -- grid
    UPDATE `tblAccount_Grid`
    SET
		`Score` = `Score`+1
	WHERE
		`AccountID` = 1;
    
    -- food
    UPDATE `tblFood`
    SET
		`X` = 15,
        `Y` = 17
	WHERE
		`GridID` = 1;
    
    -- snake
    UPDATE `tblSnake`
    SET 
		`SnakeLength` = `SnakeLength`+1
    WHERE
		`AccountID` = 1;
    
	-- snake segement
    UPDATE `tblSnakeSegment`
    SET
		`X` = 15,
        `Y` = 16
	WHERE `Tail` = 1;
END //
DELIMITER ;

-- --------------------------- SELECT
DROP PROCEDURE IF EXISTS `dataSelect`;
DELIMITER //
CREATE PROCEDURE `dataSelect`()
BEGIN
	-- account
    SELECT `Username`, `Email`, `Highscore`
    FROM `tblAccount`;
    
    -- grid
    SELECT `Username`, `Score`
    FROM `tblAccount` as A
    RIGHT JOIN `tblAccount_Grid` as AG
		on A.AccountID = AG.AccountID;
    
    -- food
    SELECT `X`, `Y`
    FROM `tblFood`;
        
	-- snake
    SELECT `SnakeLength`
    FROM `tblSnake`;
    
	-- snake segement
    SELECT `X`, `Y`
    FROM `tblSnakeSegment` as SS
    WHERE SS.`Head` = 1;
END //
DELIMITER ;

-- --------------------------- DELETE
DROP PROCEDURE IF EXISTS `dataDelete`;
DELIMITER //
CREATE PROCEDURE `dataDelete`()
BEGIN
	-- account
    DELETE FROM `tblAccount`
    WHERE `AccountID` = 3;
    
    -- grid
    DELETE FROM `tblGrid`
    WHERE `GridID` = 1;
    
    -- food
		-- Deleted through cascade
    -- snake
		-- Deleted through cascade
	-- snake segement
		-- Deleted through cascade
END //
DELIMITER ;

-- Create tables
CALL createTables();

-- Test data
CALL dataInsert(10, 5, 5);
-- CALL dataUpdate();
-- CALL dataSelect();

-- Delete tables
-- CALL dataDelete();

-- Create initail admin
-- INSERT INTO `tblAccount` (`Username`, `Password`, `Email`, `Admin`)
-- VALUES ('admin', 'P@ssword1', null,  1);


-- Remove stored procedures used in database creation - To secure access to the database
DROP PROCEDURE IF EXISTS `createTables`;
DROP PROCEDURE IF EXISTS `dataInsert`;
DROP PROCEDURE IF EXISTS `dataUpdate`;
DROP PROCEDURE IF EXISTS `dataSelect`;
DROP PROCEDURE IF EXISTS `dataDelete`;