CREATE DATABASE [AUTOMATIC_TEST_CONNECTION] 
GO
USE [AUTOMATIC_TEST_CONNECTION]
GO 
CREATE TABLE [AUTOMATIC_TEST_CONNECTION_1] (C1 CHAR(25), C2 CHAR(25))
GO
INSERT INTO [AUTOMATIC_TEST_CONNECTION_1] VALUES('TEST1', 'TEST2')
GO
SELECT C1, C2 FROM [AUTOMATIC_TEST_CONNECTION_1]
GO
