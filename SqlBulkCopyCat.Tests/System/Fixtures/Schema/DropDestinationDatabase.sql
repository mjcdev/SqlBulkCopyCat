USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='BulkCopyCatTestsDestination')
BEGIN
	ALTER DATABASE BulkCopyCatTestsDestination
	SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE

	DROP DATABASE BulkCopyCatTestsDestination
END