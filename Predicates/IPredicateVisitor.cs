namespace Necessity.UnitOfWork.Predicates
{
    public interface IPredicateVisitor<T>
    {
        T VisitPredicate(Predicate predicate);
    }
}