// <copyright file="StringBuilderTests.Indent.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <summary>
/// Unit tests for <see cref="PrettyCode.StringBuilder"/>
/// </summary>
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