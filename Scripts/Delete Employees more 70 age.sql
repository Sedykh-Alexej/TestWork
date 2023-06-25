USE [TestWork]
GO

UPDATE [dbo].[Employee]
 SET InState = 'false'
 WHERE DATEDIFF(year,Birthday,Sysdatetime())>70    

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

