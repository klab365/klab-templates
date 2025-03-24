using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;

namespace Creatorly.SolutionName.Core.UnitTests;

public class DemoTests
{
    private readonly Demo _sut;
    private readonly IDemoDownloader _demoDownloaderMock;

    public DemoTests()
    {
        _demoDownloaderMock = Substitute.For<IDemoDownloader>();
        _sut = new("Test", _demoDownloaderMock);
    }

    [Fact]
    public async Task TestMethod1()
    {
        _demoDownloaderMock.DownloadNameAsync().Returns("Test");
        string result = await _sut.GetDownloadedNameAsync();
        result.Should().Be("Test");
    }
}
