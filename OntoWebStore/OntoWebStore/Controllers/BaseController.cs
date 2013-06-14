using System.Web.Mvc;
using MongoDB.Driver;

namespace OntoWebStore.Controllers
{
    public class BaseController: Controller
    {
        private const string ConnectionString = "mongodb://<dbuser>:<dbpassword>@ds029828.mongolab.com:29828/appharbor_49f11610-043a-4d2d-8240-c58097c91b64";
        protected MongoDatabase DataContext;

        public BaseController()
        {
            var client = new MongoClient(ConnectionString);
            var server = client.GetServer();
            DataContext = server.GetDatabase("Ontologies");
        }
    }
}