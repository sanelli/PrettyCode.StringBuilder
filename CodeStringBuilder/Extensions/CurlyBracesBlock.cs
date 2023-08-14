// <copyright file="CurlyBracesBlock.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace CodeStringBuilder.Extensions;

/// <summary>
/// Define a code block surrounded by <c>{</c> and <c>}</c>.
/// </summary>
internal sealed class CurlyBracesBlock
    : IDisposable
{
    /// <summary>
    /// The string builder.
    /// </summary>
    private readonly Builder builder;

    /// <summary>
    /// <c>true</c> if a semicolon should be added when closing
    /// the block.
    /// </summary>
    private readonly bool addSemicolonAfterClose;

    /// <summary>
    /// Initializes a new instance of the <see cref="CurlyBracesBlock"/> class.
    /// </summary>
    /// <param name="builder">The string builder.</param>
    /// <param name="addSemicolonAfterClose"><c>true</c> if a semicolon should be added when closing the block.</param>
    internal CurlyBracesBlock(Builder builder, bool addSemicolonAfterClose)
    {
        this.builder = builder;
        this.addSemicolonAfterClose = addSemicolonAfterClose;
        this.builder.AppendLine("{");
    }

    /// <inheritdoc />
    public void Dispose()
    {
        this.builder.AppendLine(this.addSemicolonAfterClose ? "};" : "}");
    }
}