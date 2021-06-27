/*
GRANT EXECUTE ON PROCEDURE myDB.spName TO 'TestUser'@'localhost'  identified by 'password';

tblmessages
*/

DROP DATABASE IF EXISTS dat602frankprojectdb;
CREATE DATABASE dat602frankprojectdb;
USE dat602frankprojectdb;

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
        `Online` BOOL NOT NULL DEFAULT FALSE,
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


-- ---------------------------------------------- USERS ---------------------------------------------
-- CREATE USER IF NOT EXISTS SnakeAdmin
-- IDENTIFIED BY 'password';

-- DROP USER IF EXISTS SnakeAdmin;

-- select user from mysql.user;

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
    WHILE pCol < (SELECT `GridSize` FROM `tblGrid` WHERE `GridID` = 2) DO
		WHILE pRow < (SELECT `GridSize` FROM `tblGrid` WHERE `GridID` = 2) DO
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
    
	-- Create initial admin
	INSERT INTO `tblAccount` (`Username`, `Password`, `Email`, `Admin`)
	VALUES ('admin', 'P@ssword1', 'admin@mail.com',  1);
    
    -- snake
	INSERT INTO `tblSnake` (`SnakeID`, `GridID`)
	VALUES (1, 1);
    
    -- snakesegment
    INSERT INTO `tblsnakesegment` (`SnakeID`, `X`, `Y`)
    VALUES (1, pHomeX, pHomeY);
END //
DELIMITER ;

-- Create tables
CALL createTables();

-- Insert intial data
CALL dataInsert(10, 5, 5);


-- Remove stored procedures used in database creation - To secure access to the database
DROP PROCEDURE IF EXISTS `createTables`;
DROP PROCEDURE IF EXISTS `dataInsert`;

-- -------------------------------------------- PROCEDURES -------------------------------------------
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

-- USE DAT602_Frank_Project;

/* Included procedures
login
addplayer
	player
	admin
getAllUsers
deleteAccount
generateFood
joinGame
leaveGame
turnSnake
updateGrid
	moveSnake
		collision
		onFood

------------

*/

-- drop procedures
DROP PROCEDURE IF EXISTS `login`;
DROP PROCEDURE IF EXISTS `addPlayer`;
DROP PROCEDURE IF EXISTS `addAdmin`;
DROP PROCEDURE IF EXISTS `accountLockedToggle`;
DROP PROCEDURE IF EXISTS `getAllUsers`;
DROP PROCEDURE IF EXISTS `deleteAccount`;
DROP PROCEDURE IF EXISTS `genFood`;
DROP PROCEDURE IF EXISTS `joinGame`;
DROP PROCEDURE IF EXISTS `leaveGame`;
DROP PROCEDURE IF EXISTS `turnSnake`;
DROP PROCEDURE IF EXISTS `updateGrid`;

DELIMITER //

-- Login
CREATE PROCEDURE `login`(
	IN pUsername VARCHAR(50), 
    IN pPassword VARCHAR(50)
    )
spLogin: BEGIN
	IF (
		SELECT `LoginAttempts`
        FROM tblAccount
        WHERE `Username` = pUsername
    ) > 5
    THEN
        SELECT 'WARNING: Account locked' AS MESSAGE;
        LEAVE spLogin;
	END IF;

	IF (
		SELECT `Username`
		FROM `tblAccount`
		WHERE
		`Username` = pUsername AND 
		`Password` = pPassword
        ) = pUsername
	THEN
		UPDATE `tblAccount`
        SET `Online` = 1
        WHERE `Username` = pUsername;
		SELECT 'Login successful' AS MESSAGE;
	ELSE
		SELECT 'ERROR: Incorrect user details' AS MESSAGE;
	END IF;
END //


