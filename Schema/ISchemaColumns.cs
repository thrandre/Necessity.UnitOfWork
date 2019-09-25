namespace Necessity.UnitOfWork.Schema
{
    public interface ISchemaColumns
    {
        string KeyProperty { get; }
        PropertyColumnMap Mapping { get; }
    }
}