using System.CommandLine;

namespace FTP.CommandLine.Commands;

public interface ICommandDefinition
{
    public Command Create();
}
