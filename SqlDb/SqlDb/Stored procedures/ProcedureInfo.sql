CREATE PROCEDURE [dbo].[ProcedureInfo]
	@Id INT = 5,
	@EmployeeName NVARCHAR(100) = NULL,
	@FirstName NVARCHAR(50) = 'Joseph',
	@LastName NVARCHAR(50) = 'Norton',
	@CompanyName NVARCHAR(20) = 'Epam',
	@Position NVARCHAR(30) = 'Automation tester',
	@Street NVARCHAR(50) = 'Soft st.',
	@City NVARCHAR(20) = 'Miami',
	@State NVARCHAR(50) = 'Florida',
	@ZipCode NVARCHAR(50) = '400919'
AS
BEGIN
SET NOCOUNT ON

INSERT INTO Person(Id, FirstName, LastName)
VALUES (@Id, @FirstName, @LastName);

INSERT INTO Address(Id, Street, City, State, ZipCode)
VALUES (@Id, @Street, @City, @State, @ZipCode);

INSERT INTO Company(Id, Name, AddressId)
VALUES (@Id, @CompanyName, @Id);

INSERT INTO Employee(Id, AddressId, PersonId, CompanyName, Position, EmployeeName)
VALUES (@Id, @Id, @Id, @CompanyName, @Position, @EmployeeName);

END

GO
