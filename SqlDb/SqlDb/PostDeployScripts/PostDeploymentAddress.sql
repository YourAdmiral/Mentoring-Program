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
INSERT INTO Address(Id, Street, City, State, ZipCode)
VALUES 
(1, 'West st.','Austin', 'Texas', '54452'),
(2, 'Some st.','Houston', 'Texas', '23411'),
(3, 'Walker st.','Dallas', 'San Antonio', '54452'),
(4, 'Green st.','Tampa', 'Florida', '741123');