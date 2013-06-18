namespace OntoWebStore.Models
{
    public class JsonTriple
    {
        public TSubject Subject { get; set; }
    }

    public class TSubject
    {
        public string Name { get; set; }
        public TPredicate Predicate { get; set; }
    }

    public class TPredicate
    {
        public string Name { get; set; }
        public TObject TObject { get; set; }
    }

    public class TObject
    {
        public string Name { get; set; }
    }
}