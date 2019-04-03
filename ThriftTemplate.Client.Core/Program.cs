using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports.Client;
using ThriftTemplate.Contract.Core;

namespace ThriftTemplate.Client.Core
{
    class Program
    {
        private static readonly UserService Service = new UserService(IPAddress.Parse("127.0.0.1"), 10010);
        private static readonly Person Person = new Person {Id = 0, Name = "Colin", Age = 18};

        static void Main(string[] args)
        {
            RunAsync().Wait();

            Console.ReadKey();
        }

        private static async Task RunAsync()
        {
            await Service.CreateAsync(Person);
            await Service.UpdateAsync(Person);
            await Service.QueryAsync(0);
            await Service.DeleteAsync(0);
        }
    }
}