-- Logout
CREATE PROCEDURE `logout`(
	IN pUsername VARCHAR(50)
)
BEGIN
	UPDATE `tblAccount`
    SET `Online` = 0
    WHERE `Username` = pUsername;
    SELECT CONCAT(pUsername, ' has logged out') AS MESSAGE;
END //

-- Procedure for adding a player
CREATE PROCEDURE `addAccount`(
	IN pUsername VARCHAR(50), 
    IN pPassword VARCHAR(50), 
    IN pEmail VARCHAR(50)
    )
BEGIN
	IF pUsername IN(
		SELECT `Username`
		FROM tblAccount
		)
    THEN
		SELECT 'ERROR: User already exists' AS MESSAGE;
	ELSE
		INSERT INTO `tblAccount` (`Username`, `Password`, `Email`)
		VALUES (pUsername, pPassword, pEmail);
        
        INSERT INTO `tblSnake` (`SnakeID`, `GridID`)
        VALUES (
			(
			SELECT `AccountID`
            FROM `tblAccount`
            WHERE `Username` = pUsername
			), 1
        );
        
		SELECT CONCAT('User created: ', pUsername) AS MESSAGE;
    END IF;
END //


-- Procedure for adding an admin
CREATE PROCEDURE `promoteDemoteAccount`(
    IN pUsername VARCHAR(50)
    )
addAdmin: BEGIN
	IF (
		SELECT `Admin`
        FROM `tblAccount`
        WHERE `tblAccount`.`Username` = pUsername) = 0
	THEN
        UPDATE `tblAccount`
		SET `Admin` = 1
		WHERE `tblAccount`.`Username` = pUsername;
	ELSE
        UPDATE `tblAccount`
		SET `Admin` = 0
		WHERE `tblAccount`.`Username` = pUsername;
	END IF;
END //


-- Procedure for locking / unlocking account
CREATE PROCEDURE `accountLockedToggle`(
	IN pUsername VARCHAR(50)
)
BEGIN
	IF (
		SELECT `LoginAttempts`
		FROM `tblAccount`
		WHERE `Username` = pUsername
        ) > 5
	THEN
		UPDATE `tblAccount`
        SET `LoginAttempts` = 0
        WHERE `Username` = pUsername;
	ELSE
		UPDATE `tblAccount`
        SET `LoginAttempts` = 6
        WHERE `Username` = pUsername;
	END IF;
END //


-- Get all players
CREATE PROCEDURE `getAllUsers`()
BEGIN
	SELECT *
    FROM tblAccount;
END //


-- delete account
CREATE PROCEDURE `deleteAccount`(
	IN pUsername VARCHAR(50)
    )
deleteUser: BEGIN
    IF (
		SELECT Username 
        FROM tblAccount 
        WHERE Username = pUsername) = pUsername
    THEN
		DELETE FROM tblAccount
		WHERE Username = pUsername;
			
		SELECT CONCAT("Account deleted: ", pUsername) AS MESSAGE;
	ELSE
		SELECT CONCAT("ERROR: '", pUsername, "' does not exist") AS MESSAGE;
        LEAVE deleteUser;
	END IF;
END //


-- randomly generate food on grid up to: grid size / 5. eg. 20*20 grid has 4 food tiles
/*
	This currently has a bug where it does not always populate the grid with the correct number
    of food tiles (grid size / 5 eg. 50/5 = 10). In the case of a 50*50 grid I have seen it 
    create up to 12 food tiles as opposed to the intended 10.
    
    UPDATE: IT seems to have been fixed but I'll leave this here just in case
*/
CREATE PROCEDURE `genFood`()
BEGIN
	DECLARE pGridID INT;

	DECLARE pGridMin INT;
    DECLARE pGridMax INT;
    
    DECLARE `pCol` INT;
    DECLARE `pRow` INT;
    
    SET pGridID = 2;
    
    SET pGridMin = 1;
    SET pGridMax = (
		SELECT `GridSize`
        FROM `tblGrid`
        WHERE `GridID` = pGridID
    );
    
	WHILE (SELECT COUNT(*) FROM `tblTile` WHERE `TileType` = "Food" AND `GridID` = pGridID) < FLOOR(pGridMax/5) DO
		SET `pCol` = (SELECT FLOOR(RAND()*(pGridMax-pGridMin+1)+pGridMin));
        SET `pRow` = (SELECT FLOOR(RAND()*(pGridMax-pGridMin+1)+pGridMin));
    
		UPDATE `tblTile`
        SET `TileType` = "Food"
        WHERE (
            `TileType` = "" AND
			`GridID` = pGridID AND
			`pCol` = `X` AND `pRow` = `Y`
            );
    END WHILE;
    SELECT CONCAT("Food generated. ", (
		SELECT COUNT(*)
        FROM `tblTile`
        WHERE `TileType` = "Food"
    ), " food tiles on grid") as MESSAGE;
