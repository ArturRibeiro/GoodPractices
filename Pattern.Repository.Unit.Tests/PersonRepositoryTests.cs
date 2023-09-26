namespace Pattern.Repository.Unit.Tests
{
    public class PersonRepositoryTests
    {
        private Mock<DbSet<Person>> mockSet = new();
        private Mock<MyDbContext> mockContext = new();

        [Theory]
        [ClassData(typeof(GetAllPersonFaker))]
        public async Task GetAll(IQueryable<Person> data)
        {
            // Arrange

            // Stub's
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            mockContext.Setup(x => x.Set<Person>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Persons).Returns(mockSet.Object);

            var repository = new PersonRepository(mockContext.Object);

            // Act
            var all = repository.GetAll();

            // Assert's
            all.Should().NotBeNull();
            all.Should().HaveCount(3);
        }

        [Theory]
        [ClassData(typeof(GetByIdPersonQueryableFaker))]
        public async Task GetById(Person data, long id)
        {
            // Arrange

            // Stub's
            mockSet.Setup(x => x.Find(id)).Returns(data);
            mockContext.Setup(x => x.Set<Person>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Persons).Returns(mockSet.Object);

            var repository = new PersonRepository(mockContext.Object);

            // Act
            var person = repository.GetById(id);

            // Assert's
            person.Should().NotBeNull();
            person.Id.Should().Be(id);
        }
        
        [Theory]
        [ClassData(typeof(InsertPersonFaker))]
        public async Task Insert(Person person)
        {
            // Arrange

            // Stub's
            mockSet.Setup(x => x.Add(person));
            mockContext.Setup(x => x.Set<Person>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Persons).Returns(mockSet.Object);

            var repository = new PersonRepository(mockContext.Object);

            // Act
            repository.Insert(person);

            // Assert's
            mockSet.Verify(x => x.Add(person), Times.Once);
        }
        
        [Theory]
        [ClassData(typeof(UpdatePersonFaker))]
        public async Task Update(Person person)
        {
            // Arrange

            // Stub's
            mockSet.Setup(x => x.Update(person));
            mockContext.Setup(x => x.Set<Person>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Persons).Returns(mockSet.Object);
            var mockStateManager = new Mock<IStateManager>();
            var runtimeEntityType = new RuntimeEntityType("T", typeof(Person), false, null, null, null, ChangeTrackingStrategy.Snapshot, null, false, null);
            var internalEntityEntry = new InternalEntityEntry(mockStateManager.Object, runtimeEntityType, person);
            var entityEntry = new Mock<EntityEntry<Person>>(internalEntityEntry);
            
            mockContext.Setup(x => x.Entry(person)).Returns(entityEntry.Object);

            var repository = new PersonRepository(mockContext.Object);

            // Act
            repository.Update(person);

            // Assert's
            mockSet.Verify(x => x.Attach(person), Times.Once);
            mockContext.Verify(x => x.Entry(person), Times.Once);
        }
        
        [Theory]
        [ClassData(typeof(DeletePersonFaker))]
        public async Task Delete(Person person)
        {
            // Arrange

            // Stub's
            mockSet.Setup(x => x.Add(person));
            mockContext.Setup(x => x.Set<Person>()).Returns(mockSet.Object);
            mockContext.Setup(c => c.Persons).Returns(mockSet.Object);

            var repository = new PersonRepository(mockContext.Object);

            // Act
            repository.Delete(person);

            // Assert's
            mockSet.Verify(x => x.Remove(person), Times.Once);
        }
        
        [Fact]
        public async Task Save()
        {
            // Arrange

            // Stub's
            mockContext.Setup(c => c.SaveChanges()).Returns(1);

            var repository = new PersonRepository(mockContext.Object);

            // Act
            repository.Save();

            // Assert's
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}