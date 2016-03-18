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

CREATE TABLE ComplexSourceOne
(
	Id INT PRIMARY KEY,
	ComplexColumnOne NVARCHAR(1000)
)


CREATE TABLE ComplexSourceTwo
(
	Id INT PRIMARY KEY,
	ComplexSourceOneForeignKey INT FOREIGN KEY REFERENCES ComplexSourceOne(Id),
	ComplexColumnOne NVARCHAR(1000),
	ComplexColumnTwo NVARCHAR(1000),
	ComplexColumnThree NVARCHAR(1000),
	ComplexColumnFour NVARCHAR(1000),
	ComplexColumnFive NVARCHAR(1000),
	ComplexColumnSix NVARCHAR(1000),
	ComplexColumnSeven NVARCHAR(1000),
	ComplexColumnEight NVARCHAR(1000),
	ComplexColumnNine NVARCHAR(1000),
	ComplexColumnNotCopied NVARCHAR(1000)
)

CREATE TABLE ComplexSourceThree
(
	Id INT PRIMARY KEY,
	ComplexSourceOneForeignKey INT FOREIGN KEY REFERENCES ComplexSourceOne(Id),
	ComplexSourceTwoForeignKey INT FOREIGN KEY REFERENCES ComplexSourceTwo(Id),
	ComplexColumnOne NVARCHAR(1000)
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
	Id INT PRIMARY KEY,
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

CREATE TABLE ComplexDestinationOne
(
	Id INT PRIMARY KEY,
	ComplexColumnOne NVARCHAR(1000)
)

CREATE TABLE ComplexDestinationTwo
(
	Id INT PRIMARY KEY,
	ComplexDestinationOneForeignKey INT FOREIGN KEY REFERENCES ComplexDestinationOne(Id),
	ComplexColumnOne NVARCHAR(1000),
	ComplexColumnTwo NVARCHAR(1000),
	ComplexColumnThree NVARCHAR(1000),
	ComplexColumnFour NVARCHAR(1000),
	ComplexColumnFive NVARCHAR(1000),
	ComplexColumnSix NVARCHAR(1000),
	ComplexColumnSeven NVARCHAR(1000),
	ComplexColumnEight NVARCHAR(1000),
	ComplexColumnNine NVARCHAR(1000),
	ComplexColumnNotCopiedInto NVARCHAR(1000)
)

CREATE TABLE ComplexDestinationThree
(
	Id INT PRIMARY KEY IDENTITY(1000,1),
	ComplexDestinationOneForeignKey INT FOREIGN KEY REFERENCES ComplexDestinationOne(Id),
	ComplexDestinationTwoForeignKey INT FOREIGN KEY REFERENCES ComplexDestinationTwo(Id),
	ComplexColumnOne NVARCHAR(1000)
)