namespace Necessity.UnitOfWork.Schema
{
    public class Mapper
    {
        private readonly string _propertyName;
        private string _columnName;
        private NonStandardDbType? _dbType;

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

        public Mapping CreateMapping()
        {
            return new Mapping(_propertyName, _columnName, _dbType);
        }

        public static Mapper Map(string propertyName)
        {
            return new Mapper(propertyName);
        }
    }
}