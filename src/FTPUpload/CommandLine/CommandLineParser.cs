using Common.Core.DependencyInjection;
using FTP.CommandLine.Commands;
using System.CommandLine;

namespace FTPUpload.CommandLine;

[ServiceLocate(default, ServiceType.Scoped)]
public class CommandLineParser
{
    private readonly IEnumerable<ICommandDefinition> _commandDefinitions;

    public CommandLineParser(IEnumerable<ICommandDefinition> commandDefinitions)
    {
        _commandDefinitions = commandDefinitions;
    }

    public ParseResult Parse(string[] args)
    {
        // Define commands
        var rootCommand = new RootCommand("FTP Client");

        foreach (var commandDefinition in _commandDefinitions)
        {
            rootCommand.Subcommands.Add(commandDefinition.Create());
        }

        var parseResult = rootCommand.Parse(args);

        return parseResult;
    }
}
