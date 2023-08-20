// <copyright file="StringBuilder.NullableDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Nullable pre-processor directive definition.
/// </content>
public sealed partial class StringBuilder
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
        private readonly StringBuilder stringBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableDirectiveTermination"/> class.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="enable"><c>true</c> if nullable should be enabled, <c>false otherwise</c>.</param>
        internal NullableDirectiveTermination(StringBuilder stringBuilder, bool enable)
        {
            this.stringBuilder = stringBuilder;
            this.stringBuilder.AppendLine($"#nullable {(enable ? "enable" : "disable")}");
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.stringBuilder.AppendLine("#nullable restore");
        }
    }
}