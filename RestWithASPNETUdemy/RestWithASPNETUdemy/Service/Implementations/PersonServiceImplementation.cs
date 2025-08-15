using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Service.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            Console.WriteLine($"Person {id} deleted"); ;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 1; i <= 5; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Romeo_{id}",
                LastName = $"Oliveira_{id}",
                Address = "Osasco-SP",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Romeo_{id}",
                LastName = $"Oliveira_{id}",
                Address = "Osasco-SP",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
