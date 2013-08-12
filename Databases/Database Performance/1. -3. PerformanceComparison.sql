USE [master]

CREATE DATABASE DatabasePerformanceTest
GO

USE DatabasePerformanceTest
GO
-- 1. Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).
CREATE TABLE LogEntries(
  Id INT NOT NULL PRIMARY KEY IDENTITY,
  [Time] DATETIME,
  Content VARCHAR(MAX))

INSERT INTO LogEntries(Content) VALUES ('A sample log entry');

DECLARE @counter INT = 2
WHILE (SELECT COUNT(*) FROM LogEntries) < 10000000
BEGIN
	INSERT INTO LogEntries(Content)
		SELECT Content from LogEntries
SET @counter = @counter * 2
END

-- Random date generator
DECLARE @date_from DATETIME;
DECLARE @date_to DATETIME;
SET @date_from = '1990-01-01';
SET @date_to = '2020-12-31';
UPDATE LogEntries SET [Time] = (@date_from +(ABS(CAST(CAST(NEWID() AS BINARY(8)) AS INT)) % CAST((@date_to - @date_from) AS INT)))

SELECT COUNT(*) FROM LogEntries

-- Empty the cache
CHECKPOINT
DBCC DROPCLEANBUFFERS

-- Search by date
-- 00:02:06 (00:01:51 with caching)
SELECT [Time], Content FROM LogEntries
GO

-- 2. Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
CREATE INDEX IX_LogEntries_Time ON LogEntries([Time])

CHECKPOINT
DBCC DROPCLEANBUFFERS

-- Search by date with index
-- 00:02:22 (00:01:50 with caching)
SELECT [Time], Content FROM LogEntries
GO

-- 3. Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.
CHECKPOINT
DBCC DROPCLEANBUFFERS

-- Left LIKE
-- 00:02:05 (00:01:53 with caching)
SELECT [Time], Content FROM LogEntries 
WHERE Content LIKE 'A samp%'

CHECKPOINT
DBCC DROPCLEANBUFFERS

-- Inner LIKE
-- 00:02:01 (00:02:00 with caching)
SELECT [Time], Content FROM LogEntries 
WHERE Content LIKE '%samp%'

CREATE FULLTEXT CATALOG LogEntriesCatalog
WITH ACCENT_SENSITIVITY = OFF
 
CREATE FULLTEXT INDEX ON LogEntries(Content)
KEY INDEX PK__LogEntri__3214EC074FF10357
ON LogEntriesCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT
DBCC DROPCLEANBUFFERS

-- Left LIKE
-- 00:02:00 (00:01:53 with caching)
SELECT [Time], Content FROM LogEntries 
WHERE Content LIKE 'A samp%'

CHECKPOINT
DBCC DROPCLEANBUFFERS

-- Inner LIKE
-- 00:01:58 (00:01:50 with caching)
SELECT [Time], Content FROM LogEntries 
WHERE Content LIKE '%samp%'