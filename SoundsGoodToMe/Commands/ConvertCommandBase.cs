using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using SoundsGoodToMe.DataStructures;

namespace SoundsGoodToMe.Commands
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public abstract class ConvertCommandBase : ICommand
    {
        // default /home/charlie/sgtm-output/ or C:\Users\Charlie\sgtm-output\
        [CommandOption("outputdir", 'o', Description = "Output directory for the converted gifs.")]
        public string OutputDirectory { get; init; } = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "sgtm-output");
        
        [CommandOption("font", 'f', Description = "Font used for text overlay.")]
        public string Font { get; init; } = "Arial";

        [CommandOption("color", 'c', Description = "Color used for text overlay.")]
        public string TextColor { get; init; } = "#FFFFFF";

        [CommandOption("abbreviated-text", 'a', Description = "The abbreviated text to display.")]
        public string AbbreviatedText { get; init; } = Program.DefaultAbbreviation;

        [CommandOption("expanded-text", 'e', Description = "The unabbreviated text to display.")]
        public string ExpandedText { get; init; } = Program.DefaultExpanded;


        [CommandOption("abbreviated-size", 'A', Description = "The abbreviated font size.")]
        public int AbbreviatedSize { get; init; } = Program.DefaultAbbreviatedSize;

        [CommandOption("expanded-size", 'E', Description = "The unabbreviated font size.")]
        public int ExpandedSize { get; init; } = Program.DefaultExpandedSize;

        public Acronym SgtmAcronym => new(AbbreviatedText, ExpandedText, AbbreviatedSize, ExpandedSize);

        public abstract ValueTask ExecuteAsync(IConsole console);
    }
}