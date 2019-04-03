using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift.Protocols;
using Thrift.Server;
using Thrift.Transports.Client;
using Thrift.Transports.Server;

namespace ThriftTemplate.Contract.Core
{
    public partial class UserService : UserService.IAsync
    {
        public static async Task RunAsync(IAsync processor, int port, ILoggerFactory loggerFactory)
        {
            using (var source = new CancellationTokenSource())
            {
                var server = new AsyncBaseServer(
                    new AsyncProcessor(processor),
                    new TServerSocketTransport(port),
                    new TBinaryProtocol.Factory(),
                    new TBinaryProtocol.Factory(),
                    loggerFactory
                );

                await server.ServeAsync(source.Token);
            }
        }

        private readonly IPAddress _host;
        private readonly int _port;

        public UserService(IPAddress host, int port)
        {
            _host = host;
            _port = port;
        }

        public async Task<bool> CreateAsync(Person person)
        {
            using (var source = new CancellationTokenSource())
                return await CreateAsync(person, source.Token);
        }

        public async Task<bool> CreateAsync(Person person, CancellationToken cancellationToken) =>
            await InvokeAsync(async client => await client.CreateAsync(person, cancellationToken),
                cancellationToken);


        public async Task<bool> DeleteAsync(int id)
        {
            using (var source = new CancellationTokenSource())
                return await DeleteAsync(id, source.Token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken) =>
            await InvokeAsync(async client => await client.DeleteAsync(id, cancellationToken), cancellationToken);


        public async Task UpdateAsync(Person person)
        {
            using (var source = new CancellationTokenSource())
                await UpdateAsync(person, source.Token);
        }

        public async Task UpdateAsync(Person person, CancellationToken cancellationToken) =>
            await InvokeAsync(async client => await client.UpdateAsync(person, cancellationToken), cancellationToken);


        public async Task<Person> QueryAsync(int id)
        {
            using (var source = new CancellationTokenSource())
                return await QueryAsync(id, source.Token);
        }

        public async Task<Person> QueryAsync(int id, CancellationToken cancellationToken) =>
            await InvokeAsync(async client => await client.QueryAsync(id, cancellationToken), cancellationToken);


        private async Task InvokeAsync(Action<Client> action, CancellationToken cancellationToken)
        {
            using (var transport = new TSocketClientTransport(_host, _port))
            {
                using (var protocol = new TBinaryProtocol(transport))
                {
                    using (var client = new Client(protocol))
                    {
                        await client.OpenTransportAsync(cancellationToken);
                        action(client);
                    }
                }
            }
        }

        private async Task<T> InvokeAsync<T>(Func<Client, Task<T>> action, CancellationToken cancellationToken)
        {
            using (var transport = new TSocketClientTransport(_host, _port))
            {
                using (var protocol = new TBinaryProtocol(transport))
                {
                    using (var client = new Client(protocol))
                    {
                        await client.OpenTransportAsync(cancellationToken);
                        return await action(client);
                    }
                }
            }
        }
    }
}