// <copyright file="Builder.NullableBlock.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace CodeStringBuilder;

/// <content>
/// Nullable block definition.
/// </content>
public sealed partial class Builder
{
    /// <summary>
    /// Start a new <c>#nullable</c> block.
    /// </summary>
    /// <param name="enable"><c>true</c> if nullable should be enabled, <c>false otherwise</c>.</param>
    /// <returns>A disposable object that can be used to go back to previous indentation.</returns>
    public IDisposable NullableBlock(bool enable)
        => new NullableBlockTermination(this, enable);

    /// <summary>
    /// Describe a nullability pragma block that will be closed
    /// using the <see cref="IDisposable"/> pattern.
    /// </summary>
    private sealed class NullableBlockTermination
        : IDisposable
    {
        /// <summary>
        /// The string builder.
        /// </summary>
        private readonly Builder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBlockTermination"/> class.
        /// </summary>
        /// <param name="builder">The string builder.</param>
        /// <param name="enable"><c>true</c> if nullable should be enabled, <c>false otherwise</c>.</param>
        internal NullableBlockTermination(Builder builder, bool enable)
        {
            this.builder = builder;
            this.builder.AppendLine($"#nullable {(enable ? "enable" : "disable")}");
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.builder.AppendLine("#nullable restore");
        }
    }
}