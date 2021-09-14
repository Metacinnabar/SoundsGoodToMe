using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Spectre.Console;
using CliFx.Attributes;
using CliFx.Infrastructure;
using SoundsGoodToMe.Utils;

namespace SoundsGoodToMe.Commands
{
    [Command("converturl")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ConvertUrlCommand : ConvertCommandBase
    {
        [CommandOption("url", 'u', IsRequired = true, Description = "Url used to fetch gif")]
        public string Url { get; init; }

        public override async ValueTask ExecuteAsync(IConsole console)
        {
            var filename = $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}.gif";
            var tempFilePath = Path.Join(OutputDirectory, "temp_" + filename);
            var finalFilePath = Path.Join(OutputDirectory, "sgtm_" + filename);

            var ansiConsole = AnsiConsole.Console;
            /*AnsiConsole.Create(new AnsiConsoleSettings
            {
                Ansi = AnsiSupport.Detect,
                ColorSystem = ColorSystemSupport.Detect,
                Out = new AnsiConsoleOutput(console.Output)
            });*/

            if (!Directory.Exists(OutputDirectory))
                Directory.CreateDirectory(OutputDirectory);

            try
            {
                await ConsoleUtils.AsyncProgressBar(ansiConsole, "Downloading gif", async task =>
                    await NetUtils.DownloadGifWithProgressBar(ansiConsole, new HttpClient(), task, tempFilePath, Url));

                await ConsoleUtils.AsyncStatus(ansiConsole, "Converting gif", () =>
                    ImageUtils.AsyncConvertImage(tempFilePath, finalFilePath, Font, TextColor));
                ansiConsole.MarkupLine($"Image conversion of [u]{finalFilePath}[/] [green]completed![/]");
            }
            finally
            {
                File.Delete(tempFilePath);
                ansiConsole.MarkupLine($"Temp gif deletion of [u]{tempFilePath}[/] [green]completed![/]");
            }
        }
    }
}