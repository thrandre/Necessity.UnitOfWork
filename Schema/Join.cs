namespace Necessity.UnitOfWork.Schema
{
    public class Join
    {
        public Join(string joinExpression)
        {
            JoinExpression = joinExpression;
        }

        public string JoinExpression { get; }
    }
}