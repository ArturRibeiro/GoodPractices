namespace Pattern.Repository.Unit.Tests.Fakers
{
    public class GetAllPersonFaker : TheoryData<IQueryable<Person>>
    {
        public GetAllPersonFaker()
        {
            Add(new List<Person>
            {
                new Person(),
                new Person(),
                new Person(),
            }.AsQueryable());
        }
    }
}