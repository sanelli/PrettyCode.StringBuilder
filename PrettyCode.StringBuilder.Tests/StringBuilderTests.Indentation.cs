// <copyright file="StringBuilderTests.Indentation.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Unit tests for <see cref="StringBuilder.Indent"/>.
/// </content>
public sealed partial class StringBuilderTests
{
    /// <summary>
    /// Unit tests <see cref="StringBuilder.Indent"/>
    /// using default values.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanIdentTextUsingDefaultValues()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.Indent())
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be("   Test");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.Indent"/>
    /// using default values.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanIdentTextUsingDefaultValuesAnEmptyLine()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.Indent())
        {
            builder.AppendEmptyLine();
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be(string.Empty);
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.Indent"/>
    /// using default values and multiple lines.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanIdentTextUsingDefaultValuesAndMultipleLines()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.Indent())
        {
            builder.AppendLines(new[] { "Test", "Foo", "Bar" });
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"   Test{Environment.NewLine}   Foo{Environment.NewLine}   Bar");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.Indent"/>
    /// using default values and multiple lines.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanIdentTextUsingDefaultValuesAndMultipleLinesInASingleString()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.Indent())
        {
            builder.AppendLine($"Test{Environment.NewLine}Foo{Environment.NewLine}Bar");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"   Test{Environment.NewLine}   Foo{Environment.NewLine}   Bar");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.Indent"/>
    /// using custom values.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanIdentText()
    {
        // Arrange
        var builder = new StringBuilder(new System.Text.StringBuilder(), 2, '\t', Environment.NewLine, 0);
        using (builder.Indent())
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be("\t\tTest");
    }
}