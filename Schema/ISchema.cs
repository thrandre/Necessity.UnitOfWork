using System.Collections.Generic;

namespace Necessity.UnitOfWork.Schema
{
    public interface ISchema
    {
        string TableName { get; }
        string TableAlias { get; }
        string TableFullName { get; }
        ISchemaColumns Columns { get; }
        List<Join> Joins { get; }
        (string propertyName, OrderDirection direction) DefaultOrderBy { get; }
    }
}