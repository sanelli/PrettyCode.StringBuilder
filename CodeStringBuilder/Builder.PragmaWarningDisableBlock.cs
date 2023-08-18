// <copyright file="Builder.PragmaWarningDisableBlock.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace CodeStringBuilder;

/// <content>
/// Pragma warning disable block definition.
/// </content>
public sealed partial class Builder
{
    /// <summary>
    /// Start a new indented block.
    /// </summary>
    /// <param name="warnings">The warnings to disable.</param>
    /// <returns>A disposable object that can be used to go back to previous indentation.</returns>
    public IDisposable PragmaWarningDisableBlock(params string[] warnings)
        => new PragmaWarningDisableBlockTermination(this, warnings);

    /// <summary>
    /// Describe a warning disable pragma block that will be closed (i.e. restored)
    /// using the <see cref="IDisposable"/> pattern.
    /// </summary>
    private sealed class PragmaWarningDisableBlockTermination
        : IDisposable
    {
        /// <summary>
        /// The string builder.
        /// </summary>
        private readonly Builder builder;

        /// <summary>
        /// The warnings disabled.
        /// </summary>
        private readonly string[] warnings;

        /// <summary>
        /// Initializes a new instance of the <see cref="PragmaWarningDisableBlockTermination"/> class.
        /// </summary>
        /// <param name="builder">The string builder.</param>
        /// <param name="warnings">The warnings to disable.</param>
        internal PragmaWarningDisableBlockTermination(Builder builder, params string[] warnings)
        {
            this.builder = builder;
            this.warnings = warnings;
            if (warnings.Length > 0)
            {
                foreach (var warning in warnings)
                {
                    this.builder.AppendLine($"#pragma warning disable {warning}");
                }
            }
            else
            {
                this.builder.AppendLine("#pragma warning disable");
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (this.warnings.Length > 0)
            {
                foreach (var warning in this.warnings)
                {
                    this.builder.AppendLine($"#pragma warning restore {warning}");
                }
            }
            else
            {
                this.builder.AppendLine("#pragma warning restore");
            }
        }
    }
}