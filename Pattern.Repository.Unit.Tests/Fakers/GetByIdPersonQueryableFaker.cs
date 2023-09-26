namespace Pattern.Repository.Unit.Tests.Fakers
{
    public class GetByIdPersonQueryableFaker : TheoryData<Person, long>
    {
        public GetByIdPersonQueryableFaker()
        {
            Add(new Person { Id = 1 }, 1);
        }
    }
}