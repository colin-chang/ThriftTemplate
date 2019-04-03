using System;
using ThriftTemplate.Contract.Std;

namespace ThriftTemplate.Client.Std.Core
{
    class Program
    {
        private static readonly UserService Service = new UserService("127.0.0.1", 10010);
        private static readonly Person Person = new Person {Id = 0, Name = "Colin", Age = 18};

        static void Main(string[] args)
        {
            Service.Create(Person);
            Service.Update(Person);
            Service.Query(0);
            Service.Delete(0);

            Console.ReadKey();
        }
    }
}
