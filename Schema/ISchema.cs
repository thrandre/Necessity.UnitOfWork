namespace Necessity.UnitOfWork.Schema
{
    public interface ISchema
    {
        string TableName { get; }
        ISchemaColumns Columns { get; }
    }
}