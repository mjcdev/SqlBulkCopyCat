TRUNCATE TABLE BulkCopyCatTestsSource.dbo.SimpleSource

TRUNCATE TABLE BulkCopyCatTestsDestination.dbo.SimpleDestination

INSERT INTO BulkCopyCatTestsSource.dbo.SimpleSource (SourceColumn) VALUES ('Source Data')