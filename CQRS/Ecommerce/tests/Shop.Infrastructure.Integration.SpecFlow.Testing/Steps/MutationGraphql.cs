namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

public class MutationGraphql
{
    
    // var queryObject = new
    // {
    //     query = @"mutation {" + query.Values.First() + "}"
    //     //, variables = new { where = new { userId = userId } }//you can add your where cluase here.
    // };


    
    private string TEMPLATE =
        @"#NAME#(input: { #VALUE# }) {
                            #RESULT#
                         }";

    public Dictionary<string, object> PropertyInputValues = new();
    public string GraphqlResultValues { get; private set; }

    public string Name { get; }

    public string Query { get; private set; }

    private MutationGraphql(string name) => this.Name = name;

    public MutationGraphql AddGraphQLInput(string propertyName, object value)
    {
        PropertyInputValues.Add(propertyName, value);
        return this;
    }

    public static MutationGraphql Instance(string name) =>
        new(name);

    public MutationGraphql Builder()
    {
        //var value = PropertyInputValues.Aggregate(string.Empty, (current, d) => current + $"{d.Key} : {d.Value}");

        var result = this.TEMPLATE
            .Replace("#NAME#", this.Name)
            .Replace("#VALUE#", this.Query)
            .Replace("#RESULT#", GraphqlResultValues)
            ;

        var queryObject = new { query = "mutation {" + result +"}" };
        
        this.Query = JsonConvert.SerializeObject(queryObject);
        
        return this;
    }

    public MutationGraphql AddGraphQLResult(string graphqlResultValues)
    {
        GraphqlResultValues = graphqlResultValues;
        return this;
    }

    public MutationGraphql AddQuery(string query)
    {
        this.Query = query;
        return this;
    }
}