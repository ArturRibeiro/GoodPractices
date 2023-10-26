namespace Pattern.Functional.Programming
{
    /// <summary>
    ///     A classe Either representa uma escolha entre dois tipos de valores: falha ou sucesso.
    ///     É usada para tratar operações que podem produzir resultados de erros ou bem-sucedidos de forma explícita,
    ///     evitando o uso excessivo de exceções e tornando o código mais claro e robusto.
    /// </summary>
    /// <typeparam name="TLeft">O tipo de valor para representar a falha ou erro.</typeparam>
    /// <typeparam name="TRight">O tipo de valor para representar o sucesso.</typeparam>
    public class Either<TLeft, TRight>
    {
        public static Either<TLeft, TRight> Left(TLeft left) => new(left);
        public static Either<TLeft, TRight> Right(TRight right) => new(right);
        
        private TLeft _left;
        private TRight _right;
        private bool _isLeft;

        private Either(TLeft left)
        {
            this._left = left;
            this._isLeft = true;
        }

        private Either(TRight right)
        {
            this._right = right;
            this._isLeft = false;
        }

        protected Either()
        {
        }
        public virtual TResult Match<TResult>
            (Func<TLeft, TResult> left, Func<TRight, TResult> right)
            => _isLeft
                ? left(this._left)
                : right(this._right);
    }
}