using System;
using ThriftTemplate.Contract.Implement.Std;
using ThriftTemplate.Contract.Std;

namespace ThriftTemplate.Server.Std.Net
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
