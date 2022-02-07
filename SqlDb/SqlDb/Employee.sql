CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AddressId] INT NOT NULL, 
    [PersonId] INT NOT NULL, 
    CONSTRAINT [FK_Employee_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]),
    CONSTRAINT [FK_Employee_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]),
    [CompanyName] NVARCHAR(20) NULL, 
    [Position] NVARCHAR(30) NULL, 
    [EmployeeName] NVARCHAR(100) NULL
)
