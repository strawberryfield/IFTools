using System.Text;

namespace Casasoft.IF.GBlorbLib;

public class ResourceIndex : Chunk
{
    #region Properties
    public Int32 TotalResourcesCount;
    public List<ResourceEntry> ResourcesEntries;
    #endregion

    #region Constructors
    public ResourceIndex() : base("RIdx")
    {
        TotalResourcesCount = 0;
        ResourcesEntries = new();
    }

    public ResourceIndex(byte[] data, int offset) : base(data, offset)
    {
        TotalResourcesCount = Helpers.ReadInt32(data, offset + 8);

        Int32 currentOffset = offset + 12;
        ResourcesEntries = new();
        for (Int32 i = 0; i < TotalResourcesCount; i++)
        {
            ResourcesEntries.Add(new ResourceEntry(data, currentOffset));
            currentOffset += 12;
        }
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        foreach (ResourceEntry entry in ResourcesEntries)
        {
            sb.AppendLine(entry.ToString());
        }
        return sb.ToString();
    }

    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteInt32(data, offset + 8, TotalResourcesCount);
        Int32 currentOffset = offset + 12;
        foreach (ResourceEntry entry in ResourcesEntries)
        {
            entry.Write(data, currentOffset);
            currentOffset += 12;
        }
    }
    #endregion
}
