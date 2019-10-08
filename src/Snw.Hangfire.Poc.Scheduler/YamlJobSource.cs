using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Snw.Hangfire.Poc.Scheduler
{
    public class YamlJobSource : IJobSource
    {
        private readonly IOptionsMonitor<YamlSettings> _options;

        public YamlJobSource(IOptionsMonitor<YamlSettings> options)
        {
            _options = options;
        }

        public IEnumerable<Job> GetJobs()
        {
            var settings = _options.CurrentValue;
            if (!File.Exists(settings.Location))
                throw new FileNotFoundException("Could not find scheduler job yaml file", settings.Location);

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            using (var reader = File.OpenText(settings.Location))
            {
                return deserializer.Deserialize<IEnumerable<Job>>(reader);
            }
        }
    }
}