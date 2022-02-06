/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Employee(Id, AddressId, CompanyName, 
Position, EmployeeName)
VALUES 
(1, 4,'Google', 'Software Engineer', 'Alex'),
(2, 3,'Amazon', 'Economist', 'Robert'),
(3, 2,'Apple', 'Director', 'Katelyn'),
(4, 1,'Microsoft', 'Support engineer', 'Jessica');