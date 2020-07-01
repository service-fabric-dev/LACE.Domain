using LACE.Domain.Configuration.Abstractions;
using LACE.Domain.Extensions;

namespace LACE.Domain.Configuration
{
    public class EmbeddedConfigurationPointer : IConfigurationPointer
    {
        /// <summary>
        /// Gets or sets the configuration file sans extension
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the configuration file extension
        /// </summary>
        public string FileExtension { get; set; }

        public string BuildUri()
        {
            if (FileName.IsNullOrWhitespace())
            {
                return string.Empty;
            }

            if (FileExtension.IsNullOrWhitespace())
            {
                return FileName;
            }

            if (FileName.EndsWith(FileExtension))
            {
                return FileName;
            }

            return $"{FileName.TrimEnd('.')}.{FileExtension.TrimStart('.')}";
            
        }
    }
}
