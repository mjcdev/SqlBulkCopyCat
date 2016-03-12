TRUNCATE TABLE BulkCopyCatTestsSource.dbo.SimpleSource
TRUNCATE TABLE BulkCopyCatTestsSource.Source.SimpleSource

TRUNCATE TABLE BulkCopyCatTestsDestination.dbo.SimpleDestination
TRUNCATE TABLE BulkCopyCatTestsDestination.Destination.SimpleDestination

INSERT INTO BulkCopyCatTestsSource.dbo.SimpleSource (SourceColumn) VALUES ('Source Data')
INSERT INTO BulkCopyCatTestsSource.Source.SimpleSource (SourceColumn) VALUES ('Source Schema Source Data')