// <copyright file="StringBuilderTests.NullableDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Unit tests for <see cref="StringBuilder.NullableDirective"/>.
/// </content>
public sealed partial class StringBuilderTests
{
    /// <summary>
    /// Unit tests <see cref="StringBuilder.NullableDirective"/>
    /// using default values.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateANullableDirectiveWithDefaultValues()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.NullableDirective())
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"#nullable enable{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"#nullable restore");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.NullableDirective"/>
    /// with enable set to false.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateANullableDirectiveWithEnableSetToFalse()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.NullableDirective(enable: false))
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"#nullable disable{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"#nullable restore");
    }
}