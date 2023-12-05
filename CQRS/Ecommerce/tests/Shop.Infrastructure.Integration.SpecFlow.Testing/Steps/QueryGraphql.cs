namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Steps;

public class QueryGraphql
{
    //public static Dictionary<string, string> Dummy = new() { { "dummy", "id " } };

    private string _fields;

    private QueryGraphql(string queryName, string fields)
    {
        this.Name = queryName;
        this._fields = fields;
    }

    public string Name { get; private set; }

    public string Query { get; private set; }

    public static QueryGraphql Instance(string queryName, string fields) => new(queryName, fields);

    public QueryGraphql Builder()
    {
        var queryObject = new
        {
            query = "query { " + this.Name + " { " + this._fields + " }}"
            //, variables = new { where = new { userId = userId } }//you can add your where cluase here.
        };
        
        this.Query = JsonConvert.SerializeObject(queryObject);
        
        return this;
    }
}

public record PaymentInformation(string CreditCardNumber, string CardValidityData, string CVV);

public record DeliveryInformation(string Street, string City, string State, string Country, string ZipCode);