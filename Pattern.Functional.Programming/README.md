### Proposito do pattern Either

O pattern **Either** é uma estrutura de dados que é frequentemente usada em linguagens de programação funcionais e em linguagens que não têm suporte nativo para tipos de retorno múltiplos, como C#. O propósito do **Either** é representar uma escolha entre dois tipos de valores, comuns em situações em que uma operação pode ter um resultado bem-sucedido ou falhar.

O propósito principal do **Either** é:

**Tratar Resultados com Dois Caminhos Possíveis:** Ele permite que você trate situações em que uma função ou operação pode retornar um valor bem-sucedido ou um erro de forma explícita, sem depender de exceções.

**Evitar Uso Excessivo de Exceções:** Ao usar **Either**, você pode evitar o uso excessivo de exceções para controlar o fluxo de um programa, o que pode ser mais eficiente e legível.

**Clareza no Código:** O uso de **Either** torna o código mais explícito, tornando claro que uma operação pode produzir diferentes resultados.

**Composição Funcional:** **Either** é útil em programação funcional para encadear operações, permitindo que você lide com o resultado de cada operação de forma eficiente, aplicando funções apenas aos valores bem-sucedidos e evitando a propagação desnecessária de erros.

Por exemplo, ao usar **Either**, você pode ter um código que se parece com isto:

ex: 1
```plaintext
Either<Exception, int> result = Divide(10, 5);
int finalResult = result.Match(
error => HandleError(error),
value => value * 2);
```
Neste exemplo, a função **Divide** retorna um **Either**, que pode conter um valor bem-sucedido (a divisão) ou um erro (exceção). O método **Match** permite lidar com ambos os casos de forma explícita.

Um outro exemplo mais elaborado.
```plaintext
        [Theory]
        [InlineData(1, 1, 1, 1, 3)]
        [InlineData(1, 2, 3, 4, 12)]
        [InlineData(24, 2, 58, 12, 141)]
        public void BindSuccess(int v1, int v2, int v3, int v4, int expected)
        {
            // Assert
            Func<int, Either<Exception, int>> Sum = arg => Try<int>.Cath(() => arg);
            Func<int, Either<Exception, double>> Subtraction = arg => Try<double>.Cath(() => arg - 2);
            Func<decimal, Either<Exception, decimal>> Division = arg => Try<decimal>.Cath(() => arg / 2);
            Func<int, Either<Exception, int>> Multiplication = arg => Try<int>.Cath(() => arg * 3);
            
            // Act
            var result = Sum(v1 + v2 + v3 + v4)
                .Bind(resultSum => Subtraction(resultSum))
                .Bind(resultSubtraction => Division(decimal.Parse(resultSubtraction.ToString())))
                .Bind(resultDivision => Multiplication(int.Parse(resultDivision.ToString())))
                .Match(left: error => HandleError(error), right: r => r);
            
            // Assert's
            result.Should().Be(expected);
        }
```



Em resumo, o propósito do pattern **Either** é fornecer uma estrutura de dados que torna mais claro e robusto o tratamento de resultados com dois caminhos possíveis, como sucesso ou falha, sem depender excessivamente de exceções. Isso pode levar a código mais seguro, legível e manutenível, especialmente em linguagens que não suportam tipos de retorno múltiplos diretamente.