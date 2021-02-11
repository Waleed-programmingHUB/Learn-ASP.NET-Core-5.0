/*
CREATE DATABASE RazorView_ASPNETCore
GO
	USE [RazorView_ASPNETCore]
GO

CREATE TABLE [dbo].[Student](
	[roll_number][int] PRIMARY KEY IDENTITY(1,1) NOT NULL ,
	[name][nvarchar] (60) NULL,
	[subjects][nvarchar] (100) NULL,
	[class_name][nvarchar] (20) NULL,
	[DateOfBirth][datetime] NULL
)
*/
/*
/* Procedure */
CREATE PROCEDURE usp_Student_GetAllStudents
AS
	BEGIN
		SELECT * FROM Student
End
*/
/*
CREATE PROCEDURE usp_Student_InsertStudent(
			@name			NVARCHAR(60)
           ,@subjects		NVARCHAR(100)	
           ,@class_name		NVARCHAR(20)
           ,@DateOfBirth	DATETIME
)
AS
	BEGIN
		INSERT INTO [dbo].[Student]
				   ([name]
				   ,[subjects]
				   ,[class_name]
				   ,[DateOfBirth])
			 VALUES
				   (@name
				   ,@subjects
				   ,@class_name
				   ,@DateOfBirth)
	END
GO
*/
/* For Update Procedure */

--CREATE PROCEDURE usq_Student_Update(
--			@roll_number	INT,
--			@name			NVARCHAR(60)
--           ,@subjects		NVARCHAR(100)	
--           ,@class_name		NVARCHAR(20)
--           ,@DateOfBirth	DATETIME
--)
--AS
--	BEGIN
--		UPDATE [dbo].[Student]
--		   SET [name] = @name, 
--			  [subjects] = @subjects,
--			  [class_name] = @class_name, 
--			  [DateOfBirth] = @DateOfBirth
--		 WHERE [roll_number] = @roll_number
--	END
--GO


/* For Delete Porcedure */
/*
CREATE PROCEDURE usp_Student_DeleteStudent(
			@roll_number	INT
)
AS
	BEGIN
		DELETE FROM [dbo].[Student] WHERE [roll_number] = @roll_number
	END
GO
*/

/* For Delete Porcedure */
/*
CREATE PROCEDURE usp_Student_DPrintStudent(
			@roll_number	INT
)
AS
	BEGIN
		DELETE FROM [dbo].[Student] WHERE [roll_number] = @roll_number
	END
GO
*/