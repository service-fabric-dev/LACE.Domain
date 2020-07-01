using System.IO;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Newtonsoft.Json;

namespace LACE.Core.Content
{
    public class EmbeddedContentLoader
    {
        private static readonly EmbeddedFileProvider Provider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());
        
        public TContent LoadJson<TContent>(string contentUri)
        {
            var stream = Provider.GetFileInfo(contentUri).CreateReadStream();
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<TContent>(content);
            }
        }
    }
}
