using AIRoutine.FullStack.Api.UnitTests.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AIRoutine.FullStack.Api.Core.UnitTests.Data;

/// <summary>
/// Tests fuer AppDbContext.
/// </summary>
[TestFixture]
[Category(TestCategories.Core)]
[Category(TestCategories.Data)]
[Category(TestCategories.Unit)]
internal class AppDbContextTests : BaseApiUnitTest
{
    [Test]
    [Category(TestCategories.Smoke)]
    public void AppDbContext_CanBeCreated() =>
        // TODO: Implementiere mit InMemory-DbContext
        _ = true.Should().BeTrue("Placeholder-Test");
}
