// <copyright file="StringBuilderTests.CurlyBracesBlock.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Unit tests for <see cref="StringBuilder.CurlyBracesBlock"/>.
/// </content>
public sealed partial class StringBuilderTests
{
    /// <summary>
    /// Unit tests <see cref="StringBuilder.CurlyBracesBlock"/>
    /// using default values.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateACurlyBracesBlockWithDefaultValues()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.CurlyBracesBlock())
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"{{{Environment.NewLine}"
                         + $"   Test{Environment.NewLine}"
                         + $"}}");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.CurlyBracesBlock"/>
    /// without indentation.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateACurlyBracesBlockWithoutIndentation()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.CurlyBracesBlock(indent: false))
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"{{{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"}}");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.CurlyBracesBlock"/>
    /// with trailing semicolon.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateACurlyBracesBlockWithTrailingSemicolon()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.CurlyBracesBlock(trailingSemicolon: true))
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"{{{Environment.NewLine}"
                         + $"   Test{Environment.NewLine}"
                         + $"}};");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.CurlyBracesBlock"/>
    /// without indentation and with trailing semicolon.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateACurlyBracesBlockWithoutIndentationWithTrailingSemicolon()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.CurlyBracesBlock(trailingSemicolon: true, indent: false))
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"{{{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"}};");
    }
}