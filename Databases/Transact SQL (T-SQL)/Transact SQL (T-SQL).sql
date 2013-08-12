-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
-- and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
-- Write a stored procedure that selects the full names of all persons.
CREATE DATABASE Bank
GO

USE Bank
CREATE TABLE Persons(
	PersonId INT NOT NULL IDENTITY,
	FirstName NVARCHAR(75),
	LastName NVARCHAR(75),
	Ssn NVARCHAR(50),
	PRIMARY KEY (PersonId)
)

CREATE TABLE Accounts (
        AccountId INT NOT NULL IDENTITY,
        PersonId INT,
        Balance money
        PRIMARY KEY(AccountId)
        FOREIGN KEY(PersonId)
			REFERENCES Persons(PersonId)
)

SET IDENTITY_INSERT Persons ON
INSERT INTO Persons(PersonId, FirstName, LastName, Ssn) VALUES (1, 'Michael', 'Samuelson', '754556461456453')
INSERT INTO Persons(PersonId, FirstName, LastName, Ssn) VALUES (2, 'Anna', 'Peters', '456869874123456')
SET IDENTITY_INSERT Persons OFF
SET IDENTITY_INSERT Accounts ON
INSERT INTO Accounts(AccountId, PersonId, Balance) VALUES (1, 1, 500)
INSERT INTO Accounts(AccountId, PersonId, Balance) VALUES (2, 2, 10)
SET IDENTITY_INSERT Accounts OFF
GO

CREATE PROCEDURE usp_GetNames
AS
        SELECT FirstName + ' ' + LastName AS [Name]
        FROM Persons
GO

EXECUTE dbo.usp_GetNames
GO

---- 2. Create a stored procedure that accepts a number as a parameter 
---- and returns all persons who have more money in their accounts than the supplied number.
--CREATE PROCEDURE usp_GetPeopleWithMoreMoney(@money MONEY)
--AS
--        SELECT p.FirstName + ' ' + p.LastName AS [Name], Balance
--        FROM dbo.Persons p INNER JOIN dbo.Accounts a
--        ON p.PersonID = a.PersonID
--        WHERE a.Balance >= @money
--GO
 
--EXECUTE usp_GetPeopleWithMoreMoney 20
--GO

---- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
---- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
--CREATE FUNCTION ufn_CalculateInterest(@sum MONEY,  @yearlyInterestRate FLOAT, @months INT)
--RETURNS MONEY
--AS
--	BEGIN
--		DECLARE @result money
--		SET @result = @sum + (@months / 12.0) * (@sum * @yearlyInterestRate)
--		RETURN @result
--	END
--GO

--SELECT dbo.ufn_CalculateInterest(100, 0.2, 1) AS [Interest]
--GO

---- 4. Create a stored procedure that uses the function from the previous example to give 
---- an interest to a person's account for one month. It should take the AccountId and the interest rate as parameters.
--CREATE PROCEDURE usp_UpdateBalanceWithInterest(@AccountID INT, @interestRate FLOAT)
--AS
--	BEGIN
--		DECLARE @sum MONEY
--		SET @sum = (
--			SELECT Balance
--			FROM Accounts
--			WHERE AccountId = @AccountID
--		)

--	DECLARE @newSum MONEY
--		SET @newSum = dbo.ufn_CalculateInterest(@sum, @interestRate, 1)

--	UPDATE Accounts
--		SET Balance = CAST(@newSum AS MONEY)
--		WHERE @AccountID = @AccountID
--	END
--GO

--EXECUTE usp_UpdateBalanceWithInterest 1, 0.2

---- 5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
--CREATE PROCEDURE usp_WithdrawMoney (@AccountID INT, @money MONEY, @result MONEY OUTPUT)
--AS
--	DECLARE @currentBalance MONEY
--	SET @currentBalance = (
--		SELECT a.Balance
--        FROM dbo.Accounts a
--        WHERE a.AccountID = @AccountID
--	)
    
--	SET @result = @currentBalance - @money
--	UPDATE dbo.Accounts
--		SET Balance = @result
--        WHERE(Accounts.AccountID = @AccountID)
--GO
 
--CREATE PROCEDURE usp_DepositMoney (@AccountID INT, @money MONEY, @result MONEY OUTPUT)
--AS
--	DECLARE @currentBalance MONEY
--	SET @currentBalance = (
--		SELECT a.Balance
--        FROM dbo.Accounts a
--        WHERE a.AccountID = @AccountID
--	)
    
--	SET @result = @currentBalance + @money
--	UPDATE dbo.Accounts
--		SET Balance = @result
--        WHERE(Accounts.AccountID = @AccountID)
--GO
 
