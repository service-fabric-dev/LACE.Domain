using LACE.Domain.Configuration;
using LACE.Domain.Service.Configuration;
using Spectre.Cli;

namespace LACE.Domain.Service
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var configurationPointer = new EmbeddedConfigurationPointer
            {
                FileExtension = ".json",
                FileName = "app-configuration"
            };

            var configurationLoader = new EmbeddedConfigurationLoader("Configuration");
            var commandConfiguration = configurationLoader.GetConfiguration<CommandConfiguration>(configurationPointer);

            var app = new CommandApp();
            app.Configure(commandConfiguration.ConfigureCommand);
            app.Run(args);
        }
    }
}
