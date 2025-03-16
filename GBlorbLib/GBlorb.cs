using System.Text;

namespace Casasoft.IF.GBlorbLib;

/// <summary>
/// Gblorb file format
/// <see cref="https://github.com/iftechfoundation/ifarchive-if-specs/blob/main/Blorb-Spec.md"/>
/// </summary>
public class GBlorb
{
    #region Properties
    protected byte[] Data;

    public Header Header;
    public ResourceIndex ResourceIndex;
    public List<IChunk> Chunks;
    #endregion

    #region Constructors    
    public GBlorb()
    {
        Header = new();
        ResourceIndex = new();
        Chunks = new();
        Data = Array.Empty<byte>();
    }

    public GBlorb(string filename)
    {
        Data = File.ReadAllBytes(filename);
        Header = new(Data);
        ResourceIndex = new(Data, 12);
        Chunks = new();

        for (int offset = 12 + 8 + ResourceIndex.Length; offset < Data.Length;)
        {
            IChunk chunk = ChunkFactory.CreateChunk(Data, offset);
            Chunks.Add(chunk);
            offset += 8 + chunk.Length;
        }
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(Header.ToString());
        sb.AppendLine(ResourceIndex.ToString());
        foreach (IChunk chunk in Chunks)
        {
            sb.AppendLine(chunk.ToString());
        }
        return sb.ToString();
    }

    public void Export(string path)
    {
        foreach (IChunk chunk in Chunks)
        {
            if (chunk.Address > 0)
            {
                string filename = string.Empty;
                ResourceEntry? entry = ResourceIndex.ResourcesEntries.FirstOrDefault(e => e.Start == chunk.Address);
                if (entry != null)
                {
                    filename = Path.Combine(path, $"{entry.Type}_{entry.Number}{chunk.FileExtension()}");
                    chunk.Export(filename);
                }
            }
        }

        IChunk? IFmd = Chunks.FirstOrDefault(c => c.Name == "IFmd");
        if (IFmd != null)
        {
            IFmd.Export(Path.Combine(path, "IFmd.xml"));
        }
    }
    #endregion
}
