using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Helpity
{
  public static class SetExtensions
  {
    public static void Include<T>(this ISet<T> set, T value)
    {
      if (!set.Contains(value))
      {
        set.Add(value);
      }
    }

    public static U Safe<T, U>(this IDictionary<T, U> dict, T key, U defaultReturn = default)
    {
      if (dict.TryGetValue(key, out var output))
      {
        return output;
      }
      return defaultReturn;
    }

    public static U GetOrSet<T, U>(this IDictionary<T, U> dict, T key, Func<U> setter = null)
    {
      setter = setter ?? (() => default);

      if (dict.TryGetValue(key, out var output))
      {
        return output;
      }
      else
      {
        output = setter();
        dict[key] = output;
        return output;
      }
    }

    /// <summary>
    /// Synchronize a dictionary with a set of live keys.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="liveKeys"></param>
    /// <param name="Create"></param>
    /// <param name="Destroy"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    public static void Sync<T, U>(
      this IDictionary<T, U> dictionary,
      IEnumerable<T> liveKeys,
      Func<T, U> Create,
      Action<T, U> Destroy = null
    )
    {
      var (newElements, oldElements) = liveKeys.ToArray().BiDiff(dictionary.Keys.ToArray());
      foreach (var newElement in newElements)
      {
        dictionary.Add(newElement, Create(newElement));
      }
      foreach (var oldKey in oldElements)
      {
        var oldValue = dictionary[oldKey];
        Destroy?.Invoke(oldKey, oldValue);
        dictionary.Remove(oldKey);
      }
    }
  }
}
