using System.Collections.Generic;
using System.Linq;

namespace Data.Predicates
{
    public class PredicateGroup : Predicate
    {
        public PredicateGroup(Operator op, params Predicate[] children)
        {
            Op = op;
            Children = children.ToList();
        }

        public Operator Op { get; }
        public IList<Predicate> Children { get; }

        public override T Accept<T>(IPredicateVisitor<T> visitor)
        {
            return visitor.VisitPredicate(this);
        }
    }
}