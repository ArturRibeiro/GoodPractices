namespace Fluent.Builder.Imp;

public class Tower
{
    public int Height { get; private set; }
    public string Material { get; private set; }
    public string Shape { get; private set; }
    public int NumberOfWindows { get; private set; }
    public bool HasTerrace { get; private set; }

    public Tower AddHeight(int value)
    {
        this.Height = value;
        return this;
    }

    public Tower AddMaterial(string value)
    {
        this.Material = value;
        return this;
    }

    public Tower AddNumberOfWindows(int value)
    {
        this.NumberOfWindows = value;
        return this;
    }

    public Tower AddShape(string value)
    {
        this.Shape = value;
        return this;
    }

    public Tower AddHasTerrace(bool value)
    {
        this.HasTerrace = value;
        return this;
    }
}