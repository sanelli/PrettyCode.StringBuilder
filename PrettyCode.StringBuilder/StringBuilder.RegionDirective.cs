// <copyright file="StringBuilder.RegionDirective.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace PrettyCode;

/// <content>
/// Curly braces pre-processor directive definition.
/// </content>
public sealed partial class StringBuilder
{
    /// <summary>
    /// Start a region block.
    /// </summary>
    /// <param name="regionName">The optional name of the region being created.</param>
    /// <returns>A disposable object that can be used to close the curly braces block.</returns>
    public IDisposable RegionDirective(string? regionName = null)
        => new RegionDirectiveTerminator(this, regionName ?? string.Empty);

    /// <summary>
    /// Define a code block surrounded by <c>{</c> and <c>}</c>.
    /// </summary>
    private sealed class RegionDirectiveTerminator
        : IDisposable
    {
        /// <summary>
        /// The string builder.
        /// </summary>
        private readonly StringBuilder stringBuilder;

        private readonly string regionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionDirectiveTerminator"/> class.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="regionName">The optional name of the region.</param>
        internal RegionDirectiveTerminator(StringBuilder stringBuilder, string regionName)
        {
            this.stringBuilder = stringBuilder;
            regionName = !string.IsNullOrWhiteSpace(regionName) ? $" {regionName.Trim()}" : string.Empty;
            this.stringBuilder.AppendLine($"#region{regionName}");
            this.regionName = string.IsNullOrWhiteSpace(regionName) ? string.Empty : $" //{regionName}";
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.stringBuilder.AppendLine($"#endregion{this.regionName}");
        }
    }
}