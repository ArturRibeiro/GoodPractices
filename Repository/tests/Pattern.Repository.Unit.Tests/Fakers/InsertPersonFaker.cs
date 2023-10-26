namespace Pattern.Repository.Unit.Tests.Fakers
{
    public class InsertPersonFaker : TheoryData<Person>
    {
        public InsertPersonFaker()
        {
            Add(new Person { Id = 1 });
        }
    }
}