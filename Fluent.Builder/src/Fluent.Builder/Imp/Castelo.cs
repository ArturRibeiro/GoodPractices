using System.Collections.Immutable;

namespace Fluent.Builder.Imp;

public class Castle
{
    internal List<Tower> _towers = new();
    
    public IEnumerable<Tower> Towers => _towers.AsReadOnly();
    
    public int TowerCount { get; private set; }
    public string Material { get; private set; }
    public Moat Moat { get; private set; }
    public int WallHeight { get; private set; }
    public string CastleName { get; private set; }

    private Castle() {}

    // Classe interna Builder
    public class Builder
    {
        private Castle _castle = new();
       
        public Builder NumberOfTowers(int number, Action<Tower> atc)
        {
            _castle.TowerCount = number;
            for (var i = 0; i < number; i++) WithTowers(atc);
            return this;
        }

        public Builder WithMaterial(string material)
        {
            _castle.Material = material;
            return this;
        }

        public Builder WithMoat(Action<Moat> act)
        {
            var moat = new Moat();
            act(moat);
            _castle.Moat = moat;
            return this;
        }

        public Builder WithWallHeight(int height)
        {
            _castle.WallHeight = height;
            return this;
        }

        public Builder Named(string name)
        {
            _castle.CastleName = name;
            return this;
        }

        public Castle Build() => _castle;

        private void WithTowers(Action<Tower> atc)
        {
            var tower = new Tower();
            atc(tower);
            _castle._towers.Add(tower);
        }
    }
}