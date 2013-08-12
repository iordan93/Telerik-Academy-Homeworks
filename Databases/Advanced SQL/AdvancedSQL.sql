---- 1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
---- Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName as [Name], Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)
  ORDER BY FirstName

---- 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher 
---- than the minimal salary for the company.
--SELECT FirstName + ' ' + LastName as [Name], Salary
--FROM Employees
--WHERE Salary <= 
--  (SELECT MIN(Salary) * 1.1 FROM Employees)
--ORDER BY FirstName

---- 3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary 
---- in their department. Use a nested SELECT statement.
--SELECT FirstName + ' ' + LastName as [Name], d.Name as [Department], Salary as [Minimal salary]
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--WHERE Salary = 
--  (SELECT MIN(Salary) FROM Employees 
--   WHERE DepartmentID = e.DepartmentID)
--ORDER BY d.DepartmentID

---- 4. Write a SQL query to find the average salary in the department #1.
--SELECT AVG(Salary) as [Average salary for department 1]
--FROM Employees
--WHERE DepartmentID = 1

---- 5. Write a SQL query to find the average salary  in the "Sales" department.
--SELECT AVG(e.Salary) [Average salary for department Sales]
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--WHERE d.Name = 'Sales'

---- 6. Write a SQL query to find the number of employees in the "Sales" department.
--SELECT COUNT(*) [Employees in department Sales]
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--WHERE d.Name = 'Sales'

---- 7. Write a SQL query to find the number of all employees that have manager.
--SELECT COUNT(*) [Employees with managers]
--FROM Employees
--WHERE ManagerID IS NOT NULL

---- 8. Write a SQL query to find the number of all employees that have no manager.
--SELECT COUNT(*) [Employees with no manager]
--FROM Employees
--WHERE ManagerID IS NULL

---- 9. Write a SQL query to find all departments and the average salary for each of them.
--SELECT d.DepartmentID, AVG(Salary) as [Average salary]
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--GROUP BY d.DepartmentID

---- 10. Write a SQL query to find the count of all employees in each department and for each town.
--SELECT d.Name as [Department name], t.Name as [Town name], COUNT(EmployeeID) as [Employees]
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--	JOIN Addresses a
--		ON a.AddressID = e.AddressID
--		JOIN Towns t
--			ON t.TownID = a.TownID
--GROUP BY d.Name, t.Name
--ORDER BY d.Name

---- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
--SELECT m.FirstName + ' ' + m.LastName as [Manager name]
--FROM Employees e JOIN Employees m
--	ON m.EmployeeID = e.ManagerID
--GROUP BY m.FirstName + ' ' + m.LastName
--HAVING COUNT(*) = 5

---- 12. Write a SQL query to find all employees along with their managers.
---- For employees that do not have manager display the value ("no manager)".
--SELECT e.FirstName + ' ' + e.LastName AS [Employee name], ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager name]
--FROM Employees e LEFT JOIN Employees m
--	ON m.EmployeeID = e.ManagerID
--ORDER BY e.ManagerID

---- 13. Write a SQL query to find the names of all employees whose last name 
---- is exactly 5 characters long. Use the built-in LEN(str) function.
--SELECT FirstName + ' ' + LastName AS [Employees with 5-letter last names]
--FROM Employees
--WHERE LEN(LastName) = 5

---- 14. Write a SQL query to display the current date and time in the following format 
---- "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
--SELECT CONVERT(nvarchar, GETDATE(), 104) + ' ' + (SELECT CONVERT(nvarchar, GETDATE(), 114)) as [Current time]

---- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
---- Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. 
---- Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. 
---- Define a check constraint to ensure the password is at least 5 characters long.
--CREATE TABLE Users (
--  UserID int IDENTITY,
--  FirstName nvarchar(75),
--  LastName nvarchar(75) NOT NULL,
--  Username nvarchar(100) NOT NULL 
--	CONSTRAINT UNIQUE_USERNAME UNIQUE,
--  Password nvarchar(100) NOT NULL,
--  LastLoginTime DATE,
  
--  CONSTRAINT PK_Users PRIMARY KEY(UserID),
--	CHECK (LEN(Password) > 5))

---- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
---- Test if the view works correctly.
--CREATE VIEW [UsersLoggedInToday] AS
--SELECT *
--FROM Users
--WHERE DATEPART(YEAR, LastLoginTime) = DATEPART(YEAR, GETDATE()) AND
--	  DATEPART(MONTH, LastLoginTime) = DATEPART(MONTH, GETDATE()) AND
--	  DATEPART(DAY, LastLoginTime) = DATEPART(DAY, GETDATE())

---- 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
---- Define primary key and identity column.
--CREATE TABLE Groups (
--  GroupID int IDENTITY,
--  Name nvarchar(100) NOT NULL 
--	CONSTRAINT UNIQUE_GROUPNAME UNIQUE,
--  CONSTRAINT PK_Groups PRIMARY KEY(GroupID))

---- 18. Write a SQL statement to add a column GroupID to the table Users. 
---- Fill some data in this new column and as well in the Groups table. Write a SQL statement to add 
---- a foreign key constraint between tables Users and Groups tables.
--ALTER TABLE Users 
--	ADD GroupID int
--ALTER TABLE Users
--	ADD CONSTRAINT FK_Users_Groups
--		FOREIGN KEY (GroupID)
--		REFERENCES Groups(GroupID)

---- 19. Write SQL statements to insert several records in the Users and Groups tables.
--INSERT INTO Users (FirstName, LastName, Username, UserPassword)
--VALUES ('Mary', 'Stevenson', 'mary', 'qwerty')

--INSERT INTO Users (FirstName, LastName, Username, UserPassword)
--VALUES ('Peter', 'Dowes', 'peter', 'asdfgh123456')

--INSERT INTO Groups (Name)
--VALUES ('First group')

--INSERT INTO Groups (Name)
--VALUES ('Second group')

---- 20. Write SQL statements to update some of the records in the Users and Groups tables.
--UPDATE Users
--SET FirstName = 'Anna'
--WHERE FirstName = 'Mary'

--UPDATE Users
--SET Username = 'peter.the.famous'
--WHERE Username = 'peter'

--UPDATE Groups
--SET Name = 'New group'
--WHERE GroupID = 1

---- 21. Write SQL statements to delete some of the records from the Users and Groups tables.
--DELETE FROM Users
--WHERE Username = 'peter.the.famous'

--DELETE FROM Groups
--WHERE GroupID = 2

---- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
---- Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase).
---- Use the same for the password, and NULL for last login time.
--INSERT INTO Users
--	SELECT FirstName, LastName,
--	SUBSTRING(FirstName, 0, 1) + '' + LOWER(LastName) + CAST(EmployeeId  as varchar) as Username,
--	SUBSTRING(FirstName, 0, 1) + '' + LOWER(LastName) + '12345' as UserPassword,
--	NULL as LastLoginTime,
--	1
--	FROM Employees

---- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
--UPDATE Users
--SET UserPassword = NULL -- Remove the check constraint and allow passwords to get NULL first
--WHERE LastLoginTime IS NULL 
--	OR DATEDIFF(day, '2010-03-10 23:59:59.9999999', LastLoginTime) < 0

---- 24. Write a SQL statement that deletes all users without passwords (NULL password).
--DELETE FROM Users
--WHERE UserPassword IS NULL;

---- 25. Write a SQL query to display the average employee salary by department and job title.
--SELECT d.Name, e.JobTitle as [Job title],
--  AVG(Salary) [Average salary]
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--GROUP BY d.Name, JobTitle
--ORDER BY d.Name

---- 26. Write a SQL query to display the minimal employee salary by department and job title 
---- along with the name of some of the employees that take it.
--SELECT d.Name, e.JobTitle as [Job title],
--  MIN(Salary) [Minimal salary],
-- MIN(e.FirstName + ' ' + e.LastName) as [Employee name]
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--GROUP BY d.Name, JobTitle
--ORDER BY d.Name

---- 27. Write a SQL query to display the town where maximal number of employees work.
--SELECT TOP 1 t.Name as [Town name], COUNT(*) as [Employees]
--FROM Employees e JOIN Addresses a
--		ON a.AddressID = e.AddressID
--		JOIN Towns t
--			ON t.TownID = a.TownID
--GROUP BY t.Name
--ORDER BY Employees DESC

