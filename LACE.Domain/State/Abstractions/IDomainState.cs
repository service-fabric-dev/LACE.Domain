using System;
using System.Collections.Generic;
using System.Text;
using LACE.Domain.Model.Abstractions;

namespace LACE.Domain.State.Abstractions
{
    public interface IDomainState
    {
        IFacts GetFacts();
        IFact AddFact(IFact fact);
        IFactReport Update(IFactReport report);
    }
}
