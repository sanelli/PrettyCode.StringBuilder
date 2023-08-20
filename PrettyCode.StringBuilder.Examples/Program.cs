// <copyright file="Program.cs" company="Stefano Anelli">
// Copyright (c) Stefano Anelli. All rights reserved.
// </copyright>

Console.WriteLine("=========================================");
Console.WriteLine("=== PrettyCode.StringBuilder.Examples ===");
Console.WriteLine("=========================================");
Console.WriteLine();

Console.WriteLine(BuildIndentedCode());
Console.WriteLine();

Console.WriteLine(CurlyBracesBlock());
Console.WriteLine();

Console.WriteLine(PragmaWarningDirective());
Console.WriteLine();

Console.WriteLine(NullableDirective());
Console.WriteLine();

Console.WriteLine(RegionDirective());
Console.WriteLine();

return;

static string BuildIndentedCode()
{
    Console.WriteLine("/*********************************/");
    Console.WriteLine("/* Indented block                */");
    Console.WriteLine("/*********************************/");

    var builder = new PrettyCode.StringBuilder();
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

    var builder = new PrettyCode.StringBuilder();
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

    var builder = new PrettyCode.StringBuilder();
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

static string NullableDirective()
{
    Console.WriteLine("/*********************************/");
    Console.WriteLine("/* Nullable directive            */");
    Console.WriteLine("/*********************************/");

    var builder = new PrettyCode.StringBuilder();
    using (builder.NullableDirective())
    {
        builder.AppendLine("int? foo = null");
    }

    return builder.ToString();
}

static string RegionDirective()
{
    Console.WriteLine("/*********************************/");
    Console.WriteLine("/* Region directive              */");
    Console.WriteLine("/*********************************/");

    var builder = new PrettyCode.StringBuilder();
    using (builder.RegionDirective("My class"))
    {
        builder.AppendLine("class MyClass { }");
    }

    return builder.ToString();
}