END //


-- Procedure for joining the game
CREATE PROCEDURE `joinGame`(
	IN player VARCHAR(50)
    )
BEGIN
	DECLARE homeX INT;
    DECLARE homeY INT;

	DECLARE pID INT;
	SET pID = (
		SELECT `AccountID`
        FROM `tblAccount`
        WHERE `Username` = player
    );

	IF (SELECT `SnakeID` FROM `tblSnakeSegment` WHERE `SnakeID` = pID) = pID
    THEN
        UPDATE `tblSnake`
        SET `GridID` = 2
        WHERE `SnakeID` = pID;
		
		SELECT CONCAT(player, " returns to the grid") AS MESSAGE;
	ELSE
		SET homeX = (
			SELECT `X` FROM `tblTile` WHERE `TileType` = "Home"
        );
		SET homeY = (
			SELECT `Y` FROM `tblTile` WHERE `TileType` = "Home"
        );
        INSERT INTO `tblSnakeSegment` (`SnakeID`, `X`, `Y`)
        VALUES (pID, homeX, homeY);
        
        UPDATE `tblSnake`
        SET `GridID` = 2
        WHERE `SnakeID` = pID;
        
		SELECT CONCAT("Welcome to the grid ", player) AS MESSAGE;
    END IF;
END //


-- Procedure for leaving the game
CREATE PROCEDURE `leaveGame`(
	IN pPlayer VARCHAR(50)
    )
BEGIN
	UPDATE `tblSnake`
    SET `GridID` = 1
    WHERE `SnakeID` = (
		SELECT `AccountID`
        FROM `tblAccount`
        WHERE `Username` = pPlayer
    );
    IF (
		SELECT `GridID`
        FROM `tblSnake`
        WHERE `SnakeID` = (
			SELECT `AccountID`
			FROM `tblAccount`
			WHERE `Username` = pPlayer
        )
        ) = 1
    THEN
		SELECT CONCAT(pPlayer, " has left the grid") AS MESSAGE;
	ELSE
		SELECT CONCAT("ERROR: ", pPlayer, " failed to leave the grid") AS MESSAGE;
    END IF;
END //


-- turnSnake
CREATE PROCEDURE `turnSnake`(
	IN pPlayer VARCHAR(50),
	IN pDirX VARCHAR(10),
	IN pDirY VARCHAR(10)
)
BEGIN
	DECLARE pID INT;
    
    SET pID = (SELECT `AccountID` FROM `tblAccount` WHERE `Username` = pPlayer);

	UPDATE `tblSnake`
    SET `SnakeDirX` = pDirX, `SnakeDirY` = pDirY
    WHERE `SnakeID` = pID;
    
    SELECT CONCAT("New snake direction, X: ", pDirX, " | Y: ", pDirY) AS MESSAGE;
END //