---- 28. Write a SQL query to display the number of managers from each town.
--SELECT t.Name as [Town name], COUNT(*) as [Managers]
--FROM Employees e 
--	JOIN Addresses a 
--	ON e.AddressId = a.AddressId
--		JOIN Towns t 
--		ON t.TownId = a.TownId
--WHERE e.ManagerId IS NULL
--GROUP BY t.TownId, t.Name
--ORDER BY t.Name

---- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
---- Don't forget to define  identity, primary key and appropriate foreign key. 
---- Issue few SQL statements to insert, update and delete of some data in the table.
---- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data,
---- the new record data and the command (insert / update / delete).
--CREATE TABLE WorkHours(
--	[EmployeeID] int IDENTITY,
--	[Date] datetime,
--	Task nvarchar(50),
--	[Hours] int,
--	[Comment] nvarchar(50),
	
--	CONSTRAINT PK_WorkHours 
--		PRIMARY KEY(EmployeeID),
--	CONSTRAINT FK_WorkHours_Employees 
--		FOREIGN KEY(EmployeeID)
--		REFERENCES Employees(EmployeeID))

--INSERT INTO WorkHours([Date], Task, [Hours])
--VALUES
--	(GETDATE(), 'First', 18),
--	(GETDATE(), 'Second', 17)

--DELETE FROM WorkHours
--WHERE Task = 'First'

--UPDATE WorkHours
--SET HOURS = 10
--WHERE Task = 'Second'

--CREATE TABLE WorkHoursLog(
--	Id int IDENTITY,
--	OldRecord nvarchar(100) NOT NULL,
--	NewRecord nvarchar(100) NOT NULL,
--	Command nvarchar(10) NOT NULL,
--	EmployeeId int NOT NULL,
--	CONSTRAINT PK_WorkHoursLog 
--		PRIMARY KEY(Id),
--	CONSTRAINT FK_WorkHoursLogs_WorkHours 
--		FOREIGN KEY(EmployeeId) 
--		REFERENCES WorkHours(EmployeeID))

--INSERT INTO WorkHours([Date], Task, [Hours], Comment)
--VALUES(GETDATE(), 'Third task', 12, 'Some comment goes here')

--DELETE FROM WorkHours
--WHERE Task = 'Third task'

--UPDATE WorkHours
--SET Task = 'First'
--WHERE EmployeeID = 1

---- 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records
---- from the pother tables. At the end rollback the transaction.
--BEGIN TRANSACTION
--	ALTER TABLE EmployeesProjects
--		ADD CONSTRAINT FK_CASCADE_1
--		FOREIGN KEY (EmployeeID)
--		REFERENCES Employees (EmployeeID)
--	ON DELETE CASCADE

--	-- To test, set ManagerId to accept NULL values first
--	ALTER TABLE Departments
--	ADD CONSTRAINT FK_CASCADE_2 
--		FOREIGN KEY (ManagerId)
--		REFERENCES Employees (EmployeeID)
--	ON DELETE SET NULL

--	DELETE FROM Employees 
--	WHERE DepartmentId IN (SELECT DepartmentId FROM Departments WHERE Name = 'Sales')

--ROLLBACK TRANSACTION

---- 31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
--BEGIN TRANSACTION
--	CREATE DATABASE TelerikAcademy_Snapshot 
--	ON (NAME = TelerikAcademy_Data, FILENAME = 'TelerikAcademy_Snapshot.ss')
--	AS SNAPSHOT OF TelerikAcademy;

--	DROP TABLE Contacts
--	-- ROLLBACK TRAN
--GO

--BEGIN TRANSACTION
--	ALTER DATABASE TelerikAcademy
--	SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

--	USE master;
--	RESTORE DATABASE TelerikAcademy FROM DATABASE_SNAPSHOT = 'TelerikAcademy_Snapshot';
--GO

---- 32. Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects 
---- and restore them back after dropping and re-creating the table.
--CREATE TABLE #TempEmployeesProjects(
--	EmployeeID int NOT NULL,
--	ProjectID int NOT NULL)

--INSERT INTO #TempEmployeesProjects
--	SELECT EmployeeID, ProjectID
--	FROM EmployeesProjects

--DROP TABLE EmployeesProjects

--CREATE TABLE EmployeesProjects(
--	EmployeeID int NOT NULL,
--	ProjectID int NOT NULL,
--	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
--	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
--	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID))

--INSERT INTO EmployeesProjects
--SELECT EmployeeID, ProjectID
--FROM #TempEmployeesProjects