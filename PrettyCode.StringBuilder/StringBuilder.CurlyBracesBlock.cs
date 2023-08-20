// <copyright file="StringBuilder.CurlyBracesBlock.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Curly braces block definition.
/// </content>
public sealed partial class StringBuilder
{
    /// <summary>
    /// Start a curly braces block.
    /// </summary>
    /// <param name="addSemicolonAfterClose"><c>true</c> if a semicolon should be added after the closing brace.</param>
    /// <param name="indent"><c>true</c> if indentation should be applied between braces.</param>
    /// <returns>A disposable object that can be used to close the curly braces block.</returns>
    public IDisposable CurlyBracesBlock(bool addSemicolonAfterClose = false, bool indent = true)
        => new CurlyBracesBlockTerminator(this, addSemicolonAfterClose, indent);

    /// <summary>
    /// Define a code block surrounded by <c>{</c> and <c>}</c>.
    /// </summary>
    private sealed class CurlyBracesBlockTerminator
        : IDisposable
    {
        private readonly StringBuilder stringBuilder;
        private readonly bool addSemicolonAfterClose;
        private readonly IDisposable? indentation = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurlyBracesBlockTerminator"/> class.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="addSemicolonAfterClose"><c>true</c> if a semicolon should be added when closing the block.</param>
        /// <param name="indent"><c>true</c> if indentation should be applied between braces.</param>
        internal CurlyBracesBlockTerminator(StringBuilder stringBuilder, bool addSemicolonAfterClose, bool indent)
        {
            this.stringBuilder = stringBuilder;
            this.addSemicolonAfterClose = addSemicolonAfterClose;
            this.stringBuilder.AppendLine("{");
            if (indent)
            {
                this.indentation = this.stringBuilder.Indent();
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.indentation?.Dispose();
            this.stringBuilder.AppendLine(this.addSemicolonAfterClose ? "};" : "}");
        }
    }
}