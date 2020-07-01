using LACE.Domain.Model.Meters.Moisture;
using LACE.Domain.State.Abstractions;
using LACE.Domain.Validation.Abstractions;

namespace LACE.Domain.Validation
{
    class MoistureFactValidator : IFactValidator

    {
        public bool Validate(IFactKey factKey, IFact fact)
        {
            return factKey != null && fact is MoistureFact;
        }
    }
}