--DECLARE @result MONEY
--EXEC usp_DepositMoney 1, 100, @result OUTPUT
--PRINT 'After deposit: '
--PRINT @result

--EXEC usp_WithdrawMoney 1, 100, @result OUTPUT
--PRINT 'After withdrawal: '
--PRINT @result
--

---- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
---- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
--CREATE TABLE Logs(
--	Id INT IDENTITY,
--	AccountId INT NOT NULL,
--	OldSum MONEY,
--	NewSum MONEY,
--	PRIMARY KEY(Id),
--	FOREIGN KEY(AccountId)
--		REFERENCES Accounts(AccountId)
--)
--GO

--CREATE TRIGGER tr_LogBalanceChanges ON Accounts FOR UPDATE
--AS
--	BEGIN
--		INSERT INTO Logs
--			SELECT i.AccountId, d.Balance, i.Balance
--			FROM inserted i JOIN deleted d
--				ON d.AccountId = i.AccountId
--			END
--GO

--DECLARE @result MONEY
--EXEC usp_DepositMoney 1, 100, @result OUTPUT
--EXEC usp_WithdrawMoney 2, 100, @result OUTPUT
--GO

---- 7. Define a function in the database TelerikAcademy that returns all Employee's names 
---- (first or middle or last name) and all town's names that are comprised of given set of letters.
---- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
--USE TelerikAcademy
--GO

--CREATE FUNCTION CheckLetters(@word NVARCHAR(100), @letters NVARCHAR(100))
--RETURNS BIT
--AS
--	BEGIN
--		DECLARE @lettersCount INT = LEN(@letters), @matches INT = 0, @current NVARCHAR(1)
--		WHILE(@lettersCount > 0)
--		BEGIN
--			SET @current = SUBSTRING(@letters, @lettersCount, 1)
--			IF(CHARINDEX(@current, @word, 0) > 0)
--			BEGIN
--				SET @matches += 1
--				SET @lettersCount -= 1
--			END
--			ELSE
--				SET @lettersCount -= 1
--			END

--			IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
--				RETURN 1
--			RETURN 0
--		END
--GO

--CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
--RETURNS @ResultTable TABLE (Name NVARCHAR(100) NOT NULL)
--AS
--BEGIN
--	INSERT INTO @ResultTable
--		SELECT LastName FROM Employees
--	INSERT INTO @ResultTable
--		SELECT FirstName FROM Employees
--	INSERT INTO @ResultTable
--		SELECT t.Name FROM Towns t

--	DELETE FROM @ResultTable
--		WHERE dbo.CheckLetters(Name, @letters) = 0
--	RETURN
--END
--GO

--SELECT * FROM NamesAndTowns('svetlin') 
--ORDER BY Name
--SELECT * FROM NamesAndTowns('nakov') 
--ORDER BY Name
--SELECT * FROM NamesAndTowns('oistmiahf') 
--ORDER BY Name

---- 8. Using database cursor write a T-SQL script that scans all employees 
---- and their addresses and prints all pairs of employees that live in the same town.
--DECLARE employeeCursor CURSOR READ_ONLY
--FOR
--	SELECT e1.FirstName, e1.LastName, e2.FirstName, e2.LastName, t1.Name
--	FROM Employees e1 JOIN Addresses a1
--		ON a1.AddressID = e1.AddressID
--		JOIN Towns t1
--			ON t1.TownID = a1.TownID, 
--		Employees e2 JOIN Addresses a2
--			ON e2.AddressID = a2.AddressID
--			JOIN Towns t2
--				ON a2.TownID = t2.TownID
--	WHERE t1.Name = t2.Name AND e1.EmployeeID <> e2.EmployeeID
--	ORDER BY e1.FirstName, e2.FirstName

--OPEN employeeCursor

--DECLARE @firstName NVARCHAR(100), @lastName NVARCHAR(100), @otherFirstName NVARCHAR(100), @otherLastName NVARCHAR(100), @town NVARCHAR(100)
--FETCH NEXT FROM employeeCursor INTO @firstName, @lastName, @otherFirstName, @otherLastName, @town

--WHILE @@FETCH_STATUS = 0
--  BEGIN
--	PRINT @firstName + ' ' + @lastName + ' | ' + @otherFirstName + ' ' + @otherLastName + ' -> ' + @town
--    FETCH NEXT FROM employeeCursor
--    INTO @firstName, @lastName, @otherFirstName, @otherLastName, @town
--  END

--CLOSE employeeCursor
--DEALLOCATE employeeCursor
--GO