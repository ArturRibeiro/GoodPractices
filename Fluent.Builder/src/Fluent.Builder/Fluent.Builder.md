# Benefícios do Fluent Builder Pattern

O Fluent Builder Pattern é um design pattern amplamente utilizado em programação para construir objetos complexos de maneira sequencial e intuitiva. Aqui estão alguns de seus principais benefícios:

## 1. Melhoria na Legibilidade do Código

- O Fluent Builder torna o código mais legível, pois permite configurar objetos passo a passo usando métodos que descrevem claramente cada configuração.
- A fluidez com que o código é escrito e lido facilita o entendimento do processo de construção do objeto.

## 2. Encadeamento de Métodos

- Métodos de construção podem ser encadeados em uma única instrução, graças ao retorno do próprio objeto (`this`) em cada método, permitindo uma sintaxe fluente e concisa.

## 3. Separação da Construção da Representação

- Separa a lógica de construção de um objeto da sua representação, permitindo a criação de diferentes representações do mesmo objeto sem alterar o código do construtor.

## 4. Imutabilidade dos Objetos

- Uma vez que o objeto é construído, ele pode ser feito imutável (se desejado) sem a necessidade de um construtor complexo, aumentando a segurança e a previsibilidade do código.

## 5. Flexibilidade

- Facilita a adição de novos parâmetros ao objeto sem aumentar a complexidade do construtor ou exigir múltiplos construtores com diferentes assinaturas.

## 6. Código Reutilizável e Organizado

- A lógica de construção fica encapsulada dentro do builder, promovendo a reutilização do código e mantendo o código do cliente limpo e organizado.

## Conclusão

Adotar o Fluent Builder Pattern em projetos de software pode trazer claridade e eficiência significativas no processo de criação de objetos complexos. Além de melhorar a legibilidade do código, ele oferece uma abordagem flexível e robusta para o design de software.

## Exemplo

```plaintext
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
                moat.AddDepth(p2["MoatDepth"])
                    .AddWidth(p2["MoatWidth"])
                    .AddThereAreFish(p3["MoatThereAreFish"]))
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
```