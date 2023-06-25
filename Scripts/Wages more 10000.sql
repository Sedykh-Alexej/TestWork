USE [TestWork]
GO

SELECT 
       [Surname]
      ,[Name]
      ,[Patronymic]
      ,[Birthday]
      ,[DateOfEmployment]
      ,[Wages]
      ,[Departament]
  FROM [dbo].[Employee]
  Where Wages>10000 and InState = 'True'

GO

