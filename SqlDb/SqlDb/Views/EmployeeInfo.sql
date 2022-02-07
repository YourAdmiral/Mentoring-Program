CREATE VIEW [dbo].[EmployeeInfo]
	AS 
	SELECT 
	e.Id,
	CASE
	WHEN e.EmployeeName IS NOT NULL THEN e.EmployeeName
	ELSE CONCAT(p.FirstName, ' ', p.LastName)
	END AS EmployeeFullName,
	CONCAT(a.ZipCode, '_', a.State, ',', a.City, '-', a.Street) AS EmployeeFullAddress, 
	CONCAT(c.Name, '(', e.Position, ')') AS EmployeeCompanyInfo
	FROM dbo.Employee e
	LEFT JOIN dbo.Person p ON p.Id = e.PersonId
	LEFT JOIN dbo.Address a ON a.Id = e.AddressId
	LEFT JOIN dbo.Company c ON c.Name = e.CompanyName
