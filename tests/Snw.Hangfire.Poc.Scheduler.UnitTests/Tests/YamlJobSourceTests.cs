using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Snw.Hangfire.Poc.Scheduler.UnitTests.Tests
{
    public class YamlJobSourceTests : TestBase
    {
        [Fact]
        public void GivenValidSource_ThenItReturnsJobs()
        {
            var settings = new YamlSettings {Location = "jobs.yml"};
            var options = MockRepository.Of<IOptionsMonitor<YamlSettings>>().First(x => x.CurrentValue == settings);
            var source = new YamlJobSource(options);

            var jobs = source.GetJobs().ToList();

            jobs.Should().NotBeNullOrEmpty();
            jobs.Count.Should().Be(2);

            var job = jobs.First();
            job.Should().NotBeNull();
            job.Name.Should().BeEquivalentTo("Test job A");
            job.Location.Should().BeEquivalentTo("test.ps1");
            job.Type.Should().Be(JobType.Powershell);
            job.Schedule.Should().BeEquivalentTo("* * * * *");
        }

        [Fact]
        public void GivenInvalidFileLocation_ThenItThrows()
        {
            var settings = new YamlSettings {Location = "foo.yml"};
            var options = MockRepository.Of<IOptionsMonitor<YamlSettings>>().First(x => x.CurrentValue == settings);
            var source = new YamlJobSource(options);

            var exception = Assert.Throws<FileNotFoundException>(() => source.GetJobs());

            exception.Should().NotBeNull();
        }
    }
}
