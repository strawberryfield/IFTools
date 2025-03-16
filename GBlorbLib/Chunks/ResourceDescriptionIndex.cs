using System.Text;

namespace Casasoft.IF.GBlorbLib;

public class ResourceDescriptionIndex : Chunk
{
    #region Properties
    public Int32 TotalResourcesCount;
    public List<ResourceDescriptionEntry> DescriptionsEntries;
    #endregion

    #region Constructors
    public ResourceDescriptionIndex() : base("RDes")
    {
        TotalResourcesCount = 0;
        DescriptionsEntries = new();
    }

    public ResourceDescriptionIndex(byte[] data, int offset) : base(data, offset)
    {
        TotalResourcesCount = Helpers.ReadInt32(data, offset + 8);

        Int32 currentOffset = offset + 12;
        DescriptionsEntries = new();
        for (Int32 i = 0; i < TotalResourcesCount; i++)
        {
            ResourceDescriptionEntry entry = new(data, currentOffset);
            DescriptionsEntries.Add(entry);
            currentOffset += 12 + entry.Length;
        }
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        foreach (ResourceDescriptionEntry entry in DescriptionsEntries)
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
        foreach (ResourceDescriptionEntry entry in DescriptionsEntries)
        {
            entry.Write(data, currentOffset);
            currentOffset += 12 + entry.Length;
        }
    }
    #endregion

}
