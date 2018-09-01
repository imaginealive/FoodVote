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
        IMongoCollection<PollInfo> SubmitCollection { get; set; }

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
            SubmitCollection = database.GetCollection<PollInfo>("SubmitPoll");
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

        public void SubmitPoll(PollInfo document)
        {
            SubmitCollection.InsertOne(document);
        }

        public PollInfo GetSubmit(Expression<Func<PollInfo, bool>> expression)
        {
            return SubmitCollection.Find(expression).FirstOrDefault();
        }
    }
}
