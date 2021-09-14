using System.Threading.Tasks;
using CliFx;
using SoundsGoodToMe.DataStructures;

namespace SoundsGoodToMe
{
    public static class Program
    {
        public const string DefaultAbbreviation = "SGTM";
        public const string DefaultExpanded = "Soungs Good To Me";

        // Default value set in the static constructor.
        // This will actually be modified by either conversion command.
        public static Acronym CurrentAcronym = default;

        public static async Task<int> Main()
        {
            return await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();
        }
    }
}