using api.Dac.Contract;
using api.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace api.Dac
{
    public class PollDac : IPollDac
    {
        IMongoCollection<Poll> Collection { get; set; }

        public PollDac(DatabaseConfigurations config)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(config.MongoDBConnection));
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase(config.DatabaseName);
            Collection = database.GetCollection<Poll>("Poll");
        }

        public void Create(Poll document)
        {
            Collection.InsertOne(document);
        }

        public Poll Get(Expression<Func<Poll, bool>> expression)
        {
            return Collection.Find(expression).FirstOrDefault();
        }

        public void Update(Poll document)
        {
            Collection.ReplaceOne(it => it.Id == document.Id, document);
        }
    }
}
