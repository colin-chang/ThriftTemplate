using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Server;
using Thrift.Transports.Server;
using ThriftDemo.Contract.Core;
using ThriftDemo.Contract.Implement.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ThriftDemo.Server.Core
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
            var ServiceCollection = new ServiceCollection();
            ServiceCollection.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddConsole();
                logging.AddDebug();
            });

            var server = new AsyncBaseServer(
                new EmotionAnalyzer.AsyncProcessor(new CoreEmotionAnalyzer()),
                new TServerSocketTransport(9090),
                new TBinaryProtocol.Factory(),
                new TBinaryProtocol.Factory(),
                ServiceCollection.BuildServiceProvider().GetService<ILoggerFactory>()
            );

            await server.ServeAsync(cancellationToken);
        }
    }
}
