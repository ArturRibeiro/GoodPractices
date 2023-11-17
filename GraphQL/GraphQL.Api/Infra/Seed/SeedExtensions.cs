namespace GraphQL.Api.Infra.Seed;

public static class SeedExtensions
{
    public static void Seed(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        var comments = Builder<Comment>
            .CreateListOfSize(5)
            .All()
                .With(c => c.Content = Faker.Lorem.Sentence())
                .With(c => c.CreationDate = DateTime.Now)
            .Build()
            .ToList();
        
        var posts = Builder<Post>
            .CreateListOfSize(4)
            .All()
            .With(p => p.Title = Faker.Lorem.Sentence())
            .With(p => p.Content = Faker.Lorem.Paragraph())
            .With(p => p.CreationDate = DateTime.Now)
            .TheFirst(1)
                .With(p => p.Comments = new[] { comments[0], comments[1] }.ToList())
            .TheNext(1)
                .With(p => p.Comments = new[] { comments[2] }.ToList())
            .TheNext(1)
                .With(p => p.Comments = new[] { comments[3] }.ToList())
            .TheNext(1)
                .With(p => p.Comments = new[] { comments[4] }.ToList())
            .Build()
            .ToList();
        
        var users = Builder<User>
            .CreateListOfSize(50)
            .All()
                .With(u => u.Name = Faker.Name.FullName())
                .With(u => u.Email = Faker.Internet.Email())
                .With(u => u.Password = Guid.NewGuid().ToString("d"))
            .TheFirst(1)
                .With(u => u.Name = "Artur Ribeiro")
                .With(u => u.Email = "artur.ribeiro@f22.com")
                .With(u => u.Posts = new[] { posts[0], posts[1] }.ToList())
            .TheNext(1)
                .With(u => u.Posts = new[] { posts[2], posts[3] }.ToList())
            .Build()
            .ToList();
        
        dbContext.Users.AddRange(users);
        (dbContext.SaveChanges() > 0).Should().BeTrue();
    }
}