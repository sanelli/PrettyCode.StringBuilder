// <copyright file="Program.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

Console.WriteLine("==================================");
Console.WriteLine("=== CodeStringBuilder.Examples ===");
Console.WriteLine("==================================\n");

Console.WriteLine(BuildIndentedCode());
Console.WriteLine();

Console.WriteLine(CurlyBracesBlock());
Console.WriteLine();

Console.WriteLine(PragmaWarningDirective());
Console.WriteLine();

return;

static string BuildIndentedCode()
{
    Console.WriteLine("/*********************************/");
    Console.WriteLine("/* Indented block                */");
    Console.WriteLine("/*********************************/");

    var builder = new CodeStringBuilder.Builder();
    builder.AppendLine("def main():");
    using (builder.Indent())
    {
        builder.AppendLine("print('Hello world!')");
    }

    builder.AppendLine("# The function ended here!");
    return builder.ToString();
}

static string CurlyBracesBlock()
{
    Console.WriteLine("/*********************************/");
    Console.WriteLine("/* Curly braces block            */");
    Console.WriteLine("/*********************************/");

    var builder = new CodeStringBuilder.Builder();
    builder.AppendLine("struct cplusplus");
    using (builder.CurlyBracesBlock(indent: false))
    {
        builder.AppendLine("private:");
        builder.AppendLine("int foo;");
    }

    return builder.ToString();
}

static string PragmaWarningDirective()
{
    Console.WriteLine("/*********************************/");
    Console.WriteLine("/* Pragma warning directive      */");
    Console.WriteLine("/*********************************/");

    var builder = new CodeStringBuilder.Builder();
    builder.AppendLine("try");
    using (builder.CurlyBracesBlock())
    {
        builder.AppendLine("/* Do something */");
    }

    builder.AppendLine("catch (Exception e)");
    using (builder.PragmaWarningDirective(true, "CA2200"))
    using (builder.CurlyBracesBlock())
    {
        builder.AppendLine("throw e;");
    }

    return builder.ToString();
}