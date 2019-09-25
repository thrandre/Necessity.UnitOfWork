namespace Necessity.UnitOfWork.Schema
{
    public class Mapper
    {
        private readonly string _propertyName;
        private string _columnName;
        private NonStandardDbType? _dbType;
        private string _sqlExpression;

        public Mapper(string propertyName)
        {
            _propertyName = propertyName;
        }

        public Mapper ToColumnName(string columnName)
        {
            _columnName = columnName;
            return this;
        }

        public Mapper UsingNonStandardDbType(NonStandardDbType dbType)
        {
            _dbType = dbType;
            return this;
        }

        public Mapper UsingSqlExpression(string sqlExpression)
        {
            _sqlExpression = sqlExpression;
            return this;
        }

        public Mapping CreateMapping()
        {
            return new Mapping(_propertyName, _columnName, _dbType)
            {
                CustomSqlExpression = _sqlExpression
            };
        }

        public static Mapper Map(string propertyName)
        {
            return new Mapper(propertyName);
        }
    }
}