use BridgeLabz;

select * from Student;

-- Stored Procedure
/*
	CREATE PROCEDURE <ProcedureName (ColumnName datatype)>
	AS
	BEGIN
	<Query>
	<Query>
	END;
*/


CREATE PROCEDURE GetAllStudent
AS
BEGIN
SELECT * FROM Student;
END;

-- EXEC <ProcedureName>
EXEC GetAllStudent;

-- Stored Procedure To Add Student
CREATE PROCEDURE AddStudent(@Id INT,@Sname VARCHAR(20), @Age INT)
AS
BEGIN
INSERT INTO Student VALUES
(@Id,@Sname,@Age);
END;

EXEC AddStudent 1, 'Harsh',21;
EXEC AddStudent 2, 'ABC',22;
EXEC AddStudent 3, 'Aryan',22;
EXEC AddStudent 4, 'Satyam',21;


-- Stored Procudure To Update Student By Id
CREATE PROCEDURE UpdateStudent(@Id INT,@NewName VARCHAR(20),@NewAge INT) AS
BEGIN
UPDATE Student SET Sname=@NewName, Age=@NewAge Where Id=@Id;
END;

EXEC UpdateStudent 2,'Kartik',22;

-- Stored Procudure To Remove Student By Id and Name
CREATE PROCEDURE DeleteStudent(@Id INT)
AS
BEGIN
DELETE FROM Student WHERE Id = @Id;
END;

-- Modifing DeleteStudent Procedure to accept both Id and Name
/*
ALTER PROCEDURE <ProcedureName(ColumnName Datatype)
AS
BEGIN
<Query>
END;
*/

ALTER PROCEDURE DeleteStudent(@Id INT,@Sname VARCHAR(20))
AS
BEGIN
DELETE FROM Student WHERE Id = @Id and Sname = @Sname;
END;

EXEC DeleteStudent 2,'ABC'; 

-- STORED PROCEDURES WITH 

