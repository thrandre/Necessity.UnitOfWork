namespace Data.Predicates
{
    public interface IPredicateVisitor<T>
    {
        T VisitPredicate(Predicate predicate);
    }
}