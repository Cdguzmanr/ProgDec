﻿/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

Drop Table IF EXISTS tblDegreeType
Drop Table IF EXISTS tblProgram
Drop Table IF EXISTS tblStudents
Drop Table IF EXISTS tblDeclaration
Drop Table IF EXISTS tblUser
Drop Table IF EXISTS tblStudentAdvisor
Drop Table IF EXISTS tblAdvisor