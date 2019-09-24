namespace Data.Predicates
{
    public class PredicateFactory
    {
        public Predicate Group(Operator op, params Predicate[] children)
        {
            return new PredicateGroup(op, children);
        }

        public Predicate Binary(Operator op, string op1, object op2)
        {
            return new BinaryPredicate(op, op1, op2);
        }
    }
}