// <copyright file="StringBuilderTests.PragmaWarningDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Unit tests for <see cref="StringBuilder.PragmaWarningDirective"/>.
/// </content>
public sealed partial class StringBuilderTests
{
    /// <summary>
    /// Unit tests <see cref="StringBuilder.PragmaWarningDirective"/>
    /// using default values.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateAPragmaWarningDirectiveWithDefaultValues()
    {
        // Arrange
        var builder = new StringBuilder();
        using (builder.PragmaWarningDirective())
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"#pragma warning disable{Environment.NewLine}Test{Environment.NewLine}#pragma warning restore");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.PragmaWarningDirective"/>
    /// with one warning.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateAPragmaWarningDirectiveWithOneWarning()
    {
        const string warningId = "CS0001";

        // Arrange
        var builder = new StringBuilder();
        using (builder.PragmaWarningDirective(warningId))
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"#pragma warning disable {warningId}{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"#pragma warning restore {warningId}");
    }

    /// <summary>
    /// Unit tests <see cref="StringBuilder.PragmaWarningDirective"/>
    /// with one warning.
    /// </summary>
    [Fact]
    [UnitTest]
    public void CanCreateAPragmaWarningDirectiveWithMultipleWarning()
    {
        const string warningId1 = "CS0001";
        const string warningId2 = "CS0002";

        // Arrange
        var builder = new StringBuilder();
        using (builder.PragmaWarningDirective(warningId1, warningId2))
        {
            builder.AppendLine("Test");
        }

        // Act
        var code = builder.ToString();

        // Assert
        code.Should().Be($"#pragma warning disable {warningId1}{Environment.NewLine}"
                         + $"#pragma warning disable {warningId2}{Environment.NewLine}"
                         + $"Test{Environment.NewLine}"
                         + $"#pragma warning restore {warningId2}{Environment.NewLine}"
                         + $"#pragma warning restore {warningId1}");
    }
}