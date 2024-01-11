# Intenção

O padrão Specification tem como intenção representar condições lógicas em um formato reutilizável, permitindo a composição flexível de regras de negócios complexas.

# Motivação

Muitas vezes, em sistemas de software, é necessário expressar condições lógicas complexas que envolvem múltiplos critérios. O padrão Specification busca encapsular esses critérios em objetos independentes e reutilizáveis.

# Estrutura

O padrão Specification geralmente envolve as seguintes partes:
Specification (Especificação): Uma interface ou classe abstrata que declara um método como IsSatisfiedBy para verificar se um objeto atende a uma condição específica.

```plaintext
public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate);
}
```

```plaintext
public class AgeSpecification : ISpecification<Person>
{
    // Implementação específica para verificar a idade de uma pessoa
    // ...

    public bool IsSatisfiedBy(Person candidate)
    {
        // Lógica para verificar se a idade atende à condição
        // ...
    }
}
```

```plaintext
// Implementação concreta de Specification para verificar o nome de uma pessoa
public class NameSpecification : ISpecification<Person>
{
    // Implementação específica para verificar o nome de uma pessoa
    public bool IsSatisfiedBy(Person candidate)
    {
        // Lógica para verificar se o nome atende à condição
        // ...
    }
}
```

```plaintext
public class AndSpecification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _spec1;
    private readonly ISpecification<T> _spec2;

    public AndSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
    {
        _spec1 = spec1;
        _spec2 = spec2;
    }

    public bool IsSatisfiedBy(T candidate)
    {
        return _spec1.IsSatisfiedBy(candidate) && _spec2.IsSatisfiedBy(candidate);
    }
}
```

```plaintext
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

```plaintext
class Program
{
    static void Main()
    {
        ISpecification<Person> ageSpec = new AgeSpecification();
        ISpecification<Person> nameSpec = new NameSpecification();

        ISpecification<Person> combinedSpec = new AndSpecification<Person>(ageSpec, nameSpec);

        // Verificando se uma pessoa atende à condição combinada
        Person person = new Person { Name = "John Doe", Age = 25 };
        bool isSatisfied = combinedSpec.IsSatisfiedBy(person);
    }
}
```