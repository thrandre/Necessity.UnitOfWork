namespace Data.Predicates
{
    public abstract class Predicate
    {
        public abstract T Accept<T>(IPredicateVisitor<T> visitor);
    }
}