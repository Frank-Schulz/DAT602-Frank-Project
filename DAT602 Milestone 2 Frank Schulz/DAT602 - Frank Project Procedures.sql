-- Syntax for Azure Synapse Analytics and Parallel Data Warehouse
  
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

USE DAT602_Frank_Project;

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

-- Login
DROP PROCEDURE IF EXISTS `login`;
DELIMITER //
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
		SELECT 'Login succesful' AS MESSAGE;
	ELSE
		SELECT 'ERROR: Incorrect user details' AS MESSAGE;
	END IF;
END //
DELIMITER ;

-- Procedure for adding a player
DROP PROCEDURE IF EXISTS `addPlayer`;
DELIMITER //
CREATE PROCEDURE `addPlayer`(
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
DELIMITER ;

-- Procedure for adding an admin
DROP PROCEDURE IF EXISTS `addAdmin`;
DELIMITER //
CREATE PROCEDURE `addAdmin`(
	IN pUsername VARCHAR(50), 
    IN pPassword VARCHAR(50),
    IN pNewUsername VARCHAR(50),
    IN pNewPassword VARCHAR(50),
    IN pNewEmail VARCHAR(50)
    )
sp: BEGIN
    IF (SELECT `Admin` FROM tblAccount WHERE Username = pUsername) = false
    THEN
		SELECT CONCAT("ERROR: ", pUsername, " is NOT an Admin") as MESSAGE;
		LEAVE sp;
    END IF;

	CALL `addPlayer`(pNewUsername, pNewPassword, pNewEmail);
    UPDATE `tblAccount`
    SET `Admin` = 1
    WHERE `tblAccount`.`Username` = pNewUsername;
    
    SELECT 'New Admin Success' AS MESSAGE;
END //
DELIMITER ;

-- Get all players
DROP PROCEDURE IF EXISTS `getAllUsers`;
DELIMITER //
CREATE PROCEDURE `getAllUsers`()
BEGIN
	SELECT `Username`, `Password`, `Email`
    FROM tblAccount;
END //
DELIMITER ;

-- delete account
DROP PROCEDURE IF EXISTS `deleteAccount`;
DELIMITER //
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
DELIMITER ;

-- randomly generate food on grid up to: grid size / 5. eg. 20*20 grid has 4 food tiles
/*
	This currently has a bug where it does not always populate the grid with the correct number
    of food tiles (grid size / 5 eg. 50/5 = 10). In the case of a 50*50 grid I have seen it 
    create up to 12 food tiles as opposed to the intended 10.
    
    UPDATE: IT seems to have been fixed but I'll leave this here just in case
*/
DROP PROCEDURE IF EXISTS `genFood`;
DELIMITER //
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
DELIMITER ;

-- Procedure for joining the game
DROP PROCEDURE IF EXISTS `joinGame`;
DELIMITER //
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
DELIMITER ;

-- Procedure for leaving the game
DROP PROCEDURE IF EXISTS `leaveGame`;
DELIMITER //
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
DELIMITER ;

-- turnSnake
DROP PROCEDURE IF EXISTS `turnSnake`;
DELIMITER //
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
DELIMITER ;

-- updateGrid
DROP PROCEDURE IF EXISTS `updateGrid`;
DELIMITER //
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
DELIMITER ;

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










