﻿USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='BulkCopyCatTestsSource')
BEGIN
	ALTER DATABASE BulkCopyCatTestsSource
	SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE

	DROP DATABASE BulkCopyCatTestsSource
END