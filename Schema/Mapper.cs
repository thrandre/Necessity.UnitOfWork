using System;

namespace Necessity.UnitOfWork.Schema
{
    public class Mapper
    {
        private readonly string _propertyName;
        private string _columnName;
        private NonStandardDbType? _dbType;
        private Func<object, string> _onSelectFactory;
        private Func<object, string> _onInsertFactory;

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

        public Mapper OnSelect(Func<object, string> sqlSelectExpressionFactory)
        {
            _onSelectFactory = sqlSelectExpressionFactory;
            return this;
        }

        public Mapper OnInsert(Func<object, string> sqlInsertExpressionFactory)
        {
            _onInsertFactory = sqlInsertExpressionFactory;
            return this;
        }

        public Mapping CreateMapping()
        {
            return new Mapping(_propertyName, _columnName, _dbType)
            {
                OnSelect = _onSelectFactory,
                OnInsert = _onInsertFactory
            };
        }

        public static Mapper Map(string propertyName)
        {
            return new Mapper(propertyName);
        }
    }
}