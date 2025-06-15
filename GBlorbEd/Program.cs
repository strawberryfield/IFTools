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


/// <summary>
/// GBlorbEd is a command-line editor for GBlorb files, which are used to package resources for interactive fiction (IF) games.
/// This tool allows users to modify metadata such as author, copyright, annotations, and frontispiece image references
/// within a GBlorb file.
/// It supports reading an existing GBlorb file, updating its components, and writing the changes to a new output file.
/// </summary>

using Mono.Options;
using Casasoft.IF.GBlorbLib;

#region main
bool ShouldShowHelp = false;
bool ShouldSuppressBanner = false;
string OutputName = string.Empty;

string AuthorName = string.Empty;
string Copyright = string.Empty;
string Annotations = string.Empty;
string sFrontispice = string.Empty;
Int32 Frontispice = 0;

OptionSet p = new()
{
    { "q|quiet", "Suppress banner print", v => ShouldSuppressBanner = v != null },
    { "h|?|help", "Show this help", v => ShouldShowHelp = v != null },
    { "o|output=", "Output filename", o => OutputName = o },
    { "f|frontispice=", "Frontispice resource number", f => sFrontispice = f },
    { "a|author=", "Author name", o => AuthorName = o },
    { "c|copyright=", "Copyright notice", o => Copyright = o },
    { "r|remarks=|annotations=", "Annotations", o => Annotations = o },
};

List<string> FilesList = p.Parse(args);

if (ShouldShowHelp || string.IsNullOrWhiteSpace(OutputName))
{
    ShowBanner();
    ShowHelp();
    return;
}

if (!ShouldSuppressBanner)
    ShowBanner();

GBlorb Blorb = new();
if (FilesList.Count > 0)
{
    Blorb = new(FilesList[0]);
}

if (!string.IsNullOrWhiteSpace(sFrontispice) && Int32.TryParse(sFrontispice, out Frontispice))
{
    Blorb.AddUpdateFrontispiceChunk(Frontispice);
}

if (!string.IsNullOrWhiteSpace(AuthorName))
{
    Blorb.AddUpdateOptionalTextChunk("AUTH", AuthorName);
}

if (!string.IsNullOrWhiteSpace(Copyright))
{
    Blorb.AddUpdateOptionalTextChunk("(c) ", Copyright);
}

if (!string.IsNullOrWhiteSpace(Annotations))
{
    Blorb.AddUpdateOptionalTextChunk("ANNO", Annotations);
}

Blorb.Write(OutputName);
#endregion

#region Procedures
/// <summary>
/// Shows the help message.
/// </summary>
void ShowHelp()
{
    Console.WriteLine("Usage: GBlorbEd [OPTIONS] [FILE] -o OUTFILE");
    Console.WriteLine("Edits components of a GBlorb file.");
    Console.WriteLine();
    Console.WriteLine("Options:");
    p.WriteOptionDescriptions(Console.Out);
}

/// <summary>
/// Shows the banner message.
/// </summary>
void ShowBanner() => Console.WriteLine("Casasoft GBlorb command line editor v1.0\n(c) 2025 Roberto Ceccarelli - Casasoft\n");
#endregion