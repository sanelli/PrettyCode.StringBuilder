// <copyright file="Builder.PragmaWarningDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace CodeStringBuilder;

/// <content>
/// Pragma warning pre-processor directive definition.
/// </content>
public sealed partial class Builder
{
    /// <summary>
    /// Start a <c>#pragma warning</c> pre-processor directive.
    /// </summary>
    /// <param name="disable"><c>true</c> if the warnings should be disabled, <c>false</c> if warnings should be restored.</param>
    /// <param name="warnings">The warnings to disable.</param>
    /// <returns>A disposable object that can be used to go back to previous indentation.</returns>
    public IDisposable PragmaWarningDirective(bool disable = true, params string[] warnings)
        => new PragmaWarningDirectiveTermination(this, disable, warnings);

    /// <summary>
    /// Describe a <c>#pragma warning</c> pre-processor directive that will be reverted
    /// using the <see cref="IDisposable"/> pattern.
    /// </summary>
    private sealed class PragmaWarningDirectiveTermination
        : IDisposable
    {
        private readonly Builder builder;
        private readonly bool disable;
        private readonly string[] warnings;

        /// <summary>
        /// Initializes a new instance of the <see cref="PragmaWarningDirectiveTermination"/> class.
        /// </summary>
        /// <param name="builder">The string builder.</param>
        /// <param name="disable"><c>true</c> if the warnings should be disabled, <c>false</c> if warnings should be restored.</param>
        /// <param name="warnings">The warnings to disable or restore.</param>
        internal PragmaWarningDirectiveTermination(Builder builder, bool disable, params string[] warnings)
        {
            this.builder = builder;
            this.disable = disable;
            this.warnings = warnings;

            var disableString = disable ? "disable" : "restore";
            if (warnings.Length > 0)
            {
                foreach (var warning in warnings)
                {
                    this.builder.AppendLine($"#pragma warning {disableString} {warning}");
                }
            }
            else
            {
                this.builder.AppendLine($"#pragma warning {disableString}");
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            var restoreString = !this.disable ? "disable" : "restore";
            if (this.warnings.Length > 0)
            {
                foreach (var warning in this.warnings)
                {
                    this.builder.AppendLine($"#pragma warning {restoreString} {warning}");
                }
            }
            else
            {
                this.builder.AppendLine($"#pragma warning {restoreString}");
            }
        }
    }
}