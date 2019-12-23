using Bogus;
using Business.Contracts;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Persistence.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        protected List<Example> _dataSet;

        public ExampleRepository()
        {
            //_dataSet = new List<Example>();

            _dataSet = new Faker<Example>()
                .RuleFor(instance => instance.Id, faker => faker.Random.Int(1))
                .RuleFor(instance => instance.Data1, faker => faker.Person.FirstName)
                .RuleFor(instance => instance.Data2, faker => faker.Person.LastName)
                .Generate(10);
        }
        public Task<Example> AddAsync(Example instance)
        {

            if (instance != null)
            {
                var id = _dataSet
                        .Select(example => example.Id)
                        .Max();

                instance.Id = ++id;
                _dataSet.Add(instance);
            }
            return Task.FromResult(instance);
        }

        public Task<Example> GetAsync(int id)
        {
            return Task.FromResult(_dataSet.First(example => example.Id == id));
        }

        public Task<IEnumerable<Example>> GetCollecionAsync()
        {
            return Task.FromResult<IEnumerable<Example>>(_dataSet);
        }
    }
}
