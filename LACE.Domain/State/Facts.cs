using System.Collections.Generic;
using LACE.Domain.Extensions;
using LACE.Domain.State.Abstractions;
using LACE.Domain.Validation.Abstractions;

namespace LACE.Domain.State
{
    class Facts : IFacts
    {
        private readonly IDictionary<IFactKey, IFact> _facts;
        private readonly IFactValidator _factValidator;

        public Facts(IFactValidator factValidator)
        {
            _factValidator = factValidator.Guard(nameof(factValidator));
            _facts = new Dictionary<IFactKey, IFact>();
        }

        public bool ContainsKey(IFactKey factKey)
        {
            if (factKey == null)
            {
                return false;
            }

            return _facts.ContainsKey(factKey);
        }

        public IFact Get(IFactKey factKey)
        {
            if (factKey == null)
            {
                return default;
            }

            if (!_facts.ContainsKey(factKey))
            {
                return default;
            }

            return _facts[factKey];
        }

        public IFact Add(IFactKey factKey, IFact fact)
        {
            if (factKey == null)
            {
                return fact;
            }

            if (ContainsKey(factKey))
            {
                // Add should not update existing entries
                return fact;
            }

            if (!_factValidator.Validate(factKey, fact))
            {
                return fact;
            }

            return _facts[factKey] = fact;
        }

        public IFact Update(IFactKey factKey, IFact fact)
        {
            if (factKey == null)
            {
                return fact;
            }

            if (!ContainsKey(factKey))
            {
                return fact;
            }

            return _facts[factKey] = fact;
        }
    }
}
