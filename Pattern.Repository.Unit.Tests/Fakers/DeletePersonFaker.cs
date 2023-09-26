namespace Pattern.Repository.Unit.Tests.Fakers
{
    public class DeletePersonFaker : TheoryData<Person>
    {
        public DeletePersonFaker()
        {
            Add(new Person { Id = 1 });
        }
    }
}