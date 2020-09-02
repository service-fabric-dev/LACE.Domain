using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LACE.Domain.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        private class TestClass
        {
            public List<IMachineAdapter> MachinesInterfaced { get; set; }
            public IList<Machine> CollectionInterfaced { get; set; }
            public IList<IMachineAdapter> BothInterfaced { get; set; }
        }

        private class Machine : IMachineAdapter
        {
            public Task WorkAsync(IFacts facts, CancellationToken cancellation)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
