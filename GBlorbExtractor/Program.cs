// copyright (c) 2025 Roberto Ceccarelli - Casasoft
// http://strawberryfield.altervista.org
//
// This file is part of Casasoft IF Tools
// https://github.com/strawberryfield/IFTools
//
// Casasoft IF Tools is free software:
// you can redistribute it and/or modify it
// under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Casasoft IF Tools is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY

// <summary
// GBlorbExtractor is a command-line utility for extracting and listing resources from GBlorb files,
// which are archives used in interactive fiction (IF) games.
// The tool allows users to view the contents of a GBlorb file or extract all embedded resources
// (such as images, sounds, and metadata) to a specified directory.
// </summary>   

using Mono.Options;
using Casasoft.IF.GBlorbLib;

#region main
bool ShouldShowHelp = false;
bool ShouldSuppressBanner = false;
bool ShouldList = false;
string ExtractDir = string.Empty;

OptionSet p = new OptionSet()
{
    { "q|quiet", "Suppress banner print", v => ShouldSuppressBanner = v != null },
    { "h|?|help", "Show this help", v => ShouldShowHelp = v != null },
    { "l|list", "List the content of the archive", v => ShouldList = v != null },
    { "x|extract=", "Extract the resources in the specified dir", o => ExtractDir = o },
};

List<string> FilesList = ExpandWildcards(p.Parse(args));

if (ShouldShowHelp || FilesList.Count == 0)
{
    ShowBanner();
    ShowHelp();
    return;
}

if (!ShouldSuppressBanner)
    ShowBanner();

foreach (string file in FilesList)
{
    GBlorb Blorb = new(file);

    if (ShouldList)
    {
        Console.WriteLine($"Content of: {file}");
        Console.WriteLine(new string('-', file.Length+12));
        Console.WriteLine(Blorb.ToString());
    }

    if (!string.IsNullOrWhiteSpace(ExtractDir))
    {
        Console.WriteLine($"Extracting: {file}");
        string name = Path.GetFileNameWithoutExtension(file);
        string path = Path.Combine(ExtractDir, name);
        Directory.CreateDirectory(path);
        Blorb.Export(path);
    }
}
#endregion

#region Procedures
void ShowHelp()
{
    Console.WriteLine("Usage: GBlorbExtractor [OPTIONS] FILES");
    Console.WriteLine("Extracts the resources from a GBlorb file.");
    Console.WriteLine();
    Console.WriteLine("Options:");
    p.WriteOptionDescriptions(Console.Out);
}

void ShowBanner() => Console.WriteLine("Casasoft GBlorbExtractor v1.0\n(c) 2025 Roberto Ceccarelli - Casasoft\n");

/// <summary>
/// Expands wildcard patterns in file paths to match actual files in the directory.
/// This is necessary because the Windows shell does not automatically expand wildcards.
/// For each file path in the input list, if it contains wildcard characters ('*' or '?'),
/// it retrieves all matching files from the specified directory. Otherwise, it adds the
/// file path directly to the result list.
/// </summary>
/// <param name="FilesList">A list of file paths, which may include wildcard patterns.</param>
/// <returns>A list of file paths with wildcards expanded to match actual files.</returns>
List<string> ExpandWildcards(List<string> FilesList)
{
    List<string> files = new();
    foreach (string filename in FilesList)
    {
        if (filename.Contains('*') || filename.Contains('?'))
        {
            string? path = Path.GetDirectoryName(filename);
            if (string.IsNullOrWhiteSpace(path))
            {
                path = ".";
            }
            files.AddRange(Directory.GetFiles(path, Path.GetFileName(filename)).ToList());
        }
        else
        {
            files.Add(filename);
        }
    }
    return files;
}
#endregion