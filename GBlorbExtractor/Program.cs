using Mono.Options;
using Casasoft.IF.GBlorbLib;

bool ShouldShowHelp = false;
bool ShouldList = false;
string ExtractDir = string.Empty;

OptionSet p = new OptionSet()
{
    { "h|?|help", "Show this help", v => ShouldShowHelp = v != null },
    { "l|list", "List the content of the archive", v => ShouldList = v != null },
    { "x|extract=", "Extract the resources in the specified dir", o => ExtractDir = o },
};

List<string> FilesList = p.Parse(args);

if (ShouldShowHelp || FilesList.Count == 0)
{
    ShowHelp();
    return;
}

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
#endregion