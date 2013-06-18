using System;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using OntoWebStore.Infrastructure;
using OntoWebStore.Models;
using VDS.RDF;
using VDS.RDF.Ontology;
using System.Linq;

namespace OntoWebStore.Services
{
    public class RdfTranslator : IRdfTranslator
    {
        private readonly IMongoDataContextProvider _mongoDataContextProvider;

        public RdfTranslator(IMongoDataContextProvider mongoDataContextProvider)
        {
            _mongoDataContextProvider = mongoDataContextProvider;
        }

        public OntologyGraph LoadOntology(string filePath)
        {
            var graph = new OntologyGraph();
            graph.LoadFromFile(filePath);
            return graph;
        }

        public OntologyGraph LoadOntologyFromUri(Uri uri)
        {
            var graph = new OntologyGraph();
            graph.LoadFromUri(uri);
            return graph;
        }

        public void StoreOntology(OntologyGraph ontology)
        {
            var allClasses = ontology.AllClasses.Select(ontologyClass => ontologyClass.ToString()).ToList();
            foreach (var triple in ontology.Triples)
            {
                var newJsonTriple = new JsonTriple
                {
                    Subject = new TSubject
                        {
                            Name = triple.Subject.ToString(),
                            Predicate = new TPredicate
                                            {
                                                Name = triple.Predicate.ToString(),
                                                TObject = new TObject
                                                                {
                                                                    Name = triple.Object.ToString()
                                                                }
                                            }
                        }
                };
                MongoCollection<JsonTriple> collection = newJsonTriple.Subject.Name.In(allClasses) ? 
                    _mongoDataContextProvider.DataContext.GetCollection<JsonTriple>(ontology.BaseUri.AbsoluteUri + "-TBox") : 
                    _mongoDataContextProvider.DataContext.GetCollection<JsonTriple>(ontology.BaseUri.AbsoluteUri + "-ABox");

                collection.Insert(newJsonTriple);
            }
        }
    }
}