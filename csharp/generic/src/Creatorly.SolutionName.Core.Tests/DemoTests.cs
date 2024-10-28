using FluentAssertions;
using NSubstitute;

namespace Creatorly.SolutionName.Core.Tests;

public class DemoTests
{
    private Demo _sut;
    private IDemoDownloader _demoDownloaderMock;

    public DemoTests()
    {
        _demoDownloaderMock = NSubstitute.Substitute.For<IDemoDownloader>();
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
