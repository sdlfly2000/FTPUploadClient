using Common.Core.DependencyInjection;
using FTPUpload.CommandLine;

namespace FTP;

[ServiceLocate(default, ServiceType.Scoped)]
public class Worker
{
    private readonly CommandLineParser _parser;

    public Worker(CommandLineParser parser)
    {
        _parser = parser;
    }

    public async Task Execute(string[] args)
    {
        var parseResult = _parser.Parse(args);

        await parseResult.InvokeAsync();
    }
}
