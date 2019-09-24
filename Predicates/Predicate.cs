using System;
using System.Collections.Generic;
using System.Linq;

namespace Necessity.UnitOfWork.Predicates
{
    public abstract class Predicate
    {
        public abstract T Accept<T>(IPredicateVisitor<T> visitor);

        public static Predicate Create(Func<PredicateFactory, Predicate> factory)
        {
            return factory(new PredicateFactory());
        }
    }
}