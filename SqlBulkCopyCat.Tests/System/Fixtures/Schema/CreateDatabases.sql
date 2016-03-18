USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='BulkCopyCatTestsSource')
BEGIN
	ALTER DATABASE BulkCopyCatTestsSource
	SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE

	DROP DATABASE BulkCopyCatTestsSource
END

GO

CREATE DATABASE BulkCopyCatTestsSource

GO

USE BulkCopyCatTestsSource
GO
	CREATE SCHEMA Source
GO

CREATE TABLE SimpleSource
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	SourceColumn NVARCHAR(1000)
)

CREATE TABLE Source.SimpleSource
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	SourceColumn NVARCHAR(1000)
)


CREATE TABLE DataTypesSource
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NvarcharType NVARCHAR(1000),
	VarcharType VARCHAR(1000),
	CharType CHAR(1000),
	DecimalType DECIMAL,
	FloatType FLOAT,
	IntType INT,
	BigIntType BIGINT,
	BitType BIT,
	DateType DATE,
	DateTimeType DATETIME,
	VarbinaryType VARBINARY(MAX)
)

GO

CREATE VIEW SimpleSourceView AS SELECT SourceColumn AS SourceViewColumn FROM SimpleSource

GO





USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='BulkCopyCatTestsDestination')
BEGIN
	ALTER DATABASE BulkCopyCatTestsDestination
	SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE

	DROP DATABASE BulkCopyCatTestsDestination
END

GO

CREATE DATABASE BulkCopyCatTestsDestination

GO

USE BulkCopyCatTestsDestination
GO
	CREATE SCHEMA Destination

GO

CREATE TABLE SimpleDestination
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DestinationColumn NVARCHAR(1000)
)

CREATE TABLE Destination.SimpleDestination
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DestinationColumn NVARCHAR(1000)
)

CREATE TABLE DataTypesDestination
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NvarcharType NVARCHAR(1000),
	VarcharType VARCHAR(1000),
	CharType CHAR(1000),
	DecimalType DECIMAL,
	FloatType FLOAT,
	IntType INT,
	BigIntType BIGINT,
	BitType BIT,
	DateType DATE,
	DateTimeType DATETIME,
	VarbinaryType VARBINARY(MAX)
)