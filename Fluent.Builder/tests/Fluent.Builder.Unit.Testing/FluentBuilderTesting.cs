using Fluent.Builder.Unit.Testing.Fakers;

namespace Fluent.Builder.Unit.Testing;

public class FluentBuilderTesting
{
    [Theory]
    [ClassData(typeof(CastleFaker))]
    public async Task CreateCastleOfLego(IDictionary<string, string> p1
        , IDictionary<string, int> p2
        , IDictionary<string, bool> p3)
    {
        //arrange
        var castleBuilder = new Castle.Builder()
            .Named(p1["CastleName"])
            .WithMaterial(p1["CastleMaterial"])
            .WithWallHeight(p2["CastleHeight"])
            .WithMoat(moat =>
                moat.AddDepth(p2["MoatDepth"]).AddWidth(p2["MoatWidth"]).AddThereAreFish(p3["MoatThereAreFish"]))
            .NumberOfTowers(number: p2["CastleNumberOfTowers"], towerDetail =>
                towerDetail.AddHeight(p2["TowerHeight"])
                    .AddMaterial(p1["TowerMaterial"])
                    .AddShape(p1["TowerShape"])
                    .AddNumberOfWindows(p2["TowerNumberOfWindows"])
                    .AddHasTerrace(p3["TowerHasTerrace"]));

        //act
        var castle = castleBuilder.Build();

        //assert's
        castle.Should().NotBeNull();
        castle.TowerCount.Should().Be(p2["CastleNumberOfTowers"]);
        castle.Material.Should().Be(p1["CastleMaterial"]);

        castle.Moat.Should().NotBeNull();
        castle.Moat.ThereAreFish.Should().Be(p3["MoatThereAreFish"]);
        castle.Moat.Depth.Should().Be(p2["MoatDepth"]);
        castle.Moat.Width.Should().Be(p2["MoatWidth"]);

        castle.WallHeight.Should().Be(p2["CastleHeight"]);
        castle.CastleName.Should().Be(p1["CastleName"]);
        castle.Towers.Should().HaveCount(p2["CastleNumberOfTowers"]);

        castle.Towers.ToList()
            .ForEach(x =>
            {
                x.Height.Should().Be(p2["TowerHeight"]);
                x.Material.Should().Be(p1["TowerMaterial"]);
                x.Shape.Should().Be(p1["TowerShape"]);
                x.NumberOfWindows.Should().Be(p2["TowerNumberOfWindows"]);
                x.HasTerrace.Should().Be(p3["TowerHasTerrace"]);
            });
    }
}