﻿USE master
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

CREATE TABLE PerformanceDestination
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