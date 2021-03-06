# SqlBulkCopyCat

SqlBulkCopyCat(alogue), a Configurable wrapper around SqlBulkCopy for transferring data between SQL Server Instances for .Net applications.

Supporting Configuration by:
- JSON
- XML
- Config Domain Objects

[Now Available on NuGet](https://www.nuget.org/packages/SqlBulkCopyCat/)

[Twitter](https://twitter.com/mikechilds88) :+1:
[Blog](http://mjcdev.co.uk) :+1:

### To Do

- [X] Initial Catalog outside of Connection String Configuration
- [X] Table Order
- [X] Nuget Package
- [X] Notify after X Event Handler
- [ ] Extensibility Points

## Examples

Check out the Unit Test Project for further working examples of SqlBulkCopyCat usage.

### API

Broadly:
- Build Config from source;
- Instantiate SqlBulkCopyCat with Config;
- Copy.

```csharp
var config = new CopyCatConfigBuilder().FromXmlFile(configFilePath);

var copyCat = new CopyCat(config);

copyCat.Copy();
```

### Table Configuration

You can easily copy whole tables...

```xml
<?xml version="1.0"?>
<CopyCatConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <SourceConnectionString>Data Source=(local)\SQLExpress;Initial Catalog=BulkCopyCatSource;Integrated Security=True</SourceConnectionString>
  <DestinationConnectionString>Data Source=(local)\SQLExpress;Initial Catalog=BulkCopyCatDestination;Integrated Security=True</DestinationConnectionString>
  <TableMappings>
    <TableMapping>
      <Source>SimpleSource</Source>
      <Destination>SimpleDestination</Destination>
    </TableMapping>
  </TableMappings>
</CopyCatConfig>
```

### Column Configuration

...or pick a subset of columns.

```xml
<?xml version="1.0"?>
<CopyCatConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <SourceConnectionString>SourceConnectionString</SourceConnectionString>
  <DestinationConnectionString>DestinationConnectionString</DestinationConnectionString>
  <TableMappings>
    <TableMapping>
      <Source>SimpleSource</Source>
      <Destination>SimpleDestination</Destination>
      <ColumnMappings>
        <ColumnMapping>
          <Source>SourceColumn</Source>
          <Destination>DestinationColumn</Destination>
        </ColumnMapping>
      </ColumnMappings>
    </TableMapping>
  </TableMappings>
</CopyCatConfig>
```

### Settings

SqlBulkCopy configuration settings can be altered through configuration for your use case.

```xml
<?xml version="1.0"?>
<CopyCatConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <SqlBulkCopySettings>
    <BatchSize>300</BatchSize>
    <BulkCopyTimeout>1000</BulkCopyTimeout>
    <EnableStreaming>false</EnableStreaming>
    <SqlBulkCopyOptions>20</SqlBulkCopyOptions>
  </SqlBulkCopySettings>
  <TableMappings />
  <SqlTransaction>false</SqlTransaction>
</CopyCatConfig>
```

## License

MIT
