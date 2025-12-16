namespace FTP.Services;

public interface IFTPService
{
    Task Upload(string host, string userName, string pwd, string remotePath, string localFilePath);
}
