namespace csharp ThriftDemo.Contract.Net
namespace netcore ThriftDemo.Contract.Core

service UserService 
{
  bool Create(1: Person person)
  bool Delete(1: i32 id)
  void Update(1: Person person)
  Person Query(1: i32 id)
}


struct Person
{
  1: i32 id
  2: string name
  3: i32 age
}