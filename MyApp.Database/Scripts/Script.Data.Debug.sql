INSERT INTO [dbo].[Role] ([Id],[Name]) VALUES ('9E5388AE-06D0-46E2-975C-702A31F89318', 'Basic')
INSERT INTO [dbo].[Role] ([Id],[Name]) VALUES ('C6C0497C-3677-4732-9B23-9F26B96C958C', 'Admin')

INSERT INTO [dbo].[User] ([Id],[Name],[Active],[Email],[RoleId], [Password], [PasswordSalt]) VALUES ('4B691A00-D828-4360-9B9D-12655741CF06','Admin',1,'admin@myapp.com','C6C0497C-3677-4732-9B23-9F26B96C958C','Bp/ZXw+u8zCo5ZvF+aFWRo2VJTz+d5Ti6uHsdhX7vss=','6/OB1cUMpONQztveRjvWiQ==')