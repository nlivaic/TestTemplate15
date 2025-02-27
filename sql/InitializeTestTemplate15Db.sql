USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TestTemplate15Db')
BEGIN
  CREATE DATABASE TestTemplate15Db;
END;
GO

USE TestTemplate15Db;
GO

IF NOT EXISTS (SELECT 1
                 FROM sys.server_principals
                WHERE [name] = N'TestTemplate15Db_Login' 
                  AND [type] IN ('C','E', 'G', 'K', 'S', 'U'))
BEGIN
    CREATE LOGIN TestTemplate15Db_Login
        WITH PASSWORD = '<DB_PASSWORD>';
END;
GO  

IF NOT EXISTS (select * from sys.database_principals where name = 'TestTemplate15Db_User')
BEGIN
    CREATE USER TestTemplate15Db_User FOR LOGIN TestTemplate15Db_Login;
END;
GO  


EXEC sp_addrolemember N'db_datareader', N'TestTemplate15Db_User';
GO

EXEC sp_addrolemember N'db_datawriter', N'TestTemplate15Db_User';
GO

EXEC sp_addrolemember N'db_ddladmin', N'TestTemplate15Db_User';
GO
