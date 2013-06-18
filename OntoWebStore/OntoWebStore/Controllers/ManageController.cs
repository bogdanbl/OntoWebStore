using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OntoWebStore.Services;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace OntoWebStore.Controllers
{
    public class ManageController : Controller
    {
        private IRdfTranslator _rdfTranslator;

        public ManageController(IRdfTranslator rdfTranslator)
        {
            _rdfTranslator = rdfTranslator;
        }

        [HttpPost]
        public ActionResult Load(Uri ontologyUri)
        {
            if(ontologyUri == null || string.IsNullOrEmpty(ontologyUri.AbsolutePath))
                ontologyUri = new Uri("http://krono.act.uji.es/Links/ontologies/wine.owl/at_download/file");
            var ontology = _rdfTranslator.LoadOntologyFromUri(ontologyUri);
            _rdfTranslator.StoreOntology(ontology);
            return View();
        }

        public List<Triple> SearchOntology(OntologyGraph ontology, string instanceToSearch)
        {
            List<Triple> result1;
            var finalResult = new List<Triple>();
            if(!(result1 = ontology.Triples.Where(tripple => tripple.Subject.ToString().Contains(instanceToSearch)).ToList()).Any())
                return new List<Triple>();
            
            finalResult.AddRange(result1);
            foreach (var triple in result1)
            {
                finalResult.AddRange(SearchOntology(ontology, triple.Object.ToString()));
            }
            
            return finalResult;
        }
    }
}
