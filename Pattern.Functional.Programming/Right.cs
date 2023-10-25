namespace Pattern.Functional.Programming
{
    /// <summary>
    ///     A classe Right representa um retorno com sucesso.
    /// </summary>
    /// <typeparam name="TLeft">O tipo de valor para representar a falha ou erro.</typeparam>
    /// <typeparam name="TRight">O tipo de valor para representar o sucesso.</typeparam>
    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TRight _value;

        public Right(TRight value) => this._value = value;

        public override TResult Match<TResult>(Func<TLeft, TResult> left, Func<TRight, TResult> right) => right(this._value);
    }
}