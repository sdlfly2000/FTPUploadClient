using Common.Core.DependencyInjection;
using FluentFTP;

namespace FTP.Services.Progress;

[ServiceLocate(typeof(IProgress<FtpProgress>), ServiceType.Scoped)]
public class UploadProgress : IProgress<FtpProgress>
{
    public void Report(FtpProgress value)
    {
        ClearCurrentline();
        Console.Write($"Uploaded: {value.Progress}, Speed: {value.TransferSpeed}, ETA: {value.ETA}");
    }

    private void ClearCurrentline()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
