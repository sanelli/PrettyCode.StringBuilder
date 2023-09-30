// <copyright file="StringBuilderTests.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <summary>
/// Unit tests for <see cref="PrettyCode.StringBuilder"/>.
/// </summary>
public sealed partial class StringBuilderTests
{
    /// <summary>
    /// Unit tests <see cref="StringBuilder.AppendLine"/>.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanAppendALine()
    {
        // Arrange
        var builder = new StringBuilder();
        builder.AppendLine("Test");

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be("Test");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.AppendLine"/>.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanAppendALineContainingMultipleLines()
    {
        // Arrange
        var builder = new StringBuilder();
        builder.AppendLine($"Test{Environment.NewLine}Foo{Environment.NewLine}Bar");

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"Test{Environment.NewLine}Foo{Environment.NewLine}Bar");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.AppendEmptyLine"/>.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanAppendAnEmptyLine()
    {
        // Arrange
        var builder = new StringBuilder();
        builder.AppendEmptyLine();

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be(string.Empty);
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.AppendLines"/>.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanAppendMultipleLines()
    {
        // Arrange
        var builder = new StringBuilder();
        builder.AppendLines(new[] { "Test", "Bar" });

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"Test{Environment.NewLine}Bar");
    }
}