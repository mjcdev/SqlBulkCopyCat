DELETE FROM BulkCopyCatTestsSource.dbo.ComplexSourceOne
DELETE FROM BulkCopyCatTestsSource.dbo.ComplexSourceTwo
DELETE FROM BulkCopyCatTestsSource.dbo.ComplexSourceThree

DELETE FROM BulkCopyCatTestsDestination.dbo.ComplexDestinationOne
DELETE FROM BulkCopyCatTestsDestination.dbo.ComplexDestinationTwo
DELETE FROM BulkCopyCatTestsDestination.dbo.ComplexDestinationThree

INSERT INTO BulkCopyCatTestsSource.dbo.ComplexSourceOne
(
	Id,
	ComplexColumnOne
)
VALUES
(
	1,
	'ComplexValueOne'
)


INSERT INTO BulkCopyCatTestsSource.dbo.ComplexSourceTwo
(
	Id,
	ComplexSourceOneForeignKey,
	ComplexColumnOne,
	ComplexColumnTwo,
	ComplexColumnThree,
	ComplexColumnFour,
	ComplexColumnFive,
	ComplexColumnSix,
	ComplexColumnSeven,
	ComplexColumnEight,
	ComplexColumnNine
)
VALUES
(
	1,
	1,
	'ComplexValueOne',
	'ComplexValueTwo',
	'ComplexValueThree',
	'ComplexValueFour',
	'ComplexValueFive',
	'ComplexValueSix',
	'ComplexValueSeven',
	'ComplexValueEight',
	'ComplexValueNine'
)

INSERT INTO BulkCopyCatTestsSource.dbo.ComplexSourceThree
(
	Id,
	ComplexSourceOneForeignKey,
	ComplexSourceTwoForeignKey,
	ComplexColumnOne
)
VALUES
(
	1,
	1,
	1,
	'ComplexValueOne'
)
