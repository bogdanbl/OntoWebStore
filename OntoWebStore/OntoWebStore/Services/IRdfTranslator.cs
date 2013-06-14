using System;
using VDS.RDF.Ontology;

namespace OntoWebStore.Services
{
    public interface IRdfTranslator
    {
        OntologyGraph LoadOntology(string filePath);
        OntologyGraph LoadOntologyFromUri(Uri uri);
    }
}
