﻿// <copyright file="StringBuilder.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

using System.Text;

namespace PrettyCode;

/// <summary>
/// The pretty code builder.
/// </summary>
/// <remarks>
/// Allows creating blocks of code that can be automatically
/// reverted to their original status using the <c>IDisposable</c>
/// pattern.
/// </remarks>
public sealed partial class StringBuilder
{
    private readonly System.Text.StringBuilder buffer;
    private readonly int spacesPerIndentation;
    private readonly char space;
    private readonly string newLine;
    private int indentation;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringBuilder"/> class.
    /// </summary>
    /// <param name="buffer">The buffer used to store the generated strings.</param>
    /// <param name="spacesPerIndentation">The number of spaces per  indentation..</param>
    /// <param name="space">The character to be used as space.</param>
    /// <param name="newLine">The sequence of character representing a new line.</param>
    /// <param name="indentation">The initial indentation level.</param>
    public StringBuilder(System.Text.StringBuilder buffer, int spacesPerIndentation, char space, string newLine, int indentation)
    {
        this.buffer = buffer;
        this.spacesPerIndentation = spacesPerIndentation;
        this.space = space;
        this.newLine = newLine;
        this.indentation = indentation;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringBuilder"/> class.
    /// </summary>
    /// <remarks>
    /// This uses default values: three spaces indentation and new line
    /// from <see cref="Environment.NewLine"/> with no indentation.
    /// </remarks>
    public StringBuilder()
        : this(new System.Text.StringBuilder(), 3, ' ', Environment.NewLine, 0)
    {
    }

    /// <summary>
    /// Gets a string representing the current indentation.
    /// </summary>
    private string Spaces => new(this.space, this.indentation * this.spacesPerIndentation);

    /// <inheritdoc/>
    public override string ToString()
    {
        return this.buffer.ToString().TrimEnd();
    }

    /// <summary>
    /// Append the lines to the builder.
    /// </summary>
    /// <param name="lines">The lines to be appended.</param>
    /// <returns>This object.</returns>
    public StringBuilder AppendLines(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            this.buffer.AppendLine($"{this.Spaces}{line.TrimEnd()}");
        }

        return this;
    }

    /// <summary>
    /// Append the line to the builder.
    /// </summary>
    /// <param name="line">The line to be appended.</param>
    /// <returns>This object.</returns>
    /// <remarks>
    /// If the line contains multiple lines it is split
    /// and each line is properly indented.
    /// </remarks>
    public StringBuilder AppendLine(string line)
        => this.AppendLines(line
            .Split(new[] { this.newLine }, StringSplitOptions.None)
            .Select(subLine => subLine.TrimEnd()));

    /// <summary>
    /// Append an empty line to the builder.
    /// </summary>
    /// <returns>This object.</returns>
    public StringBuilder AppendEmptyLine()
    {
        this.buffer.AppendLine(this.Spaces);
        return this;
    }

    /// <summary>
    /// Increase the indentation.
    /// </summary>
    private void IncreaseIndentation() => ++this.indentation;

    /// <summary>
    /// Decrease the indentation.
    /// </summary>
    private void DecreaseIndentation() => --this.indentation;
}