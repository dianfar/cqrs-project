﻿CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[Active] BIT NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[RoleId] UNIQUEIDENTIFIER NOT NULL,
	[Password] VARCHAR(128) NOT NULL,
	[PasswordSalt] VARCHAR(64) NOT NULL,
	CONSTRAINT [FK_User_ToRole] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id])
)
