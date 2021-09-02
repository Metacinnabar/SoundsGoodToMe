using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Spectre.Console;

namespace SoundsGoodToMe.Utils
{
    public static class NetUtils
    {
        // https://github.com/spectreconsole/spectre.console/discussions/162#discussioncomment-202912
        public static async Task DownloadGifWithProgressBar(IAnsiConsole console, HttpClient client, ProgressTask task, string outputPath, string url)
        {
            // https://stackoverflow.com/a/56091135
            const int bufferSize = 8192;
            try
            {
                using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                // Set the max value of the progress task to the number of bytes
                task.MaxValue(response.Content.Headers.ContentLength ?? 0);
                // Start the progress task
                task.StartTask();

                console.MarkupLine($"Starting download of [u]{outputPath}[/] ({task.MaxValue} bytes)");

                await using var contentStream = await response.Content.ReadAsStreamAsync();
                await using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, true);

                
                var buffer = new byte[bufferSize];
                while (true)
                {
                    var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                    if (read == 0)
                    {
                        console.MarkupLine($"Download of [u]{outputPath}[/] [green]completed![/]");
                        break;
                    }

                    // Increment the number of read bytes for the progress task
                    task.Increment(read);

                    // Write the read bytes to the output stream
                    await fileStream.WriteAsync(buffer, 0, read);
                }
            }
            catch (Exception ex)
            {
                console.MarkupLine($"[red]Error downloading gif:[/] {ex}");
            }
        }
    }
}