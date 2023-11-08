namespace GraphQL.Api.Books
{
    public class Query
    {
        public Livro ObterLivro(int id)
        {
            // Simule a obtenção de dados de um banco de dados
            return new Livro { Id = id, Titulo = "O Livro da Selva", Autor = "Rudyard Kipling" };
        }
    }
}