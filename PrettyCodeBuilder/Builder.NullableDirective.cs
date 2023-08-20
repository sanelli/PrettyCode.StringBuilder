// <copyright file="Builder.NullableDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Nullable pre-processor directive definition.
/// </content>
public sealed partial class Builder
{
    /// <summary>
    /// Start a new <c>#nullable</c> directive.
    /// </summary>
    /// <param name="enable"><c>true</c> if nullable should be enabled, <c>false otherwise</c>.</param>
    /// <returns>A disposable object that can be used to go back to previous indentation.</returns>
    public IDisposable NullableDirective(bool enable = true)
        => new NullableDirectiveTermination(this, enable);

    /// <summary>
    /// Describe a <c>#nullable</c> pragma block that will be restored
    /// using the <see cref="IDisposable"/> pattern.
    /// </summary>
    private sealed class NullableDirectiveTermination
        : IDisposable
    {
        private readonly Builder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableDirectiveTermination"/> class.
        /// </summary>
        /// <param name="builder">The string builder.</param>
        /// <param name="enable"><c>true</c> if nullable should be enabled, <c>false otherwise</c>.</param>
        internal NullableDirectiveTermination(Builder builder, bool enable)
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