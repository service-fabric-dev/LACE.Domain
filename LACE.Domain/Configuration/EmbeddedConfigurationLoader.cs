using LACE.Domain.Configuration.Abstractions;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using LACE.Domain.Extensions;

namespace LACE.Domain.Configuration
{
    public class EmbeddedConfigurationLoader : IConfigurationLoader<EmbeddedConfigurationPointer>
    {
        private const string OutputFolder = "Data";
        private const string JsonOutputFolder = "JSON";

        private readonly string _subDirectory;
        private readonly EmbeddedFileProvider _provider;

        public EmbeddedConfigurationLoader(string uriPrefix)
        {
            _subDirectory = uriPrefix ?? string.Empty;
            _provider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
        }

        public TConfiguration GetConfiguration<TConfiguration>(EmbeddedConfigurationPointer pointer)
            where TConfiguration : IConfiguration
        {
            pointer.Guard(nameof(pointer));

            var uri = pointer.BuildUri();
            var fileInfo = _provider.GetFileInfo(uri);

            using var stream = fileInfo.CreateReadStream();
            using var stringReader = new StreamReader(stream);

            var configJson = stringReader.ReadToEnd();

            try
            {
                return JsonConvert.DeserializeObject<TConfiguration>(configJson);
            }
            catch (JsonException)
            {
                Console.WriteLine($"Failed to load {typeof(TConfiguration).Name}");
                throw;
            }
        }
    }
}
