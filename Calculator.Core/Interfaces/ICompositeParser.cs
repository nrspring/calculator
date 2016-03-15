namespace Calculator.Core.Interfaces
{
    public interface ICompositeParser
    {
        Models.NumberSegment GetSegmentFromValue(string value);
    }
}