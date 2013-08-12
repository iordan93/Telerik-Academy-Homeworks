---- 4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT d.Name, e.FirstName + ' ' + e.LastName AS [Manager] 
FROM Departments d JOIN Employees e
	ON d.ManagerID = e.EmployeeID

---- 5. Write a SQL query to find all department names.
--SELECT Name AS [Department Name] 
--FROM Departments

---- 6. Write a SQL query to find the salary of each employee.
--SELECT FirstName + ' ' + LastName AS [Employee], Salary 
--FROM Employees
--ORDER BY LastName, FirstName

---- 7. Write a SQL to find the full name of each employee.
--SELECT FirstName + ' ' + 
--	CASE WHEN MiddleName IS NULL 
--		THEN LastName 
--		ELSE MiddleName + ' ' + LastName 
--	END
--FROM Employees

-- -- 8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
-- -- Consider that the mail domain is telerik.com. Emails should look like "John.Doe@telerik.com". 
-- -- The produced column should be named "Full Email Addresses".
--SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Address] 
--FROM Employees

---- 9. Write a SQL query to find all different employee salaries.
--SELECT DISTINCT Salary 
--FROM Employees

---- 10. Write a SQL query to find all information about the employees whose job title is "Sales Representative".
--SELECT FirstName + ' ' + LastName AS [Sales Representatives]
--FROM Employees
--WHERE JobTitle = 'Sales Representative'

---- 11. Write a SQL query to find the names of all employees whose first name starts with "SA".
--SELECT FirstName + ' ' + LastName AS [Employees]
--FROM Employees
--WHERE FirstName LIKE 'Sa%'
--ORDER BY FirstName

---- 12. Write a SQL query to find the names of all employees whose last name contains "ei".
--SELECT FirstName + ' ' + LastName AS [Employees]
--FROM Employees
--WHERE LastName LIKE '%ei%'
--ORDER BY FirstName

---- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
--SELECT FirstName + ' ' + LastName AS [Employees with salaries in range]
--FROM Employees
--WHERE Salary >= 20000 AND Salary <= 30000
--ORDER BY FirstName

---- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
--SELECT FirstName + ' ' + LastName AS [Employees with specified salaries]
--FROM Employees
--WHERE Salary IN (25000, 14000, 12500, 23600)
--ORDER BY FirstName

---- 15. Write a SQL query to find all employees that do not have manager.
--SELECT FirstName + ' ' + LastName AS [Directors]
--FROM Employees
--WHERE ManagerID IS NULL
--ORDER BY FirstName

---- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
--SELECT FirstName + ' ' + LastName AS [Employees with salaries more than 50000], Salary
--FROM Employees
--WHERE Salary > 50000
--ORDER BY Salary DESC

---- 17. Write a SQL query to find the top 5 best paid employees.
--SELECT TOP 5 FirstName + ' ' + LastName AS [Employee Name],  Salary
--FROM Employees
--ORDER BY Salary DESC

---- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
--SELECT e.FirstName + ' ' + e.LastName AS [Name], a.AddressText as [Address]
--FROM Employees e INNER JOIN Addresses a
--	ON e.AddressID = a.AddressID
--ORDER BY e.FirstName, e.LastName

---- 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
--SELECT e.FirstName + ' ' + e.LastName AS [Name], a.AddressText AS [Address]
--FROM Employees e, Addresses a
--	WHERE e.AddressID = a.AddressID
--ORDER BY e.FirstName, e.LastName

---- 20. Write a SQL query to find all employees along with their manager.
--SELECT employee.FirstName + ' ' + employee.LastName AS [Employee Name], manager.FirstName + ' ' + manager.LastName AS [Manager Name]
--FROM Employees employee LEFT JOIN Employees manager
--	ON employee.ManagerID = manager.EmployeeID
--ORDER BY employee.FirstName, employee.LastName

---- 21. Write a SQL query to find all employees, along with their manager and their address.
---- Join the 3 tables: Employees e, Employees m and Addresses a.
--SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], m.FirstName + ' ' + m.LastName AS [Manager Name], a.AddressText AS [Address]
--FROM Employees e LEFT JOIN Employees m
--	ON e.ManagerID = m.EmployeeID
--JOIN Addresses a
--	ON e.AddressID = a.AddressID
--ORDER BY e.FirstName, e.LastName

---- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.
--SELECT Name AS [Departments and towns]
--FROM Departments
--UNION SELECT Name
--	FROM Towns

---- 23. Write a SQL query to find all the employees and the manager for each of them along with the employees 
---- that do not have manager. Use right outer join.
--SELECT employee.FirstName + ' ' + employee.LastName AS [Employee Name], manager.FirstName + ' ' + manager.LastName AS [Manager Name]
--FROM Employees manager RIGHT OUTER JOIN Employees employee
--	ON manager.EmployeeID = employee.ManagerID
--ORDER BY employee.FirstName, employee.LastName

---- Rewrite the query to use left outer join.
--SELECT employee.FirstName + ' ' + employee.LastName AS [Employee Name], manager.FirstName + ' ' + manager.LastName AS [Manager Name]
--FROM Employees employee LEFT OUTER JOIN Employees manager
--	ON employee.ManagerID = manager.EmployeeID
--ORDER BY employee.FirstName, employee.LastName

---- 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance"
----  whose hire year is between 1995 and 2005.
--SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], e.HireDate
--FROM Employees e JOIN Departments d
--	ON e.DepartmentID = d.DepartmentID
--WHERE d.Name IN ('Sales', 'Finance') 
--	AND e.HireDate> CAST('1995-01-01' AS smalldatetime) 
--	AND e. HireDate < CAST('2005-01-01' AS smalldatetime)
--ORDER BY e.FirstName, e.LastName