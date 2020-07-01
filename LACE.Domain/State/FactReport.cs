using System.Collections.Generic;
using LACE.Domain.State.Abstractions;

namespace LACE.Domain.State
{
    class FactReport : IFactReport
    {
        private readonly IList<IFact> _facts;

        public FactReport()
        {
            _facts = new List<IFact>();
        }

        public bool IsSuccessful { get; set; }

        public IFactReport AddFact(IFact fact)
        {
            if (fact == null)
            {
                return this;
            }

            if (!_facts.Contains(fact))
            {
                _facts.Add(fact);
            }

            return this;
        }
    }
}
