using System;
using System.Collections.Generic;

namespace Necessity.UnitOfWork.Schema
{
    public class PropertyColumnMap : Dictionary<string, Mapping>
    {
        public PropertyColumnMap() : base(StringComparer.OrdinalIgnoreCase) { }
        public PropertyColumnMap(Dictionary<string, Mapping> dict) : base(dict, StringComparer.OrdinalIgnoreCase) { }
    }
}