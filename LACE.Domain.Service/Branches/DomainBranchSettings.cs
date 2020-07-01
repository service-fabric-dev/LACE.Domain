using Autofac;
using Spectre.Cli;

namespace LACE.Domain.Service.Branches
{
    /// <summary>
    /// Root node for LACE domain commands
    /// </summary>
    internal class DomainBranchSettings : CommandSettings
    {
        public virtual ContainerBuilder ConfigureContainer(ContainerBuilder builder)
        {
            builder?.RegisterInstance(this)
                .AsSelf()
                .As<CommandSettings>();
            return builder;
        }
    }
}
