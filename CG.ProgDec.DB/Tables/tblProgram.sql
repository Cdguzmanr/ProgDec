CREATE TABLE [dbo].[tblProgram]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(50) NOT NULL,
	[DegreeTypeId] INT NOT NULL, 
    [ImagePath] VARCHAR(MAX) NOT NULL
)