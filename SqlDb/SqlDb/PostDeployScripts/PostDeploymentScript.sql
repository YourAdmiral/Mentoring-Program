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
INSERT INTO Person(Id, FirstName, LastName)
VALUES (1, 'Alex','Smith'),
(2, 'Robert','Cooper'),
(3, 'Katelyn','Black'),
(4, 'Jessica','Stein');

INSERT INTO Address(Id, Street, City, State, ZipCode)
VALUES (1, 'West st.','Austin', 'Texas', '54452'),
(2, 'Some st.','Houston', 'Texas', '23411'),
(3, 'Walker st.','Dallas', 'San Antonio', '54452'),
(4, 'Green st.','Tampa', 'Florida', '741123');

INSERT INTO Company(Id, Name, AddressId)
VALUES (1, 'Google',4),
(2, 'Amazon', 3),
(3, 'Apple', 2),
(4, 'Microsoft', 1);

INSERT INTO Employee(Id, AddressId, PersonId, CompanyName, Position, EmployeeName)
VALUES (1, 4, 1, 'Google', 'Software Engineer', 'Alex'),
(2, 3, 2,'Amazon', 'Economist', 'Robert'),
(3, 2, 3, 'Apple', 'Director', 'Katelyn'),
(4, 1, 4, 'Microsoft', 'Support engineer', 'Jessica');
