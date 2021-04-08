using System.Reflection.PortableExecutable;
using LACE.Core.Extensions;
using LACE.Data.Cosmos.Abstractions;
using LACE.Domain.Web.Model;
using System.Threading;
using System.Threading.Tasks;

namespace LACE.Domain.Web.Data
{
    public class MachineConfigurations
    {
        private readonly IDocumentRepository<MachineConfiguration> _configRepository;

        public MachineConfigurations(IDocumentRepository<MachineConfiguration> configRepository)
        {
            _configRepository = configRepository.Guard(nameof(configRepository));
        }

        public async Task<MachineConfiguration> GetAsync(string id)
        {
            using var source = new CancellationTokenSource();
            return await _configRepository.GetAsync(id, source.Token);
        }

        public async Task<MachineConfiguration> Create(string id, MachineConfiguration configuration)
        {
            return await _configRepository.UpsertAsync(id, null, configuration, CancellationToken.None);
        }
    }
}
