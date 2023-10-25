namespace Pattern.Functional.Programming
{
    /// <summary>
    ///     A classe Left representa um retorno com falha de forma explícita.
    /// </summary>
    /// <typeparam name="TLeft">O tipo de valor para representar a falha ou erro.</typeparam>
    /// <typeparam name="TRight">O tipo de valor para representar o sucesso.</typeparam>
    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TLeft _value;

        public Left(TLeft left) => this._value = left;

        public override TResult Match<TResult>(Func<TLeft, TResult> left, Func<TRight, TResult> right) => left(this._value);
    }
}