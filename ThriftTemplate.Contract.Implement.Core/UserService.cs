using System;
using System.Threading;
using System.Threading.Tasks;
using ThriftTemplate.Contract.Core;

namespace ThriftTemplate.Contract.Implement.Core
{
    public class UserSvs : UserService.IAsync
    {
        public Task<bool> CreateAsync(Person person, CancellationToken cancellationToken)
        {
            // your code
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            // your code
            return Task.FromResult(true);
        }

        public Task UpdateAsync(Person person, CancellationToken cancellationToken)
        {
            // your code
            return Task.CompletedTask;
        }

        public Task<Person> QueryAsync(int id, CancellationToken cancellationToken)
        {
            // your code
            return Task.FromResult(new Person {Id = 0, Name = "Colin", Age = 18});
        }
    }
}