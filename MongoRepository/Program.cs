using System;
using System.Threading.Tasks;
using MongoRepository.Domain.Entities;
using MongoRepository.Persistence;
using MongoRepository.Persistence.Repositories;

namespace MongoRepository
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task t = MainAsync();
            t.Wait();

            Console.ReadKey();
        }

        private static async Task MainAsync()
        {
            var p = new Person()
            {
                FirstName = "Emrah",
                LastName = "Ozguner"
            };

            var context = new MongoDataContext();
            var personRepository = new PersonRepository(context);

            await personRepository.SaveAsync(p);

            var personFromDatabase = await personRepository.GetByIdAsync(p.Id);

            var personList = await personRepository.FindAllAsync();

            Console.WriteLine($"{personFromDatabase.FirstName}, {personFromDatabase.LastName}, id: {personFromDatabase.Id}");
        }
    }
}