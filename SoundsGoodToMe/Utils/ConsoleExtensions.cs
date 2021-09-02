using CliFx.Infrastructure;
using Spectre.Console;

// taken from
// https://github.com/Tyrrrz/DiscordChatExporter/blob/e849c9516ce1a3cc065170219d6fea9dd5debc3d/DiscordChatExporter.Cli/Utils/Extensions/ConsoleExtensions.cs#L17
namespace SoundsGoodToMe.Utils
{
    public static class ConsoleExtensions
    {
        public static IAnsiConsole CreateAnsiConsole(this IConsole console)
        {
            return AnsiConsole.Create(new AnsiConsoleSettings
            {
                Ansi = AnsiSupport.Detect,
                ColorSystem = ColorSystemSupport.Detect,
                Out = new AnsiConsoleOutput(console.Output)
            });
        }
    }
}