using System.Collections.Generic;

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
  }
}
