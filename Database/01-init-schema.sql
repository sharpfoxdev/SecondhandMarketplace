DROP PROCEDURE IF EXISTS `POMELO_BEFORE_DROP_PRIMARY_KEY`;
DELIMITER //
CREATE PROCEDURE `POMELO_BEFORE_DROP_PRIMARY_KEY`(IN `SCHEMA_NAME_ARGUMENT` VARCHAR(255), IN `TABLE_NAME_ARGUMENT` VARCHAR(255))
BEGIN
	DECLARE HAS_AUTO_INCREMENT_ID TINYINT(1);
	DECLARE PRIMARY_KEY_COLUMN_NAME VARCHAR(255);
	DECLARE PRIMARY_KEY_TYPE VARCHAR(255);
	DECLARE SQL_EXP VARCHAR(1000);
	SELECT COUNT(*)
		INTO HAS_AUTO_INCREMENT_ID
		FROM `information_schema`.`COLUMNS`
		WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
			AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
			AND `Extra` = 'auto_increment'
			AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
	IF HAS_AUTO_INCREMENT_ID THEN
		SELECT `COLUMN_TYPE`
			INTO PRIMARY_KEY_TYPE
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
		SELECT `COLUMN_NAME`
			INTO PRIMARY_KEY_COLUMN_NAME
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
		SET SQL_EXP = CONCAT('ALTER TABLE `', (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA())), '`.`', TABLE_NAME_ARGUMENT, '` MODIFY COLUMN `', PRIMARY_KEY_COLUMN_NAME, '` ', PRIMARY_KEY_TYPE, ' NOT NULL;');
		SET @SQL_EXP = SQL_EXP;
		PREPARE SQL_EXP_EXECUTE FROM @SQL_EXP;
		EXECUTE SQL_EXP_EXECUTE;
		DEALLOCATE PREPARE SQL_EXP_EXECUTE;
	END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS `POMELO_AFTER_ADD_PRIMARY_KEY`;
DELIMITER //
CREATE PROCEDURE `POMELO_AFTER_ADD_PRIMARY_KEY`(IN `SCHEMA_NAME_ARGUMENT` VARCHAR(255), IN `TABLE_NAME_ARGUMENT` VARCHAR(255), IN `COLUMN_NAME_ARGUMENT` VARCHAR(255))
BEGIN
	DECLARE HAS_AUTO_INCREMENT_ID INT(11);
	DECLARE PRIMARY_KEY_COLUMN_NAME VARCHAR(255);
	DECLARE PRIMARY_KEY_TYPE VARCHAR(255);
	DECLARE SQL_EXP VARCHAR(1000);
	SELECT COUNT(*)
		INTO HAS_AUTO_INCREMENT_ID
		FROM `information_schema`.`COLUMNS`
		WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
			AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
			AND `COLUMN_NAME` = COLUMN_NAME_ARGUMENT
			AND `COLUMN_TYPE` LIKE '%int%'
			AND `COLUMN_KEY` = 'PRI';
	IF HAS_AUTO_INCREMENT_ID THEN
		SELECT `COLUMN_TYPE`
			INTO PRIMARY_KEY_TYPE
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_NAME` = COLUMN_NAME_ARGUMENT
				AND `COLUMN_TYPE` LIKE '%int%'
				AND `COLUMN_KEY` = 'PRI';
		SELECT `COLUMN_NAME`
			INTO PRIMARY_KEY_COLUMN_NAME
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_NAME` = COLUMN_NAME_ARGUMENT
				AND `COLUMN_TYPE` LIKE '%int%'
				AND `COLUMN_KEY` = 'PRI';
		SET SQL_EXP = CONCAT('ALTER TABLE `', (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA())), '`.`', TABLE_NAME_ARGUMENT, '` MODIFY COLUMN `', PRIMARY_KEY_COLUMN_NAME, '` ', PRIMARY_KEY_TYPE, ' NOT NULL AUTO_INCREMENT;');
		SET @SQL_EXP = SQL_EXP;
		PREPARE SQL_EXP_EXECUTE FROM @SQL_EXP;
		EXECUTE SQL_EXP_EXECUTE;
		DEALLOCATE PREPARE SQL_EXP_EXECUTE;
	END IF;
