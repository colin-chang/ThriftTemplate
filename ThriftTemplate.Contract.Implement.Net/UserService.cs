using ThriftTemplate.Contract.Net;

namespace ThriftTemplate.Contract.Implement.Net
{
    public class UserSvs : UserService.Iface
    {
        public bool Create(Person person)
        {
            // your code
            return true;
        }

        public bool Delete(int id)
        {
            // your code
            return true;
        }

        public void Update(Person person)
        {
            // your code
        }

        public Person Query(int id)
        {
            // your code
            return new Person {Id = 0, Name = "Colin", Age = 18};
        }
    }
}