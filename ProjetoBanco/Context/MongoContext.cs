using MongoDB.Driver;
using ProjetoBanco.Models.Mongo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjetoBanco.Context
{
    public class MongoContext
    {
        MongoClient _client;
        MongoServer _server;
        public MongoDatabase _database;
        public MongoContext()        //constructor   
        {
            // Reading credentials from Web.config file   
            var MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"]; //ProjetoBanco
            var MongoPort = ConfigurationManager.AppSettings["MongoPort"];  //27017  
            var MongoHost = ConfigurationManager.AppSettings["MongoHost"];  //localhost  

            // Creating credentials  

            // Creating MongoClientSettings  
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
            };
            _client = new MongoClient(settings);
            _server = _client.GetServer();
            _database = _server.GetDatabase(MongoDatabaseName);

            //MongoDB.Bson.Serialization.BsonClassMap.RegisterClassMap<Produto_Mongo>(p =>
            //{
            //    p.MapIdField(f => f.Nome_Materia_Principal.AsObjectId);
            //});
        }
    }
}