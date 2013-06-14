using System;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace OntoWebStore.Services
{
    public class RdfTranslator:IRdfTranslator
    {
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
    }
}