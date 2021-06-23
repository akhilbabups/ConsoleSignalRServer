using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleSignalRServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            IHubContext<MessageHub> hubContext = (IHubContext<MessageHub>)host.Services.GetService(typeof(IHubContext<MessageHub>));
            var watcher = new DirectoryWatcher(hubContext);
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
