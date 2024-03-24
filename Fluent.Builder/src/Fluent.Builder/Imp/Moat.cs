namespace Fluent.Builder.Imp;

public class Moat
{
    public int Width { get; private set; }
    public int Depth { get; private set; }
    public bool ThereAreFish { get; private set; }

    public Moat AddWidth(int value)
    {
        this.Width = value;
        return this;
    }

    public Moat AddDepth(int value)
    {
        this.Depth = value;
        return this;
    }

    public Moat AddThereAreFish(bool value)
    {
        this.ThereAreFish = value;
        return this;
    }
}