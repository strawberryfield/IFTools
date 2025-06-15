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

/// <remarks>
/// ResMap is a command-line tool for extracting resources and generating resource maps from GBlorb files,
/// which are archives used in interactive fiction (IF) games.
/// The resource map is required from the Quixe interpreter to properly display images.
/// </remarks>
 
using Mono.Options;
using Casasoft.IF.GBlorbLib;

#region main
bool ShouldShowHelp = false;
bool ShouldSuppressBanner = false;
bool ShouldList = false;
string ExtractDir = string.Empty;
string ProjectName = string.Empty;

OptionSet p = new OptionSet()
{
    { "q|quiet", "Suppress banner print", v => ShouldSuppressBanner = v != null },
    { "h|?|help", "Show this help", v => ShouldShowHelp = v != null },
    { "l|list", "List the content of the archive", v => ShouldList = v != null },
    { "x|extract=", "Extract the resources in the specified dir", o => ExtractDir = o },
    { "p|project=", "Manage the resources of the specified project", o => ProjectName = o },
};

List<string> FilesList = p.Parse(args);

if (ShouldShowHelp || (FilesList.Count == 0 && string.IsNullOrWhiteSpace(ProjectName)))
{
    ShowBanner();
    ShowHelp();
    return;
}

if (!ShouldSuppressBanner)
    ShowBanner();

string file = string.Empty;
if (!string.IsNullOrWhiteSpace(ProjectName))
{
    ExtractDir = $"{ProjectName}.materials/Release";
    file = $"{ExtractDir}/{Path.GetFileName(ProjectName)}.gblorb";
}
else
{
    file = FilesList[0];
}
GBlorb Blorb = new(file);

if (string.IsNullOrWhiteSpace(ExtractDir))
{
    ExtractDir = Path.GetDirectoryName(file) ?? string.Empty;
}

Blorb.ExportResourceMap(ExtractDir);
#endregion

#region Procedures
void ShowHelp()
{
    Console.WriteLine("Usage: ResMap [OPTIONS] [FILE]");
    Console.WriteLine("Extracts the resources and creates a map from a GBlorb file.");
    Console.WriteLine();
    Console.WriteLine("Options:");
    p.WriteOptionDescriptions(Console.Out);
}

void ShowBanner() => Console.WriteLine("Casasoft ResMap v1.0\n(c) 2025 Roberto Ceccarelli - Casasoft\n");
#endregion