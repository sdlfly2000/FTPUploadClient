using Common.Core.DependencyInjection;
using FluentFTP;

namespace FTP.Services.Progress;

[ServiceLocate(typeof(IProgress<FtpProgress>), ServiceType.Scoped)]
public class UploadProgress : IProgress<FtpProgress>
{
    public void Report(FtpProgress value)
    {
        ClearCurrentline();
        Console.Write($"Uploaded: {value.Progress:F1}%, Speed: {value.TransferSpeedToString()}, ETA: {value.ETA:hh\\:mm\\:ss}");
    }

    private void ClearCurrentline()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
