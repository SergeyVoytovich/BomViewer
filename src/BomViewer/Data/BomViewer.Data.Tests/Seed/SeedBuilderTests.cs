using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomViewer.Data.Entities;
using BomViewer.Data.Mapping;
using BomViewer.Data.Seed;
using BomViewer.Data.Seed.Readers;
using Dasync.Collections;
using FluentAssertions;
using Moq;
using Xunit;

namespace BomViewer.Data.Tests.Seed
{
    public class SeedBuilderTests
    {
        [Fact]
        public void Constructor()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) {CallBase = true};

            // Assert
            builder.Object.Should().NotBeNull();
        }

        [Fact]
        public async Task BuildAsync()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            var groups = new List<GroupEntity>();
            builder.Setup(b => b.BuildGroupsAsync()).ReturnsAsync(groups);
            builder.Setup(b => b.BuildPartsAsync(It.IsAny<IList<GroupEntity>>())).Returns(Task.CompletedTask);

            //Action
            await builder.Object.BuildAsync();

            // Assert
            builder.Verify(b => b.BuildGroupsAsync(), Times.Once);
            builder.Verify(b => b.BuildPartsAsync(It.Is<IList<GroupEntity>>(i => Equals(i, groups))), Times.Once);
        }



        #region BuildGroup

        [Fact]
        public async Task BuildGroupsAsync()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var reader = new Mock<IReader<GroupSeed>>();
            var readers = new Mock<IReadersFactory>();
            readers.Setup(r => r.Groups(It.IsAny<string>())).Returns(reader.Object);
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            var groups = new List<GroupEntity>();
            builder.Setup(b => b.BuildGroupsAsync(It.IsAny<IReader<GroupSeed>>())).ReturnsAsync(groups);

            //Action
            await builder.Object.BuildGroupsAsync();

            // Assert
            builder.Verify(b => b.BuildGroupsAsync(It.Is<IReader<GroupSeed>>(r => r == reader.Object)));
            readers.Verify(r => r.Groups(It.Is<string>(s => s == SeedBuilder.GroupsFileName)));
        }

        [Fact]
        public async Task BuildGroupsAsync_ByReader()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var reader = new Mock<IReader<GroupSeed>>();
            var asyncEnumerable = new AsyncEnumerable<GroupSeed>(yield => yield.ReturnAsync(new GroupSeed()));
            reader.Setup(r => r.ReadAsync()).Returns(asyncEnumerable);
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            var groups = new List<GroupEntity>();
            builder.Setup(b => b.BuildGroupsAsync(It.IsAny<IAsyncEnumerable<GroupSeed>>())).ReturnsAsync(groups);

            //Action
            await builder.Object.BuildGroupsAsync(reader.Object);

            // Assert
            builder.Verify(b => b.BuildGroupsAsync(It.Is<IAsyncEnumerable<GroupSeed>>(e => e == asyncEnumerable)));
            reader.Verify(r => r.ReadAsync());
        }

        [Fact]
        public async Task BuildGroupsAsync_ByAsyncEnumerable()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var asyncEnumerable = new AsyncEnumerable<GroupSeed>(yield => yield.ReturnAsync(new GroupSeed()));
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            var groups = new List<GroupEntity>();
            builder.Setup(b => b.BuildGroupsAsync(It.IsAny<IAsyncEnumerator<GroupSeed>>())).ReturnsAsync(groups);

            //Action
            await builder.Object.BuildGroupsAsync(asyncEnumerable);

            // Assert
            builder.Verify(b => b.BuildGroupsAsync(It.IsAny<IAsyncEnumerator<GroupSeed>>()));
        }

        [Fact]
        public async Task BuildGroupsAsync_ByAsyncEnumerator()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var asyncEnumerable = new AsyncEnumerable<GroupSeed>(yield => yield.ReturnAsync(new GroupSeed()));
            var enumerator = asyncEnumerable.GetAsyncEnumerator();
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            builder.Setup(b => b.BuildGroup(It.IsAny<GroupSeed>(), It.IsAny<IList<GroupEntity>>())).Returns(new GroupEntity());

            //Action
            var actual = await builder.Object.BuildGroupsAsync(enumerator);

            // Assert
            actual.Should().HaveCount(1);
            builder.Verify(b => b.BuildGroup(It.Is<GroupSeed>(g => g != null), It.IsAny<IList<GroupEntity>>()));
        }

        [Fact]
        public void BuildGroup()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            entityBuilder.Setup(b => b.HasData(It.IsAny<It.IsAnyType>()));
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            var parent = new GroupEntity { Name = "test" };

            //Action

            var actual = builder.Object.BuildGroup(new GroupSeed{ParentName = "test"}, new []{parent});

            // Assert
            actual.Should().NotBeNull();
            actual.Parent.Should().NotBeNull().And.Be(parent);
            entityBuilder.Verify(b => b.HasData(It.IsAny<It.IsAnyType>()));
        }

        #endregion


        #region Build part

        [Fact]
        public async Task BuildPartsAsync()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var readers = new Mock<IReadersFactory>();
            readers.Setup(r => r.Parts(It.IsAny<string>())).Returns(Mock.Of<IReader<PartSeed>>());
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            builder.Setup(b => b.BuildPartsAsync(It.IsAny<IList<GroupEntity>>(), It.IsAny<IReader<PartSeed>>())).Returns(Task.CompletedTask);

            //Action

            await builder.Object.BuildPartsAsync(new List<GroupEntity>());

            // Assert
            readers.Verify(r => r.Parts(It.Is<string>(s => s == SeedBuilder.PartsFileName)));
            builder.Verify(b => b.BuildPartsAsync(It.IsAny<IList<GroupEntity>>(), It.Is<IReader<PartSeed>>(r => r != null)));
        }

        [Fact]
        public async Task BuildPartsAsync_ByReader()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var reader = new Mock<IReader<PartSeed>>();
            reader.Setup(r => r.ReadAsync()).Returns(new AsyncEnumerable<PartSeed>(yield => yield.ReturnAsync(new PartSeed())));
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            builder.Setup(b => b.BuildPartsAsync(It.IsAny<IList<GroupEntity>>(), It.IsAny<IAsyncEnumerable<PartSeed>>())).Returns(Task.CompletedTask);

            //Action

            await builder.Object.BuildPartsAsync(new List<GroupEntity>(), reader.Object);

            // Assert
            builder.Verify(b => b.BuildPartsAsync(It.IsAny<IList<GroupEntity>>(), It.IsAny<IAsyncEnumerable<PartSeed>>()));
            reader.Verify(r => r.ReadAsync());
        }

        [Fact]
        public async Task BuildPartsAsync_ByAsyncEnumerable()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var enumerable = new AsyncEnumerable<PartSeed>(yield => yield.ReturnAsync(new PartSeed()));
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            builder.Setup(b => b.BuildPartsAsync(It.IsAny<IList<GroupEntity>>(), It.IsAny<IAsyncEnumerator<PartSeed>>())).Returns(Task.CompletedTask);

            //Action

            await builder.Object.BuildPartsAsync(new List<GroupEntity>(), enumerable);

            // Assert
            builder.Verify(b => b.BuildPartsAsync(It.IsAny<IList<GroupEntity>>(), It.IsAny<IAsyncEnumerator<PartSeed>>()));
        }

        [Fact]
        public async Task BuildPartsAsync_ByAsyncEnumerator()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var enumerator = new AsyncEnumerable<PartSeed>(yield => yield.ReturnAsync(new PartSeed())).GetAsyncEnumerator();
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            builder.Setup(b => b.BuildPart(It.IsAny<IList<GroupEntity>>(), It.IsAny<PartSeed>(), It.IsAny<int>()));

            //Action

            await builder.Object.BuildPartsAsync(new List<GroupEntity>(), enumerator);

            // Assert
            builder.Verify(b => b.BuildPart(It.IsAny<IList<GroupEntity>>(), It.IsAny<PartSeed>(), It.IsAny<int>()), Times.Exactly(1));
        }

        [Fact]
        public void BuildPart()
        {
            // Prepare
            var mapper = MapperFactory.Init();
            var readers = new Mock<IReadersFactory>();
            var entityBuilder = new Mock<IEntityBuilder>();
            entityBuilder.Setup(b => b.HasData(It.IsAny<It.IsAnyType>()));
            var builder = new Mock<SeedBuilder>(readers.Object, mapper, entityBuilder.Object) { CallBase = true };
            var groups = new List<GroupEntity> {new GroupEntity {Name = "test"}};
            var seed = new PartSeed {Name = "test"};
            const int id = 1;

            //Action
            builder.Object.BuildPart(groups, seed, id);

            // Assert
            entityBuilder.Verify(b => b.HasData(It.Is<PartEntity>(p => p.Id == id + 1 && p.Group == groups.First())));
        }

        #endregion
    }
}