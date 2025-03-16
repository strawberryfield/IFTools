namespace Casasoft.IF.GBlorbLib;

public class Header : Chunk
{
    #region Properties
    public String Type;
    #endregion

    #region Constructors
    public Header() : base("FORM")
    {
        Type = "IFRS";
    }

    public Header(byte[] data) : base(data, 0)
    {
        Type = Helpers.ReadString(data, 8, 4);
    }
    #endregion

    #region Methods
    public override void Write(byte[] data, int offset)
    {
        base.Write(data, offset);
        Helpers.WriteString(data, offset + 8, Type);
    }
    #endregion
}
