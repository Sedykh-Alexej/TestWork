USE [TestWork]
GO

UPDATE [dbo].[Employee]
   SET Wages=15000
 WHERE Wages<15000

 SELECT 
       [Surname]
      ,[Name]
      ,[Patronymic]
      ,[Birthday]
      ,[DateOfEmployment]
      ,[Wages]
      ,[Departament]
  FROM [dbo].[Employee]
  Where InState = 'true'
GO