END //
DELIMITER ;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `AspNetRoles` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `AspNetUsers` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `UserName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 NULL,
        `Email` varchar(256) CHARACTER SET utf8mb4 NULL,
        `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 NULL,
        `EmailConfirmed` tinyint(1) NOT NULL,
        `PasswordHash` longtext CHARACTER SET utf8mb4 NULL,
        `SecurityStamp` longtext CHARACTER SET utf8mb4 NULL,
        `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
        `PhoneNumber` longtext CHARACTER SET utf8mb4 NULL,
        `PhoneNumberConfirmed` tinyint(1) NOT NULL,
        `TwoFactorEnabled` tinyint(1) NOT NULL,
        `LockoutEnd` datetime(6) NULL,
        `LockoutEnabled` tinyint(1) NOT NULL,
        `AccessFailedCount` int NOT NULL,
        CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `Categories` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        `ParentCategoryId` char(36) COLLATE ascii_general_ci NULL,
        CONSTRAINT `PK_Categories` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Categories_Categories_ParentCategoryId` FOREIGN KEY (`ParentCategoryId`) REFERENCES `Categories` (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `ListingProperties` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_ListingProperties` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `StateOfItem` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_StateOfItem` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `AspNetRoleClaims` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `RoleId` char(36) COLLATE ascii_general_ci NOT NULL,
        `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
        `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `AspNetUserClaims` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
        `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `AspNetUserLogins` (
        `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `ProviderDisplayName` longtext CHARACTER SET utf8mb4 NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
        CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `AspNetUserRoles` (
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `RoleId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
        CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `AspNetUserTokens` (
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `Value` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
        CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `CategoryListingProperty` (
        `CategoriesId` char(36) COLLATE ascii_general_ci NOT NULL,
        `ListingPropertiesId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_CategoryListingProperty` PRIMARY KEY (`CategoriesId`, `ListingPropertiesId`),
        CONSTRAINT `FK_CategoryListingProperty_Categories_CategoriesId` FOREIGN KEY (`CategoriesId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_CategoryListingProperty_ListingProperties_ListingPropertiesId` FOREIGN KEY (`ListingPropertiesId`) REFERENCES `ListingProperties` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `ListingPropertyValues` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        `ListingPropertyId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_ListingPropertyValues` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_ListingPropertyValues_ListingProperties_ListingPropertyId` FOREIGN KEY (`ListingPropertyId`) REFERENCES `ListingProperties` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `Listings` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Price` decimal(65,30) NOT NULL,
        `SellerId` char(36) COLLATE ascii_general_ci NOT NULL,
        `StateOfItemId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Title` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
        `ReasonOfSale` longtext CHARACTER SET utf8mb4 NOT NULL,
        `IsSold` tinyint(1) NOT NULL,
        `CategoryId` char(36) COLLATE ascii_general_ci NOT NULL,
        `ApplicationUserId` char(36) COLLATE ascii_general_ci NULL,
        CONSTRAINT `PK_Listings` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Listings_AspNetUsers_ApplicationUserId` FOREIGN KEY (`ApplicationUserId`) REFERENCES `AspNetUsers` (`Id`),
        CONSTRAINT `FK_Listings_AspNetUsers_SellerId` FOREIGN KEY (`SellerId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_Listings_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_Listings_StateOfItem_StateOfItemId` FOREIGN KEY (`StateOfItemId`) REFERENCES `StateOfItem` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `Images` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ImageUrl` longtext CHARACTER SET utf8mb4 NOT NULL,
        `FileName` longtext CHARACTER SET utf8mb4 NOT NULL,
        `FileExtension` longtext CHARACTER SET utf8mb4 NOT NULL,
        `FileSizeInBytes` bigint NOT NULL,
        `ListingId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_Images` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Images_Listings_ListingId` FOREIGN KEY (`ListingId`) REFERENCES `Listings` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE TABLE `ListingListingPropertyValue` (
        `ListingsId` char(36) COLLATE ascii_general_ci NOT NULL,
        `SelectedListingPropertyValuesId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_ListingListingPropertyValue` PRIMARY KEY (`ListingsId`, `SelectedListingPropertyValuesId`),
        CONSTRAINT `FK_ListingListingPropertyValue_ListingPropertyValues_SelectedLi~` FOREIGN KEY (`SelectedListingPropertyValuesId`) REFERENCES `ListingPropertyValues` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_ListingListingPropertyValue_Listings_ListingsId` FOREIGN KEY (`ListingsId`) REFERENCES `Listings` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    INSERT INTO `AspNetRoles` (`Id`, `ConcurrencyStamp`, `Name`, `NormalizedName`)
    VALUES ('2d39b4e7-843e-410b-b6e4-ae30e38039f4', '2d39b4e7-843e-410b-b6e4-ae30e38039f4', 'User', 'USER'),
    ('996f9a95-c46c-40fa-9bb6-144a05138cdc', '996f9a95-c46c-40fa-9bb6-144a05138cdc', 'Developer', 'DEVELOPER'),
    ('e8c9ac14-c7f6-4991-88aa-ad40bfe8f707', 'e8c9ac14-c7f6-4991-88aa-ad40bfe8f707', 'Admin', 'ADMIN');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    INSERT INTO `ListingProperties` (`Id`, `Name`)
    VALUES ('72697394-56b3-4ed8-851f-b74e28454616', 'BinocularsType'),
    ('9091889f-ed33-48a0-979e-875968b305fe', 'BackpackBrand'),
    ('e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3', 'BackpackType');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    INSERT INTO `StateOfItem` (`Id`, `Name`)
    VALUES ('2e0e5d47-2ff5-421e-945e-9fdc08cc762d', 'Nový');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    INSERT INTO `ListingPropertyValues` (`Id`, `ListingPropertyId`, `Name`)
    VALUES ('13b902a9-c0e4-4799-80d8-56206eb1acc8', '9091889f-ed33-48a0-979e-875968b305fe', 'Patizon'),
    ('3f5fd110-e73f-46fe-bb92-3a8094e3cbcb', '9091889f-ed33-48a0-979e-875968b305fe', 'Sir Joseph'),
    ('4f53489e-90b3-43ad-b51c-aa65f301b984', '9091889f-ed33-48a0-979e-875968b305fe', 'Prima'),
    ('8dd8cbb6-03a9-4220-b343-d4c5a283283b', 'e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3', 'Batoh'),
    ('b567cbd5-d49d-427d-a90f-1d94f8cd5c8e', '72697394-56b3-4ed8-851f-b74e28454616', 'Monokulár'),
    ('ba38e3c6-777c-4dbd-87bd-450206c7e49a', 'e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3', 'Sumka'),
    ('c62d49f3-0294-4e9a-9411-5a392f719b76', '72697394-56b3-4ed8-851f-b74e28454616', 'Binokulár'),
    ('d882ac03-d93e-41c6-8503-2d2fd47acac5', 'e2cfc37d-9d86-4dbf-a0e9-c4b2b59770c3', 'Taška');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_Categories_ParentCategoryId` ON `Categories` (`ParentCategoryId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_CategoryListingProperty_ListingPropertiesId` ON `CategoryListingProperty` (`ListingPropertiesId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_Images_ListingId` ON `Images` (`ListingId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_ListingListingPropertyValue_SelectedListingPropertyValuesId` ON `ListingListingPropertyValue` (`SelectedListingPropertyValuesId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_ListingPropertyValues_ListingPropertyId` ON `ListingPropertyValues` (`ListingPropertyId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_Listings_ApplicationUserId` ON `Listings` (`ApplicationUserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_Listings_CategoryId` ON `Listings` (`CategoryId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_Listings_SellerId` ON `Listings` (`SellerId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    CREATE INDEX `IX_Listings_StateOfItemId` ON `Listings` (`StateOfItemId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240307233051_fresh start once more1') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240307233051_fresh start once more1', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    ALTER TABLE `Listings` DROP FOREIGN KEY `FK_Listings_AspNetUsers_ApplicationUserId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    ALTER TABLE `Listings` DROP INDEX `IX_Listings_ApplicationUserId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    ALTER TABLE `Listings` DROP COLUMN `ApplicationUserId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    CREATE TABLE `Conversations` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `CreatedAt` datetime(6) NOT NULL,
        CONSTRAINT `PK_Conversations` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    CREATE TABLE `ConversationParticipant` (
        `ConversationId` char(36) COLLATE ascii_general_ci NOT NULL,
        `UserId` char(36) COLLATE ascii_general_ci NOT NULL,
        CONSTRAINT `PK_ConversationParticipant` PRIMARY KEY (`ConversationId`, `UserId`),
        CONSTRAINT `FK_ConversationParticipant_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_ConversationParticipant_Conversations_ConversationId` FOREIGN KEY (`ConversationId`) REFERENCES `Conversations` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    CREATE TABLE `Messages` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ConversationId` char(36) COLLATE ascii_general_ci NOT NULL,
        `SenderId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Content` longtext CHARACTER SET utf8mb4 NOT NULL,
        `CreatedAt` datetime(6) NOT NULL,
        CONSTRAINT `PK_Messages` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Messages_AspNetUsers_SenderId` FOREIGN KEY (`SenderId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_Messages_Conversations_ConversationId` FOREIGN KEY (`ConversationId`) REFERENCES `Conversations` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    CREATE INDEX `IX_ConversationParticipant_UserId` ON `ConversationParticipant` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    CREATE INDEX `IX_Messages_ConversationId` ON `Messages` (`ConversationId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    CREATE INDEX `IX_Messages_SenderId` ON `Messages` (`SenderId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315214916_Conversations and messages') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250315214916_Conversations and messages', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    ALTER TABLE `ConversationParticipant` DROP FOREIGN KEY `FK_ConversationParticipant_AspNetUsers_UserId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    ALTER TABLE `ConversationParticipant` DROP FOREIGN KEY `FK_ConversationParticipant_Conversations_ConversationId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    CALL POMELO_BEFORE_DROP_PRIMARY_KEY(NULL, 'ConversationParticipant');
    ALTER TABLE `ConversationParticipant` DROP PRIMARY KEY;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    ALTER TABLE `ConversationParticipant` RENAME `ConversationParticipants`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    ALTER TABLE `ConversationParticipants` RENAME INDEX `IX_ConversationParticipant_UserId` TO `IX_ConversationParticipants_UserId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    ALTER TABLE `ConversationParticipants` ADD CONSTRAINT `PK_ConversationParticipants` PRIMARY KEY (`ConversationId`, `UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    ALTER TABLE `ConversationParticipants` ADD CONSTRAINT `FK_ConversationParticipants_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    ALTER TABLE `ConversationParticipants` ADD CONSTRAINT `FK_ConversationParticipants_Conversations_ConversationId` FOREIGN KEY (`ConversationId`) REFERENCES `Conversations` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231312_rename to participantS') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250315231312_rename to participantS', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231400_rename to participant') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250315231400_rename to participant', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    ALTER TABLE `ConversationParticipants` DROP FOREIGN KEY `FK_ConversationParticipants_AspNetUsers_UserId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    ALTER TABLE `ConversationParticipants` DROP FOREIGN KEY `FK_ConversationParticipants_Conversations_ConversationId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    CALL POMELO_BEFORE_DROP_PRIMARY_KEY(NULL, 'ConversationParticipants');
    ALTER TABLE `ConversationParticipants` DROP PRIMARY KEY;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    ALTER TABLE `ConversationParticipants` RENAME `ConversationParticipant`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    ALTER TABLE `ConversationParticipant` RENAME INDEX `IX_ConversationParticipants_UserId` TO `IX_ConversationParticipant_UserId`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    ALTER TABLE `ConversationParticipant` ADD CONSTRAINT `PK_ConversationParticipant` PRIMARY KEY (`ConversationId`, `UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    ALTER TABLE `ConversationParticipant` ADD CONSTRAINT `FK_ConversationParticipant_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    ALTER TABLE `ConversationParticipant` ADD CONSTRAINT `FK_ConversationParticipant_Conversations_ConversationId` FOREIGN KEY (`ConversationId`) REFERENCES `Conversations` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250315231446_rename to participant without s') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250315231446_rename to participant without s', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250331225851_add last update of convo') THEN

    ALTER TABLE `Conversations` ADD `LastUpdatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250331225851_add last update of convo') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250331225851_add last update of convo', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250621222021_adding fields to user') THEN

    ALTER TABLE `AspNetUsers` ADD `LastLoggedIn` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250621222021_adding fields to user') THEN

    ALTER TABLE `AspNetUsers` ADD `Nickname` longtext CHARACTER SET utf8mb4 NOT NULL;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250621222021_adding fields to user') THEN

    ALTER TABLE `AspNetUserClaims` MODIFY COLUMN `Id` int NOT NULL AUTO_INCREMENT;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250621222021_adding fields to user') THEN

    ALTER TABLE `AspNetRoleClaims` MODIFY COLUMN `Id` int NOT NULL AUTO_INCREMENT;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250621222021_adding fields to user') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250621222021_adding fields to user', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250622232935_Add cities') THEN

    ALTER TABLE `Listings` ADD `CityId` char(36) COLLATE ascii_general_ci NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250622232935_Add cities') THEN

    CREATE TABLE `Cities` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        `ZipCode` longtext CHARACTER SET utf8mb4 NOT NULL,
        `District` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Region` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Location` point srid 4326 NOT NULL,
        CONSTRAINT `PK_Cities` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250622232935_Add cities') THEN

    CREATE INDEX `IX_Listings_CityId` ON `Listings` (`CityId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250622232935_Add cities') THEN

    ALTER TABLE `Listings` ADD CONSTRAINT `FK_Listings_Cities_CityId` FOREIGN KEY (`CityId`) REFERENCES `Cities` (`Id`) ON DELETE CASCADE;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250622232935_Add cities') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250622232935_Add cities', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250703164701_Listing creation date') THEN

    ALTER TABLE `Listings` ADD `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250703164701_Listing creation date') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250703164701_Listing creation date', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250713133349_add reviews') THEN

    CREATE TABLE `Reviews` (
        `Id` char(36) COLLATE ascii_general_ci NOT NULL,
        `ReviewerId` char(36) COLLATE ascii_general_ci NOT NULL,
        `RevieweeId` char(36) COLLATE ascii_general_ci NOT NULL,
        `ReviewText` longtext CHARACTER SET utf8mb4 NOT NULL,
        `CreatedAt` datetime(6) NOT NULL,
        CONSTRAINT `PK_Reviews` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_Reviews_AspNetUsers_RevieweeId` FOREIGN KEY (`RevieweeId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_Reviews_AspNetUsers_ReviewerId` FOREIGN KEY (`ReviewerId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250713133349_add reviews') THEN

    CREATE INDEX `IX_Reviews_RevieweeId` ON `Reviews` (`RevieweeId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250713133349_add reviews') THEN

    CREATE INDEX `IX_Reviews_ReviewerId` ON `Reviews` (`ReviewerId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20250713133349_add reviews') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20250713133349_add reviews', '8.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

DROP PROCEDURE `POMELO_BEFORE_DROP_PRIMARY_KEY`;

DROP PROCEDURE `POMELO_AFTER_ADD_PRIMARY_KEY`;

