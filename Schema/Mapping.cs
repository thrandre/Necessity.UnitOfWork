using System;

namespace Necessity.UnitOfWork.Schema
{
    public class Mapping
    {
        public Mapping(
            string propertyName,
            string columnName,
            NonStandardDbType? nonStandardDbType = null)
        {
            PropertyName = propertyName;
            ColumnName = columnName;
            NonStandardDbType = nonStandardDbType;
        }

        public string ColumnName { get; }
        public string PropertyName { get; }
        public NonStandardDbType? NonStandardDbType { get; }
        public Func<object, string> OnSelect { get; set; }
        public Func<object, string> OnInsert { get; set; }

        public string QualifiedColumnNameForSelect(ISchema schema) =>
            OnSelect == null && !ColumnName.Contains(".")
                ? $"{schema.TableAlias}.{ColumnName}"
                : ColumnName;

        public string QualifiedColumnNameForInsert(ISchema schema) =>
            OnInsert == null && !ColumnName.Contains(".")
                ? $"{schema.TableAlias}.{ColumnName}"
                : ColumnName;
    }
}