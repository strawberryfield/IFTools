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

if (ShouldShowHelp || FilesList.Count == 0 || string.IsNullOrWhiteSpace(OutputName))
{
    ShowBanner();
    ShowHelp();
    return;
}

if (!ShouldSuppressBanner)
    ShowBanner();

GBlorb Blorb = new(FilesList[0]);

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
void ShowHelp()
{
    Console.WriteLine("Usage: GBlorbEd [OPTIONS] FILE -o OUTFILE");
    Console.WriteLine("Edits components of a GBlorb file.");
    Console.WriteLine();
    Console.WriteLine("Options:");
    p.WriteOptionDescriptions(Console.Out);
}

void ShowBanner() => Console.WriteLine("Casasoft GBlorb command line editor v1.0\n(c) 2025 Roberto Ceccarelli - Casasoft\n");
#endregion