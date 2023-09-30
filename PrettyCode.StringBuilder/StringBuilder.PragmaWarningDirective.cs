// <copyright file="StringBuilder.PragmaWarningDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Pragma warning pre-processor directive definition.
/// </content>
public sealed partial class StringBuilder
{
    /// <summary>
    /// Start a <c>#pragma warning</c> pre-processor directive.
    /// </summary>
    /// <param name="warnings">The warnings to disable.</param>
    /// <returns>A disposable object that can be used to go back to previous indentation.</returns>
    public IDisposable PragmaWarningDirective(params string[] warnings)
        => new PragmaWarningDirectiveTermination(this, warnings);

    /// <summary>
    /// Describe a <c>#pragma warning</c> pre-processor directive that will be reverted
    /// using the <see cref="IDisposable"/> pattern.
    /// </summary>
    private sealed class PragmaWarningDirectiveTermination
        : IDisposable
    {
        private readonly StringBuilder stringBuilder;
        private readonly string[] warnings;

        /// <summary>
        /// Initializes a new instance of the <see cref="PragmaWarningDirectiveTermination"/> class.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="warnings">The warnings to disable or restore.</param>
        internal PragmaWarningDirectiveTermination(StringBuilder stringBuilder, params string[] warnings)
        {
            this.stringBuilder = stringBuilder;
            this.warnings = warnings;

            this.DoAppendPragmaLine("disable", false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.DoAppendPragmaLine("restore", true);
        }

        private void DoAppendPragmaLine(string what, bool reverse)
        {
            if (this.warnings.Length > 0)
            {
                foreach (var warning in reverse ? this.warnings.Reverse() : this.warnings)
                {
                    this.stringBuilder.AppendLine($"#pragma warning {what} {warning}");
                }
            }
            else
            {
                this.stringBuilder.AppendLine($"#pragma warning {what}");
            }
        }
    }
}