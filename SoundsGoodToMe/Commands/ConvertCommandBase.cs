using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace SoundsGoodToMe.Commands
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public abstract class ConvertCommandBase : ICommand
    {
        [CommandOption("font", 'f', Description = "Font used for text overlay.")]
        public string Font { get; init; } = "Ubuntu";
        
        // default /home/charlie/sgtm/output or C:\Users\Charlie\sgtm\output
        [CommandOption("outputdir", 'o', Description = "Output directory for the converted images.")]
        public string OutputDirectory { get; init; } = Environment.GetEnvironmentVariable("userprofile");
        
        [CommandOption("color", 'c', Description = "Color used for text overlay.")]
        public string TextColor { get; init; } = "#FFFFFF";
        public abstract ValueTask ExecuteAsync(IConsole console);
    }
}