using System.Collections.Generic;

namespace Arachne.API.Utilities.Option
{
    public static class DictionaryExtensions
    {
        public static Option<TValue> TryGetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key) =>
            dictionary.TryGetValue(key, out var value)
                ? (Option<TValue>)new Some<TValue>(value)
                : None.Value;
    }
}
