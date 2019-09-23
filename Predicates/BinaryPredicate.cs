namespace Data.Predicates
{
    public class BinaryPredicate : Predicate
    {
        public BinaryPredicate(Operator op, object op1, object op2, bool negate = false)
        {
            Op = op;
            Op1 = op1;
            Op2 = op2;
            Negate = negate;
        }

        public Operator Op { get; }
        public object Op1 { get; }
        public object Op2 { get; }
        public bool Negate { get; }

        public override T Accept<T>(IPredicateVisitor<T> visitor)
        {
            return visitor.VisitPredicate(this);
        }
    }
}