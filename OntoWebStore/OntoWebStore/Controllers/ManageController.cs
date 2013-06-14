using System;
using System.Web.Mvc;
using OntoWebStore.Services;

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
            var ontology = _rdfTranslator.LoadOntologyFromUri(ontologyUri);
            return View();
        }

    }
}
