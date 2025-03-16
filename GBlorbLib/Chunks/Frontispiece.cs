namespace Casasoft.IF.GBlorbLib;

public class Frontispiece : Chunk
{
    #region Properties
    public Int32 ResourceNumber { get; set; }
    #endregion

    #region Constructors
    public Frontispiece() : this("Fspc")
    {
    }

    public Frontispiece(string name) : base(name)
    {
    }

    public Frontispiece(byte[] data, int offset) : base(data, offset)
    {
        ResourceNumber = Helpers.ReadInt32(data, offset + 8);
    }
    #endregion

    #region Methods
    public override string ToString() => $"{base.ToString()}\tRes Id:{ResourceNumber,3}";

    public override void Export(string filename) => File.WriteAllText(filename, $"{ResourceNumber}");

    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteInt32(data, offset + 8, ResourceNumber);
    }
    #endregion
}
