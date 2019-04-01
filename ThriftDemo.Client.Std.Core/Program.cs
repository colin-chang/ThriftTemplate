using System;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftDemo.Contract.Std;

namespace ThriftDemo.Client.Std.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var transport = new TSocket("localhost", 9090))
            {
                using (var protocol = new TBinaryProtocol(transport))
                {
                    using (var client = new EmotionAnalyzer.Client(protocol))
                    {
                        transport.Open();
                        client.Stop(123);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
