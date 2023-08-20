// <copyright file="StringBuilder.Indentation.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Indentation definition.
/// </content>
public sealed partial class StringBuilder
{
    /// <summary>
    /// Start a new indented block.
    /// </summary>
    /// <returns>A disposable object that can be used to go back to previous indentation.</returns>
    public IDisposable Indent()
        => new IndentTermination(this);

    /// <summary>
    /// Represent an indentation that will be reverted once the
    /// block gets disposed.
    /// </summary>
    internal sealed class IndentTermination
        : IDisposable
    {
        private readonly StringBuilder stringBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndentTermination"/> class.
        /// </summary>
        /// <param name="stringBuilder">The indentation object.</param>
        internal IndentTermination(StringBuilder stringBuilder)
        {
            this.stringBuilder = stringBuilder;
            this.stringBuilder.IncreaseIndentation();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.stringBuilder.DecreaseIndentation();
        }
    }
}