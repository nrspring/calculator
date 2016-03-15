namespace Calculator.Core.Interfaces
{
    public interface IExpressionProcessor
    {
        Models.ExpressionResult Process(string value);
    }
}