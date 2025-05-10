CREATE DATABASE MyCompany;
USE MyCompany;

CREATE LOGIN victor
WITH PASSWORD = 'Pa$$w0rd';
GO

-- Creates a database user for the login created previously.
CREATE USER Victor
FOR LOGIN victor;

EXEC sp_addrolemember 'db_datareader', 'Victor';
EXEC sp_addrolemember 'db_datawriter', 'Victor'; 

DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;
DROP TABLE IF EXISTS Functions;

CREATE TABLE Employees (
	EmployeeId INT IDENTITY(1,1),
	DepartmentId INT NOT NULL,
	FunctionId INT NOT NULL,
	PostTitle VARCHAR(500),
	FirstName VARCHAR(100) NOT NULL, 
	LastName VARCHAR(100) NOT NULL,
	BirthDate DATETIME NOT NULL,
	EmploymentDate DATETIME NOT NULL,
	Salary SMALLMONEY NOT NULL,
	PRIMARY KEY (EmployeeId),
	FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
	FOREIGN KEY (FunctionId) REFERENCES Functions(FunctionId)
);

CREATE TABLE Departments (
	DepartmentId INT IDENTITY(1,1),
	DepartmentName VARCHAR(100) NOT NULL,
	PRIMARY KEY (DepartmentId)
);

CREATE TABLE Functions (
	FunctionId INT IDENTITY(1,1),
	FunctionName VARCHAR(100) NOT NULL,
	PRIMARY KEY (FunctionId)
);

-- Seed the db

INSERT INTO Departments (DepartmentName) VALUES 
('Human Resources'),
('Finance'),
('IT'),
('Research and Development'),
('Marketing');

INSERT INTO Functions (FunctionName) VALUES 
('Manager'),
('Analyst'),
('Developer'),
('Technician'),
('Consultant');

INSERT INTO Employees (DepartmentId, FunctionId, PostTitle, FirstName, LastName, BirthDate, EmploymentDate, Salary) VALUES
(1, 1, 'Senior HR Advisor', 'John', 'Smith', '1949-06-15', '1990-03-01', 12000),
(2, 2, 'Financial Consultant', 'Barbara', 'Miller', '1945-09-23', '1985-07-15', 15000),
(3, 3, 'Senior Developer', 'George', 'Taylor', '1948-02-10', '1992-08-01', 18000),
(4, 4, 'Lead Technician', 'Martha', 'Anderson', '1947-12-30', '1980-05-23', 9000),
(5, 5, 'Senior Marketing Specialist', 'Frank', 'White', '1944-01-20', '1982-04-19', 27000),

(1, 1, 'HR Coordinator', 'Emily', 'Johnson', '1988-07-12', '2015-03-20', 5500),
(2, 2, 'Junior Analyst', 'Michael', 'Brown', '1992-04-01', '2019-06-17', 6200),
(3, 3, 'Backend Developer', 'David', 'Davis', '1990-12-21', '2016-09-01', 7500),
(4, 4, 'IT Support', 'Susan', 'Wilson', '1985-11-30', '2013-11-03', 4800),
(5, 5, 'Marketing Intern', 'James', 'Martinez', '2000-10-10', '2023-01-10', 3200);

-- Db tasks:

-- Task1
-- Scrieți și atașați scripturi pentru: selectarea tuturor angajaților
SELECT EmployeeId, DepartmentName, FunctionName, PostTitle, 
	FirstName, LastName, BirthDate, EmploymentDate, Salary
FROM Employees empl
	JOIN Departments dep ON dep.DepartmentId = empl.DepartmentId
	JOIN Functions func ON func.FunctionId = empl.FunctionId

-- Task2
-- Angajații al căror salariu este mai mare de 10.000
SELECT EmployeeId, DepartmentName, FunctionName, PostTitle, 
	FirstName, LastName, BirthDate, EmploymentDate, Salary
FROM Employees empl
	JOIN Departments dep ON dep.DepartmentId = empl.DepartmentId
	JOIN Functions func ON func.FunctionId = empl.FunctionId
WHERE Salary > 10000

-- Task3
-- Stergerea angajaților cu vârsta peste 70 de ani
DELETE Employees 
	WHERE BirthDate < DATEADD(YEAR, -70, GETDATE())

-- Task4
-- Actualizarea salariului la 15.000 pentru acei angajați al căror salariu este mai mic
UPDATE Employees SET Salary = 15000 WHERE Salary < 15000
