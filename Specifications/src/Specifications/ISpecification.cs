﻿namespace Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate);
    ISpecification<T> And(ISpecification<T> other);
    ISpecification<T> Or(ISpecification<T> other);
    ISpecification<T> Not();
    ISpecification<T> Not(ISpecification<T> other);
    ISpecification<T> Contains<TValue>(Func<T, IEnumerable<TValue>> valueSelector, TValue targetValue);
}