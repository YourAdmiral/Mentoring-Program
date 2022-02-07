CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [AddressId] INT NOT NULL,
    CONSTRAINT [FK_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
