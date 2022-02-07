CREATE TRIGGER [EmployeeInsertTrigger]
	ON [dbo].[Employee]
	AFTER INSERT
	AS
	BEGIN
		DECLARE @Id int
		DECLARE @AddressId int
		DECLARE @CompanyName NVARCHAR(20)
		
		SELECT @Id = Max(e.Id)+1
		FROM Employee e
		SELECT @AddressId = inserted.AddressId
		FROM inserted
		SELECT @CompanyName = inserted.CompanyName
		FROM inserted

		INSERT INTO Company(Id, AddressId, Name)
		VALUES(@Id, @AddressId, @CompanyName)
	END
