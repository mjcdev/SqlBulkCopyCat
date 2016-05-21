using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SqlBulkCopyCat")]
[assembly: AssemblyDescription("SqlBulkCopyCat(alogue) - a configurable wrapper around the SqlBulkCopy .net Class supporting copying of data between databases.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("mjcdev")]
[assembly: AssemblyProduct("SqlBulkCopyCat")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("4fe4d705-7101-4943-89df-9c5f9b0d9042")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.2.0.0")]
[assembly: AssemblyFileVersion("0.2.0.0")]

//Expose Internals to Unit Test Project.
[assembly: InternalsVisibleTo("SqlBulkCopyCat.Tests")]
//Exposer Internals to Moq.
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: NeutralResourcesLanguage("en")]

