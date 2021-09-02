using System;
using System.Threading.Tasks;
using Spectre.Console;

namespace SoundsGoodToMe.Utils
{
    public static class ConsoleUtils
    {
        public static async Task AsyncProgressBar(IAnsiConsole console, string taskName, Func<ProgressTask, Task>  task)
        {
            await console.Progress()
                .Columns(new TaskDescriptionColumn(), new ProgressBarColumn(), new PercentageColumn(), new RemainingTimeColumn(), new SpinnerColumn())
                .StartAsync(async ctx =>
                {
                    var progressTask = ctx.AddTask(taskName, new ProgressTaskSettings
                    {
                        AutoStart = false
                    });

                    await task(progressTask);
                });
        }

        public static async Task AsyncStatus(IAnsiConsole console, string status, Func<Task>  task)
        {
            await console.Status()
                .StartAsync(status, async _ => 
                {
                    await task();
                });
        }
    }
}