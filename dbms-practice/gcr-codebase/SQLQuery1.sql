-- DDL : Data Definition Language

-- CREATE DATABASE/TABLE/VIEW <Name>
CREATE DATABASE BridgeLabz;

-- USE <Database_Name>;
USE BridgeLabz;

-- CREATE TABLE <TableName> (ColumnName DataType);
CREATE TABLE Student(
	Id int PRIMARY KEY,
	Sname varchar(50)
);

-- SELECT <ColumnNames/*> FROM <TableName>;
SELECT * FROM Student;

-- ALTER TABLE <TableName> ADD <ColumnName> <DataType>;
ALTER TABLE Student ADD Age int;


-- DROP TABLE <TableName>;
DROP TABLE Student;

--------------------------------------------------------------------

-- DML – Data Manipulation Language

-- INSERT INTO <TableName> (ColumnNames) VALUES (Values);
INSERT INTO Student (Id,Sname,Age) VALUES 
	(1,'Harsh',21),
	(2,'Kartik',25);


-- UPDATE <TableName> SET <ColumnName> = <Value> WHERE <Condition>;
UPDATE Student SET Age = 22 Where Id = 2;


-- DELETE FROM <TableName> WHERE <Condition>;
DELETE FROM Student WHERE Id = 1;


--------------------------------------------------------------------
-- DQL – Data Query Language

-- SELECT <ColumnNames/*> FROM <TableName>;
SELECT * FROM Student;

-- SELECT <ColumnName1, ColumnName2> FROM <TableName>;
SELECT Sname,Age From Student;


--------------------------------------------------------------------
-- TCL – Transaction Control Language


-- BEGIN TRANSACTION;
BEGIN TRANSACTION;
UPDATE Student SET Age = 25 Where Id = 2

-- SAVE TRANSACTION <SavepointName>;
SAVE TRANSACTION sp1;
INSERT INTO Student (Id,Sname,Age) VALUES (1,'Harsh',21)

-- ROLLBACK TRANSACTION <SavepointName>;
ROLLBACK TRANSACTION sp1

-- COMMIT
COMMIT;

-- DCL – Data Control Language

USE master;

GO
-- CREATE LOGIN <LoginName> WITH PASSWORD = '<Password>';
CREATE LOGIN Goyal WITH PASSWORD = '123';
CREATE LOGIN Honey WITH PASSWORD = '123';
GO

USE BridgeLabz;

GO
-- CREATE USER <UserName> FOR LOGIN <LoginName>;
CREATE USER UserGoyal FOR LOGIN Goyal;
CREATE USER UserHoney FOR LOGIN Honey; 
GO

-- GRANT <Permission> ON <TableName> TO <UserName>;
GRANT SELECT ON Student TO UserGoyal;
-- REVOKE <Permission> ON <TableName> FROM <UserName>;
REVOKE SELECT ON Student FROM UserHoney;