-- updateGrid
CREATE PROCEDURE `updateGrid`()
BEGIN
	-- loop vars
    DECLARE pSnakes INT; DECLARE pSnake INT;
    -- player
    DECLARE pPlayerName VARCHAR(50);
    -- snake vars
    DECLARE pSnakeID INT; DECLARE pSnakeDirX VARCHAR(10); DECLARE pSnakeDirY VARCHAR(10); DECLARE pSnakeHead INT;
    -- position vars
    DECLARE pCurrentID INT; DECLARE pCurrentX INT; DECLARE pCurrentY INT;
    DECLARE pTargetID INT;  DECLARE pTargetX INT;  DECLARE pTargetY INT;
    -- state vars
    DECLARE pTargetType VARCHAR(10); DECLARE pTargetUsed BOOL;
    
    
	SET pSnake = 0,
		pPlayerName = "",
		pCurrentID = 0, pCurrentX = 0, pCurrentY = 0,
		pTargetID = 0, pTargetX = 0, pTargetY = 0,
        pTargetType = "", pTargetUsed = false;
	
	-- collision
        -- for each snake
        SELECT COUNT(*) FROM `tblSnake` WHERE `GridID` = 2 INTO pSnakes;
        WHILE pSnake<pSnakes DO
			SET pSnakeDirX = null;
			SET pSnakeDirY = null;
			SET pSnakeID = (SELECT `SnakeID` FROM tblSnake WHERE `GridID` = 2 LIMIT pSnake,1);
            SET pPlayerName = (SELECT `Username` FROM `tblAccount` WHERE `AccountID` = pSnakeID);
			SET pSnakeHead = (SELECT `SegmentID` FROM `tblSnakeSegment` WHERE `SnakeID` = pSnakeID ORDER BY `SegmentID` DESC LIMIT 1);
            SET pSnakeDirX = (SELECT `SnakeDirX` FROM `tblSnake` WHERE `SnakeID` = pSnakeID);
            SET pSnakeDirY = (SELECT `SnakeDirY` FROM `tblSnake` WHERE `SnakeID` = pSnakeID);
            SET pCurrentID = (SELECT `TileID` FROM `tblTile` t JOIN `tblSnakeSegment` ss ON t.X = ss.X AND t.Y = ss.Y WHERE `GridID` = 2 AND `SnakeID` = pSnakeID AND `SegmentID` = pSnakeHead);
            SET pCurrentX = (SELECT `X` FROM `tblTile` WHERE `TileID` = pCurrentID);
            SET pCurrentY = (SELECT `Y` FROM `tblTile` WHERE `TileID` = pCurrentID);
            SET pTargetID = (SELECT `TileID` FROM `tblTile` WHERE `X` = (pCurrentX + pSnakeDirX) AND `Y` = (pCurrentY + pSnakeDirY));
            SET pTargetX = (SELECT `X` FROM `tblTile` WHERE `TileID` = pTargetID);
            SET pTargetY = (SELECT `Y` FROM `tblTile` WHERE `TileID` = pTargetID);
            IF (SELECT `TileType` FROM `tblTile` WHERE `TileID` = pTargetID) <> ""
            THEN
				SET pTargetType = (SELECT `TileType` FROM `tblTile` WHERE `TileID` = pTargetID);
			ELSE
				SET pTargetType = "EMPTY";
            END IF;
            IF ((SELECT `TileID` FROM `tblTile` t JOIN `tblSnakeSegment` ss ON t.X = ss.X AND t.Y = ss.Y AND ss.X = pTargetX AND ss.Y = pTargetY ) = pTargetID) AND pTargetType <> "Home"
			THEN
				SET pTargetUsed = true;
			ELSE
				SET pTargetUsed = false;
			END IF;
            
			-- move snake
            IF pTargetUsed = false OR pTargetID = null
            THEN
				-- if on food, remove food, move snake, DON'T REMOVE TAIL, generate new food
				IF pTargetType = "FOOD"
				THEN
					UPDATE `tblTile`
                    SET `tileType` = ""
                    WHERE `TileID` = pTargetID;
					INSERT INTO `tblSnakeSegment` (`SnakeID`, `X`, `Y`)
					VALUES (pSnakeID, pTargetX, pTargetY);
                    CALL `genFood()`;
				ELSE 	-- if no food, move snake, REMOVE TAIL
					INSERT INTO `tblSnakeSegment` (`SnakeID`, `X`, `Y`)
					VALUES (pSnakeID, pTargetX, pTargetY);
					DELETE FROM `tblSnakeSegment`
					WHERE `SnakeID` = pSnakeID
					LIMIT 1;
				END IF;
                
			ELSE	-- on collision
				DELETE FROM `tblSnakeSegment`
                WHERE `SnakeID` = pSnakeID;
                CALL `leaveGame`(pPlayerName);
				SELECT "You Died!" AS MESSAGE;
            END IF;
            
            SELECT pSnakeID AS SnakeID,
				   pSnakeHead AS HeadID,
                   pSnakeDirX AS DirectionX,
                   pSnakeDirY AS DirectionY,
                   pCurrentID AS CurrentTile,
                   pCurrentX AS CurrentX,
                   pCurrentY AS CurrentY,
                   pTargetID AS TargetID,
                   pTargetX AS TargetX,
                   pTargetY AS TargetY,
                   pTargetType AS TargetType,
                   pTargetUsed AS TargetUsed;
            
            SET pSnake = pSnake + 1;
		END WHILE;
	SELECT "Grid Updated" AS MESSAGE;
