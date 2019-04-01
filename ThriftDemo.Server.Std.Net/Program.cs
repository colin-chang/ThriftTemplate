using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;
using ThriftDemo.Contract.Implement.Std;
using ThriftDemo.Contract.Std;

namespace ThriftDemo.Server.Std.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var processor = new EmotionAnalyzer.Processor(new StdEmotionAnalyzer());
                var serverTransport = new TServerSocket(9090);
                var server = new TThreadPoolServer(processor, serverTransport);

                Console.WriteLine("Starting the server...");
                server.Serve();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.StackTrace);
            }
            Console.WriteLine("done.");
        }
    }
}
