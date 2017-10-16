using System;
using Weather.App.Domain.Aggregates;
using Weather.App.Infrastructure.Repositories;
using Xunit;

namespace Weather.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IRepository repo = new MongoRepository();
            var user = User.Factory.CreateNew();
            user.EmailAddress = "1davidrbourke@gmail.com";
            user.AddWeatherLocation("London")
                .AddWeatherLocation("Athens")
                .AddWeatherLocation("New York")
                .Save();

        }

        [Fact]
        public void Test2()
        {
            IRepository repo = new MongoRepository();
            var results = repo.ReadAsync<User>(x => x.EmailAddress == "1davidrbourke@gmail.com");
            results.ContinueWith((user) =>
            {
                var u = user.Result;
            });
        }
    }
}
