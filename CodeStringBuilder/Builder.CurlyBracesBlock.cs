// <copyright file="Builder.CurlyBracesBlock.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace CodeStringBuilder;

/// <content>
/// Curly braces block definition.
/// </content>
public sealed partial class Builder
{
    /// <summary>
    /// Start a curly braces block.
    /// </summary>
    /// <param name="addSemicolonAfterClose"><c>true</c> if a semicolon should be added after the closing brace.</param>
    /// <returns>A disposable object that can be used to close the curly braces block.</returns>
    public IDisposable CurlyBracesBlock(bool addSemicolonAfterClose = false)
        => new CurlyBracesBlockTerminator(this, addSemicolonAfterClose);

    /// <summary>
    /// Define a code block surrounded by <c>{</c> and <c>}</c>.
    /// </summary>
    private sealed class CurlyBracesBlockTerminator
        : IDisposable
    {
        private readonly Builder builder;
        private readonly bool addSemicolonAfterClose;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurlyBracesBlockTerminator"/> class.
        /// </summary>
        /// <param name="builder">The string builder.</param>
        /// <param name="addSemicolonAfterClose"><c>true</c> if a semicolon should be added when closing the block.</param>
        internal CurlyBracesBlockTerminator(Builder builder, bool addSemicolonAfterClose)
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
}