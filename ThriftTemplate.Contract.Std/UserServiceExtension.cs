using System;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace ThriftTemplate.Contract.Std
{
    public partial class UserService : UserService.Iface
    {
        public static void Run(Iface processor, int port)
        {
            var pc =
                new Processor(processor);
            var serverTransport = new TServerSocket(port);
            var server = new TThreadPoolServer(pc, serverTransport);

            server.Serve();
        }

        private readonly string _host;
        private readonly int _port;

        public UserService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public bool Create(Person person) =>
            Invoke(client => client.Create(person));

        public bool Delete(int id) =>
            Invoke(client => client.Delete(id));

        public void Update(Person person) =>
            Invoke(client => client.Update(person));

        public Person Query(int id) =>
            Invoke(client => client.Query(id));


        private void Invoke(Action<Client> action)
        {
            using (var transport = new TSocket(_host, _port))
            {
                using (var protocol = new TBinaryProtocol(transport))
                {
                    using (var clt = new Client(protocol))
                    {
                        transport.Open();
                        action(clt);
                    }
                }
            }
        }

        private T Invoke<T>(Func<Client, T> action)
        {
            using (var transport = new TSocket(_host, _port))
            {
                using (var protocol = new TBinaryProtocol(transport))
                {
                    using (var clt = new Client(protocol))
                    {
                        transport.Open();
                        return action(clt);
                    }
                }
            }
        }
    }
}