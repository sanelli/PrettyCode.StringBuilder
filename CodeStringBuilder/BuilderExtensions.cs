// <copyright file="BuilderExtensions.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

using CodeStringBuilder.Extensions;

namespace CodeStringBuilder;

/// <summary>
/// Extension methods for <see cref="Builder"/>.
/// </summary>
public static class BuilderExtensions
{
    /// <summary>
    /// Start a new indented block.
    /// </summary>
    /// <param name="builder">The builder on which apply the indentation.</param>
    /// <returns>A disposable object that can be used to go back to previous indentation.</returns>
    public static IDisposable Indent(this Builder builder)
        => new Indentation(builder);
}