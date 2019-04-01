using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports.Client;
using ThriftDemo.Contract.Core;

namespace ThriftDemo.Client.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new CancellationTokenSource())
            {
                RunAsync(source.Token).Wait(source.Token);
            }

            Console.ReadKey();
        }

        private static async Task RunAsync(CancellationToken cancellationToken)
        {
            using (var transport = new TSocketClientTransport(IPAddress.Parse("127.0.0.1"), 9090))
            {
                using (var protocol = new TBinaryProtocol(transport))
                {
                    using (var client = new EmotionAnalyzer.Client(protocol))
                    {
                        await client.OpenTransportAsync(cancellationToken);
                        await client.StopAsync(123, cancellationToken);
                    }
                }
            }
        }
    }
}
