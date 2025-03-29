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

using Mono.Options;
using Casasoft.IF.GBlorbLib;

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

List<string> FilesList = p.Parse(args);

if (ShouldShowHelp || FilesList.Count == 0)
{
    ShowBanner();
    ShowHelp();
    return;
}

if (!ShouldSuppressBanner)
    ShowBanner();   

GBlorb Blorb = new(FilesList[0]);

if (ShouldList)
{
    Console.WriteLine(Blorb.ToString());
    return;
}

if (!string.IsNullOrEmpty(ExtractDir))
{
    Directory.CreateDirectory(ExtractDir);
    Blorb.Export(ExtractDir);
    return;
}

#region Procedures
void ShowHelp()
{
    Console.WriteLine("Usage: GBlorbExtractor [OPTIONS] FILE");
    Console.WriteLine("Extracts the resources from a GBlorb file.");
    Console.WriteLine();
    Console.WriteLine("Options:");
    p.WriteOptionDescriptions(Console.Out);
}

void ShowBanner() => Console.WriteLine("Casasoft GBlorbExtractor v1.0\n(c) 2025 Roberto Ceccarelli - Casasoft\n");
#endregion