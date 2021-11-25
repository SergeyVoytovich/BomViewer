using System.Collections.Generic;
using System.Threading.Tasks;
using BomViewer.Data;
using BomViewer.DomainObjects;
using FluentAssertions;
using Moq;
using Xunit;

namespace BomViewer.Application.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public void Constructor()
        {
            // Prepare
            var dataSource = new Mock<IDataSource>();

            // Action
            var app = new Mock<Application>(dataSource.Object) {CallBase = true};

            // Assert
            app.Should().NotBeNull();
        }

        [Fact]
        public async Task GetGroups()
        {
            // Prepare
            var dataSource = new Mock<IDataSource>();
            dataSource.Setup(d => d.Groups.ToListAsync()).ReturnsAsync(new List<IGroup> {new Group()});
            var app = new Mock<Application>(dataSource.Object) { CallBase = true };

            // Action
            var actual = await app.Object.GetGroupsAsync();

            // Assert
            actual.Should().NotBeNullOrEmpty();
            dataSource.Verify(d => d.Groups.ToListAsync());
        }

        [Fact]
        public async Task GetParts()
        {
            // Prepare
            var dataSource = new Mock<IDataSource>();
            dataSource.Setup(d => d.Parts.ByGroups(It.IsAny<IList<IGroup>>()).ToListAsync()).ReturnsAsync(new List<IPart> { new Part() });
            var app = new Mock<Application>(dataSource.Object) { CallBase = true };

            // Action
            var actual = await app.Object.GetPartsAsync(new List<IGroup>());

            // Assert
            actual.Should().NotBeNullOrEmpty();
            dataSource.Verify(d => d.Parts.ByGroups(It.IsAny<IList<IGroup>>()).ToListAsync());
        }
    }
}