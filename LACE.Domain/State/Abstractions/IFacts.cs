namespace LACE.Domain.State.Abstractions
{
    public interface IFacts
    {
        bool ContainsKey(IFactKey factKey);
        IFact Get(IFactKey factKey);
    }
}
