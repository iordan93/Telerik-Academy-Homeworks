CREATE DATABASE DatabasePerformanceTest;

USE DatabasePerformanceTest;

CREATE TABLE LogEntries(
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Time` DATETIME,
	`Content` VARCHAR(8000),
	PRIMARY KEY (Id, `Time`))
	PARTITION BY RANGE(YEAR(`Time`))(
		PARTITION p1 VALUES LESS THAN (1990),
		PARTITION p2 VALUES LESS THAN (2000),
		PARTITION p3 VALUES LESS THAN (2010),
		PARTITION p4 VALUES LESS THAN MAXVALUE);

DELIMITER $$
	CREATE PROCEDURE InsertValues()
	BEGIN
		DECLARE counter INT DEFAULT 0;
		DECLARE minDate DATETIME;
		DECLARE maxDate DATETIME;
		SET minDate = '1980-01-01 00:00:00';
		SET maxDate = '2020-12-31 00:00:00';
		START TRANSACTION;
		WHILE counter < 10000000 DO
			INSERT INTO `LogEntries`(`Time`, `Content`)
				VALUES (
					TIMESTAMPADD(SECOND, FLOOR(RAND() * TIMESTAMPDIFF(SECOND, minDate, maxDate)), minDate),
					'A sample log entry');
		SET counter = counter + 1;
		END WHILE;
		COMMIT;
END $$
CALL InsertValues();

-- 4. Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random dates) 
-- to certain partition (e.g. year 1995).

-- Clear the cache
RESET QUERY CACHE;

-- All tables - 00:00:35
SELECT `Time`, `Content` from `LogEntries`
WHERE `Time` BETWEEN '1995-01-01' AND '1995-12-31'
LIMIT 10000000

RESET QUERY CACHE;

-- Only second partition - 00:00:07
SELECT `Time`, `Content` from `LogEntries` PARTITION(p2)
WHERE `Time` BETWEEN '1995-01-01' AND '1995-12-31'
LIMIT 10000000