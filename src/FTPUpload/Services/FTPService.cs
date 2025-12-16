using Common.Core.DependencyInjection;
using FluentFTP;

namespace FTP.Services;

[ServiceLocate(typeof(IFTPService), ServiceType.Scoped)]
public class FTPService : IFTPService
{
    private readonly IProgress<FtpProgress> _progress;

    public FTPService(IProgress<FtpProgress> progress)
    {
        _progress = progress;
    }

    public async Task Upload(string host, string userName, string pwd, string remotePath, string localFilePath)
    {
        using var client = new AsyncFtpClient(host, userName, pwd);
        var status = await client.UploadFile(localFilePath, remotePath, progress: _progress).ConfigureAwait(false);
    }

}
