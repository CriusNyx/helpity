using System;

namespace Helpity
{
  public static class Functional
  {
    public static U[] Map<T, U>(this T[] arr, Func<T, U> func)
    {
      U[] output = new U[arr.Length];
      for (var i = 0; i < arr.Length; i++)
      {
        output[i] = func(arr[i]);
      }
      return output;
    }

    public static (U, U) Map<T, U>(this (T, T) tuple, Func<T, U> func)
    {
      return (func(tuple.Item1), func(tuple.Item2));
    }

    public static (U, U, U) Map<T, U>(this (T, T, T) tuple, Func<T, U> func)
    {
      return (func(tuple.Item1), func(tuple.Item2), func(tuple.Item3));
    }

    public static T Get<T>(this T[] arr, int index, int offset = 0)
    {
      return arr[offset + index];
    }

    public static (T, T) Get2<T>(this T[] arr, int index, int offset = 0)
    {
      return (arr.Get(index, offset), arr.Get(index + 1, offset));
    }

    public static T GetCirc<T>(this T[] arr, int index, int? length = null, int offset = 0)
    {
      var _len = length ?? arr.Length - offset;

      return arr[offset + index % _len];
    }

    public static (T, T) GetCirc2<T>(this T[] arr, int index, int? length = null, int offset = 0)
    {
      return (arr.GetCirc(index, length, offset), arr.GetCirc(index + 1, length, offset));
    }
  }
}
