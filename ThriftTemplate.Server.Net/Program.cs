using System;
using Thrift.Server;
using Thrift.Transport;
using ThriftTemplate.Contract.Implement.Net;
using ThriftTemplate.Contract.Net;

namespace ThriftTemplate.Server.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("UserService starting on port 10010...");
                UserService.Run(new UserSvs(), 10010);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.StackTrace);
            }
        }
    }
}