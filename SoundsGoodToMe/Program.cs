using System.Threading.Tasks;
using CliFx;
using SoundsGoodToMe.DataStructures;

namespace SoundsGoodToMe
{
    public static class Program
    {
        // Struct abuse :sunglasses:
        public static Acronym SgtmAcronym = new("SGTM", "Sounds Good To Me", 70, 30);

        public static async Task<int> Main()
        {
            return await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();
        }
    }
}