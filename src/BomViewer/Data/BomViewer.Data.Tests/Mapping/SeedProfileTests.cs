using System.Collections.Generic;
using BomViewer.Data.Entities;
using BomViewer.Data.Mapping;
using BomViewer.Data.Seed;
using FluentAssertions;
using Xunit;

namespace BomViewer.Data.Tests.Mapping
{
    public class SeedProfileTests
    {
        #region Group

        public static IEnumerable<object[]> GroupData()
        {
            yield return new object[]
            {
                new GroupSeed {ComponentName = "test", ParentName = "test parent", Quantity = 123},
                new GroupEntity {Name = "test"}
            };
        }

        [Theory]
        [MemberData(nameof(GroupData))]
        public void Group(GroupSeed seed, GroupEntity expected)
        {
            // Prepare
            var mapper = MapperFactory.Init();

            // Action
            var actual = mapper.Map<GroupEntity>(seed);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.Match<GroupEntity>(g => g.Name == expected.Name);
        }

        #endregion


        #region Part

        public static IEnumerable<object[]> PartData()
        {
            yield return new object[]
            {
                new PartSeed {Item = "item", Material = "material", Name = "component name", PartNumber = "number", Title = "title", Type = "type"},
                new PartEntity {Item = "item", Material = "material", Number = "number", Title = "title", Type = "type"}
            };
        }

        [Theory]
        [MemberData(nameof(PartData))]
        public void Part(PartSeed seed, PartEntity expected)
        {
            // Prepare
            var mapper = MapperFactory.Init();

            // Action
            var actual = mapper.Map<PartEntity>(seed);

            // Assert
            actual.Should()
                .NotBeNull()
                .And.Match<PartEntity>(p => p.Item == expected.Item
                                            && p.Material == expected.Material
                                            && p.Number == expected.Number
                                            && p.Title == expected.Title
                                            && p.Type == expected.Type);
        }

        #endregion
    }
}