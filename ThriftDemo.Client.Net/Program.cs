using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftDemo.Contract.Net;

namespace ThriftDemo.Client.Net
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
