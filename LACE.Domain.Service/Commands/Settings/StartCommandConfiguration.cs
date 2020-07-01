using Autofac;
using LACE.Domain.Service.Branches;

namespace LACE.Domain.Service.Commands.Settings
{
    internal class StartCommandConfiguration : DomainBranchSettings
    {
        public override ContainerBuilder ConfigureContainer(ContainerBuilder builder)
        {
            //return base.ConfigureContainer(builder)
            //    .RegisterType<DomainSer>();
            base.ConfigureContainer(builder);
            return builder;
        }
    }
}
