using LACE.Domain.State.Abstractions;

namespace LACE.Domain.Validation.Abstractions
{
    interface IFactValidator
    {
        bool Validate(IFactKey factKey, IFact fact);
    }
}
