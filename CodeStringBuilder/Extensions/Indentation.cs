// <copyright file="Indentation.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

namespace CodeStringBuilder.Extensions;

/// <summary>
/// Represent an indentation.
/// </summary>
internal sealed class Indentation
    : IDisposable
{
    /// <summary>
    /// The indentation object.
    /// </summary>
    private readonly Builder builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="Indentation"/> class.
    /// </summary>
    /// <param name="builder">The indentation object.</param>
    internal Indentation(Builder builder)
    {
        this.builder = builder;
        this.builder.IncreaseIndentation();
    }

    /// <inheritdoc />
    public void Dispose()
    {
        this.builder.DecreaseIndentation();
    }
}