using System;
using System.Threading;
using Autofac;
using Spectre.Cli;
using System.Threading.Tasks;
using LACE.Domain.Service.Commands.Settings;
using LACE.Domain.Services.Abstractions;

namespace LACE.Domain.Service.Commands
{
    /// <summary>
    /// Command to start the domain service
    /// </summary>
    internal class StartCommand : AsyncCommand<StartCommandConfiguration>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, StartCommandConfiguration settings)
        {
            try
            {
                var builder = settings.ConfigureContainer(new ContainerBuilder());
                var provider = builder.Build();

                using var cts = new CancellationTokenSource();
                var domainService = provider.Resolve<IDomainService>();
                await domainService.RunAsync(cts.Token).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

            return 0;
        }
    }
}
