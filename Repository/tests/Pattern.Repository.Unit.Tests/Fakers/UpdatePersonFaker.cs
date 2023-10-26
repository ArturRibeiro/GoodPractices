namespace Pattern.Repository.Unit.Tests.Fakers
{
    public class UpdatePersonFaker : TheoryData<Person>
    {
        public UpdatePersonFaker()
        {
            Add(new Person { Id = 1 });
        }
    }
}