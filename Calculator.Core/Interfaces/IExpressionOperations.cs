namespace Calculator.Core.Interfaces
{
    public interface IExpressionOperations
    {
        Models.Expression ProcessExpression(Models.Expression leftSide, Models.Expression operation,Models.Expression rightSide);
    }
}