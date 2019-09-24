using System.Collections.Generic;

namespace Necessity.UnitOfWork.Schema
{
    public interface ISchemaColumns
    {
        string KeyName { get; }
        Dictionary<string, (string columnName, string dbType)> Mapping { get; }
    }
}