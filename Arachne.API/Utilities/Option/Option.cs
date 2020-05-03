using System;

namespace Arachne.API.Utilities.Option
{
    public abstract class Option<T>
    {
        public static implicit operator Option<T>(T value) =>
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();

        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);

        public abstract void Map(Action<T> map);

        // Applies a function over an optional argument. When applied to a Some<T> it applies the function to T, when applied
        // to a None it returns None.
        public abstract Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map);

        public abstract T Reduce(T whenNone);

        public abstract T Reduce(Func<T> whenNone);

        public Option<TNew> OfType<TNew>()
            where TNew : class
            =>
            this is Some<T> some && typeof(TNew).IsAssignableFrom(typeof(T))
                ? (Option<TNew>)new Some<TNew>(some.Content as TNew)
                : None.Value;
    }
}
