using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Server;
using Thrift.Transports.Server;
using ThriftTemplate.Contract.Core;
using ThriftTemplate.Contract.Implement.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ThriftTemplate.Server.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new CancellationTokenSource())
            {
                RunAsync(source.Token).Wait(source.Token);
                
                Console.ReadKey();
                source.Cancel();
            }
        }

        private static async Task RunAsync(CancellationToken cancellationToken)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddConsole();
                logging.AddDebug();
            });

            await UserService.RunAsync(new UserSvs(), 10010, serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>());
        }
    }
}
