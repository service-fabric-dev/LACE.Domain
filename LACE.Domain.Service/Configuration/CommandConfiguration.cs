using LACE.Domain.Configuration.Abstractions;
using LACE.Domain.Service.Branches;
using LACE.Domain.Service.Commands;
using Spectre.Cli;

namespace LACE.Domain.Service.Configuration
{
    public class CommandConfiguration : IConfiguration
    {
        public void ConfigureCommand(IConfigurator configurator)
        {
            // TODO: tie discovery to JSON
            configurator.AddBranch<DomainBranchSettings>("domain", domain =>
            {
                domain.AddCommand<StartCommand>("start");
            });
        }
    }
}
