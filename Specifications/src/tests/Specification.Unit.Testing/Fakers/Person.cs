namespace Specification.Unit.Testing.Fakers;

public class Person
{
    public Person() => this.Tags = new[] { "important", "important1", "important2" };
    public IEnumerable<string> Tags { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public short Age { get; set; }
    
    public static class Data
    {
        public static readonly Person AmeliaEarhart = new() { Name = "Amelia Earhart", Email = "Amelia.Earhart@domain.com", Age = 35 };
        public static readonly Person AlbertEinstein = new() { Name = "Albert Einstein", Email = "Albert.Einstein@domain.com", Age = 17 };
        public static readonly Person MarieCurie = new() { Name = "Marie Curie", Email = "Marie.Curie@domain.com", Age = 15 };
        public static readonly Person LeonardoDaVinci = new() { Name = "Leonardo da Vinci", Email = "Leonardo.da@domain.com", Age = 13 };
        public static readonly Person MarilynMonroe = new() { Name = "Marilyn Monroe", Email = "Marilyn.Monroe@domain.com", Age = 10 };
        public static readonly Person NelsonMandela = new() { Name = "Nelson Mandela", Email = "Nelson.Mandela@domain.com", Age = 12 };
        public static readonly Person AdaLovelace = new() { Name = "Ada Lovelace", Email = "Ada.Lovelace@domain.com", Age = 14 };
        public static readonly Person CharlesDarwin = new() { Name = "Charles Darwin", Email = "Charles.Darwin@domain.com", Age = 13 };
        public static readonly Person OprahWinfrey = new() { Name = "Oprah Winfrey", Email = "Oprah.Winfrey@domain.com", Age = 15 };
        public static readonly Person WinstonChurchill = new() { Name = "Winston Churchill", Email = "Winston.Churchill@domain.com", Age = 11 };

        public static List<Person> All()
        {
            return new List<Person>
                {
                    AmeliaEarhart, AlbertEinstein, MarieCurie, LeonardoDaVinci, MarilynMonroe,
                    NelsonMandela, AdaLovelace, CharlesDarwin, OprahWinfrey, WinstonChurchill
                }.OrderBy(x => x.Name)
                .ToList();
        }
    }
}