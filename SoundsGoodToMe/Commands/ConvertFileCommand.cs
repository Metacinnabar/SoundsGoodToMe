using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using CliFx.Attributes;
using CliFx.Infrastructure;
using SoundsGoodToMe.Utils;
using Spectre.Console;

namespace SoundsGoodToMe.Commands
{
    [Command("convertfile")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ConvertFileCommand : ConvertCommandBase
    {
        [CommandOption("path", 'p', IsRequired = true, Description = "Path used for pre-existing file to overlay")]
        public string Path { get; init; }
        
        public override async ValueTask ExecuteAsync(IConsole console)
        {
            var filename = $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}.gif";
            var filepath = System.IO.Path.Join(OutputDirectory, $"sgtm_{filename}");

            var ansiConsole = AnsiConsole.Console;
            /*AnsiConsole.Create(new AnsiConsoleSettings
            {
                Ansi = AnsiSupport.Detect,
                ColorSystem = ColorSystemSupport.Detect,
                Out = new AnsiConsoleOutput(console.Output)
            });*/

            if (!Directory.Exists(OutputDirectory))
                Directory.CreateDirectory(OutputDirectory);
            
            await ConsoleUtils.AsyncStatus(ansiConsole, "Converting gif", () =>
                ImageUtils.AsyncConvertImage(Path, filepath, Font, TextColor));
            ansiConsole.MarkupLine($"Image conversion of [u]{filepath}[/] [green]completed![/]");
        }
    }
}