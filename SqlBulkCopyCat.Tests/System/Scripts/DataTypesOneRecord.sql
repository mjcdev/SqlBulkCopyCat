TRUNCATE TABLE BulkCopyCatTestsSource.dbo.DataTypesSource

TRUNCATE TABLE BulkCopyCatTestsDestination.dbo.DataTypesDestination

INSERT INTO BulkCopyCatTestsSource.dbo.DataTypesSource 
(
	NvarcharType,
	VarcharType,
	CharType,
	DecimalType,
	FloatType,
	IntType,
	BigIntType,
	BitType,
	DateType,
	DateTimeType,
	VarbinaryType
)
VALUES
(
	'Nvarchar',
	'Varchar',
	'Char',
	10.1,
	11.1,
	1234,
	12345678910,
	1,
	'10/02/1988',
	'10/02/1988 12:23:20',
	0x010203040506
)