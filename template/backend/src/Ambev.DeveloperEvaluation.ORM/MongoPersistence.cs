using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.ORM.Persistence.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM
{
    public static class MongoPersistence
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSection = configuration.GetSection("Mongo");
            var connectionString = mongoSection.GetValue<string>("ConnectionString");
            var databaseName = mongoSection.GetValue<string>("Database");

            var mongoSettings = MongoClientSettings.FromConnectionString(connectionString);
            mongoSettings.GuidRepresentation = GuidRepresentation.Standard;


            var mongoClient = new MongoClient(mongoSettings);
            services.AddSingleton<IMongoClient>(mongoClient);

            services.AddScoped(sp =>
                sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName));

            services.AddScoped(typeof(IEventRepository<>), typeof(MongoEventRepository<>));
        }
    }
}
