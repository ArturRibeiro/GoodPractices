namespace Pattern.Functional.Programming.Extensions
{
    public static class EitherExtension
    {
        // public static Either<Exception, T1> Bind<T1>(
        //     this Either<Exception, T1> @this
        //     //Func<T, Either<Exception, T1>> f
        //     )
        // {
        //     @this.Match()
        // }


        // public static Either<L, RR> Bind<L, R, RR>
        //     (this Either<L, R> either, Func<R, Either<L, RR>> f)
        //     => either.Match(
        //         l => Either<L, RR>.Left(l),
        //         r => f(r));
        //
        // public static Either<L, Unit> ForEach<L, R>
        //     (this Either<L, R> either, Action<R> act)
        //     => Map(either, act.ToFunc());
        //
        // public static Either<L, RR> Map<L, R, RR>
        //     (this Either<L, R> either, Func<R, RR> f)
        //     => either.Match<Either<L, RR>>(
        //         l => Either<L, RR>.Left(l),
        //         r => Either<L, RR>.Right(f(r)));

        /// <summary>
        /// Realiza a operação de ligação (bind) entre um valor do tipo Either<Exception, TInput> 
        /// e uma função que transforma esse valor em um novo Either<Exception, TResult>.
        /// </summary>
        /// <param name="either">O valor Either&lt;Exception, TInput&gt; de entrada.</param>
        /// <param name="func">A função que transforma o valor de entrada em um novo Either<Exception, TResult>.</param>
        /// <typeparam name="TInput">O tipo contido no Either de entrada.</typeparam>
        /// <typeparam name="TResult">O tipo contido no Either resultante.</typeparam>
        /// <returns></returns>
        public static Either<Exception, TResult> Bind<TInput, TResult>
        (this Either<Exception, TInput> either
            , Func<TInput, Either<Exception, TResult>> func)
            => either.Match(left => Either<Exception, TResult>.Left(left)
                , right => func(right));
    }
}