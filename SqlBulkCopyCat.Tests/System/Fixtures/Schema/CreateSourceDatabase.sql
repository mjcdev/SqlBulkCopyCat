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

CREATE TABLE PerformanceSource
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Column1 NVARCHAR(1000),
	Column2 NVARCHAR(1000),
	Column3 NVARCHAR(1000),
	Column4 NVARCHAR(1000),
	Column5 NVARCHAR(1000),
	Column6 NVARCHAR(1000),
	Column7 NVARCHAR(1000),
	Column8 NVARCHAR(1000),
	Column9 NVARCHAR(1000),
	Column10 NVARCHAR(1000),
	Column11 NVARCHAR(1000),
	Column12 NVARCHAR(1000),
	Column13 NVARCHAR(1000),
	Column14 NVARCHAR(1000),
	Column15 NVARCHAR(1000),
	Column16 NVARCHAR(1000),
	Column17 NVARCHAR(1000),
	Column18 NVARCHAR(1000),
	Column19 NVARCHAR(1000),
	Column21 NVARCHAR(1000),
	Column22 NVARCHAR(1000),
	Column23 NVARCHAR(1000),
	Column24 NVARCHAR(1000),
	Column25 NVARCHAR(1000),
	Column26 NVARCHAR(1000),
	Column27 NVARCHAR(1000),
	Column28 NVARCHAR(1000),
	Column29 NVARCHAR(1000),
	Column31 NVARCHAR(1000),
	Column32 NVARCHAR(1000),
	Column33 NVARCHAR(1000),
	Column34 NVARCHAR(1000),
	Column35 NVARCHAR(1000),
	Column36 NVARCHAR(1000),
	Column37 NVARCHAR(1000),
	Column38 NVARCHAR(1000),
	Column39 NVARCHAR(1000),
	Column40 NVARCHAR(1000)
)

GO

CREATE VIEW SimpleSourceView AS SELECT SourceColumn AS SourceViewColumn FROM SimpleSource

GO

CREATE PROCEDURE DoublePerformanceTable
AS
	INSERT INTO BulkCopyCatTestsSource.dbo.PerformanceSource
	(	
		Column1,
		Column2,
		Column3,
		Column4,
		Column5,
		Column6,
		Column7,
		Column8,
		Column9,
		Column10,
		Column11,
		Column12,
		Column13,
		Column14,
		Column15,
		Column16,
		Column17,
		Column18,
		Column19,
		Column21,
		Column22,
		Column23,
		Column24,
		Column25,
		Column26,
		Column27,
		Column28,
		Column29,
		Column31,
		Column32,
		Column33,
		Column34,
		Column35,
		Column36,
		Column37,
		Column38,
		Column39,
		Column40
	)
	SELECT 
		Column1,
		Column2,
		Column3,
		Column4,
		Column5,
		Column6,
		Column7,
		Column8,
		Column9,
		Column10,
		Column11,
		Column12,
		Column13,
		Column14,
		Column15,
		Column16,
		Column17,
		Column18,
		Column19,
		Column21,
		Column22,
		Column23,
		Column24,
		Column25,
		Column26,
		Column27,
		Column28,
		Column29,
		Column31,
		Column32,
		Column33,
		Column34,
		Column35,
		Column36,
		Column37,
		Column38,
		Column39,
		Column40
	FROM BulkCopyCatTestsSource.dbo.PerformanceSource

GO