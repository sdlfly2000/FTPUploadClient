// Example:
// FTP upload --host ftp.example.com --username user --password pass --remotePath /upload/file.txt --localFilePath C:\file.txt

using Common.Core.DependencyInjection;
using FTP;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.RegisterDomain("FTPClient");

using var serviceProvider = serviceCollection.BuildServiceProvider();
var worker = serviceProvider.GetRequiredService<Worker>();

await worker.Execute(args);



