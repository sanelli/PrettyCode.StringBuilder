// <copyright file="StringBuilderTests.RegionDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Unit tests for <see cref="StringBuilder.RegionDirective"/>.
/// </content>
public sealed partial class StringBuilderTests
{
    /// <summary>
    /// Unit tests <see cref="StringBuilder.RegionDirective"/>
    /// using default values.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateARegionDirectiveWithDefaultValues()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.RegionDirective())
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"#region{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"#endregion");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.RegionDirective"/>
    /// with a name.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateARegionDirectiveWithName()
    {
        const string regionName = "MyRegion";

        // Arrange
        var builder = new StringBuilder();
        using (builder.RegionDirective(regionName))
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"#region {regionName}{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"#endregion // {regionName}");
    }
}