END //


CREATE PROCEDURE `getGameGrid`()
BEGIN
	DECLARE pCol INT;
    DECLARE pRow INT;
    SET pCol = 1;
    SET pRow = 1;
    
	select *
    from `tbltile`
    where `GridID` = 2;

-- 	WHILE pCol < 10 DO
-- 		WHILE PRow < 10 DO
-- 			INSERT INTO `tblGameGrid`
--             SET pCol = (
-- 				SELECT `TileType`
--                 FROM `tbltile`
--                 WHERE `X` = pCol AND `Y` = pRow
--             );
--         END WHILE;
--     END WHILE;
--     
END //
DELIMITER ;

drop table if exists `tblGameGrid`;
create table `tblGameGrid` (
	`1` int,
	`2` int,
	`3` int,
	`4` int,
	`5` int,
	`6` int,
	`7` int,
	`8` int,
	`9` int,
	`10` int
);

call `getGameGrid`();








/*
-- -------------------------------------------- ACCESS RIGHTS -------------------------------------------
-- DROP PROCEDURE IF EXISTS `accessControl`
-- DELIMITER //
-- CREATE PROCEDURE `accessControl`()
-- BEGIN
-- 	
-- 	GRANT EXECUTE ON PROCEDURE dat602_frank_project.spName TO 'TestUser'@'localhost';
-- END //
-- DELIMITER ;



/*
-- Procedure test calls
-- ---------------------------------------------------------------------------

-- add users
CALL `addPlayer`('player1', 'P@ssword1', 'testPlayer@mail.com');
CALL `addPlayer`('player2', 'P@ssword1', 'testPlayer@mail.com');
CALL `addAdmin`('admin', 'P@ssword1', 'newAdmin', 'newPassword', 'new@mail.com');
-- promote player1 to admin
CALL `addAdmin`('admin', 'P@ssword1', 'player1', 'newPassword', 'new@mail.com');
-- get list of all users
CALL `getAllUsers`();

-- Correct details
CALL `login`('player1', 'P@ssword1');
-- Incorrect details
CALL `login`('player1', 'Password1');

-- delete user 'player1'
-- CALL `deleteAccount`('player1');

-- add food to the grid
CALL `genFood`();

CALL `joinGame`('player2');
CALL `leaveGame`('player2');

CALL `turnSnake`("player1", 1, 0);

CALL `updateGrid`();

/*
==================================================================================
UNFINISHED BELOW THIS POINT
*/










