using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Threading.Tasks;
using api.Model;
using MongoDB.Driver;

namespace api.Dac.Contract
{
    public class AccountDac : IAccountDac
    {
        IMongoCollection<Account> Collection { get; set; }

        public AccountDac(DatabaseConfigurations config)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(config.MongoDBConnection));
            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };
            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase(config.DatabaseName);
            Collection = database.GetCollection<Account>("Account");
        }

        public void Create(Account document)
        {
            Collection.InsertOne(document);
        }

        public Account Get(Expression<Func<Account, bool>> expression)
        {
            return Collection.Find(expression).FirstOrDefault();
        }
    }
}
