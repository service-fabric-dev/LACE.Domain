using LACE.Core.Abstractions.Model;

namespace LACE.Domain.Validation.Abstractions
{
    interface IFactValidator
    {
        bool Validate(IFactKey factKey, IFact fact);
    }
}
