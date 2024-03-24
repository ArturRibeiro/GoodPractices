namespace Fluent.Builder.Unit.Testing.Fakers;

public class CastleFaker : TheoryData<IDictionary<string, string>
    , IDictionary<string, int>
    , IDictionary<string, bool>>
{
    public CastleFaker()
    {
        var p1 = new Dictionary<string, string>();
        p1.Add("CastleName", "Castelo Coradelli em Joinville");
        p1.Add("CastleMaterial", "Granite");
        p1.Add("TowerMaterial", "Granite");
        p1.Add("TowerShape", "Medieval");
        
        var p2 = new Dictionary<string, int>();
        p2.Add("CastleHeight", 20);
        p2.Add("MoatDepth", 5);
        p2.Add("MoatWidth", 1);
        p2.Add("CastleNumberOfTowers", 6);
        p2.Add("TowerHeight", 25);
        p2.Add("TowerNumberOfWindows", 30);
        
        var p3 = new Dictionary<string, bool>();
        p3.Add("MoatThereAreFish", true);
        p3.Add("TowerHasTerrace", false);
        
        Add(p1, p2, p3);
    }
}