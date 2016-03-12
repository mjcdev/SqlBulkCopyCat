USE BulkCopyCatTestsSource

CREATE TABLE SimpleSource
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	SourceColumn NVARCHAR(1000)
)

USE BulkCopyCatTestsDestination

CREATE TABLE SimpleDestination
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DestinationColumn NVARCHAR(1000)
)