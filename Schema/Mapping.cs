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
        public string CustomSqlExpression { get; set; }

        public string QualifiedName(ISchema schema) => $"{schema.TableAlias}.{ColumnName}";
    }
}