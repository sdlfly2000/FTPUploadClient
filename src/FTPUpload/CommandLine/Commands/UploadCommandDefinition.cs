using Common.Core.DependencyInjection;
using FTP.Services;
using System.CommandLine;
using System.Diagnostics;

namespace FTP.CommandLine.Commands;

[ServiceLocate(typeof(ICommandDefinition), ServiceType.Scoped)]
public class UploadCommandDefinition : ICommandDefinition
{
    private Option<string>? _hostOption;
    private Option<string>? _userNameOption;
    private Option<string>? _pwdOption;
    private Option<string>? _remotePath;
    private Option<string>? _localFileOption;

    private readonly IFTPService _ftpService;

    public UploadCommandDefinition(IFTPService ftpService)
    {
        _ftpService = ftpService;
    }

    public Command Create()
    {
        _hostOption = new Option<string>("--host", "-h")
        {
            Required = true,
            Description = "FTP Server Host"
        };

        _userNameOption = new Option<string>("--userName", "-u")
        {
            Required = true,
            Description = "User Name"
        };

        _pwdOption = new Option<string>("--password", "-p")
        {
            Required = true,
            Description = "Password"
        };

        _remotePath = new Option<string>("--remotePath", "-r")
        {
            Required = true,
            Description = "path on FTP Server"
        };

        _localFileOption = new Option<string>("--localFile", "-l")
        {
            Required = true,
            Description = "local file path to upload"
        };

        var uploadCommand = new Command("upload", "operation on image")
        {
            _hostOption,
            _userNameOption,
            _pwdOption,
            _remotePath,
            _localFileOption
        };

        uploadCommand.SetAction(Action);

        return uploadCommand;
    }

    private async Task Action(ParseResult parseResult, CancellationToken token)
    {
        Debug.Assert(_hostOption is not null);
        Debug.Assert(_userNameOption is not null);
        Debug.Assert(_pwdOption is not null);
        Debug.Assert(_remotePath is not null);
        Debug.Assert(_localFileOption is not null);

        var host = parseResult.GetResult(_hostOption)?.GetValueOrDefault<string>() ?? string.Empty;
        var userName = parseResult.GetResult(_userNameOption)?.GetValueOrDefault<string>() ?? string.Empty;
        var pwd = parseResult.GetResult(_pwdOption)?.GetValueOrDefault<string>() ?? string.Empty;
        var remotePath = parseResult.GetResult(_remotePath)?.GetValueOrDefault<string>() ?? string.Empty;
        var localFilePath = parseResult.GetResult(_localFileOption)?.GetValueOrDefault<string>() ?? string.Empty;

        await _ftpService.Upload(host, userName, pwd, remotePath, localFilePath)
            .ConfigureAwait(false);
    } 
}
