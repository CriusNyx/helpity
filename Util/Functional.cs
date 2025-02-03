using System;
using UnityEngine;

namespace Helpity
{
  public static class Functional
  {
    public static U[] Map<T, U>(this T[] arr, Func<T, U> func)
    {
      return arr.Map((x, i) => func(x));
    }

    public static U[] Map<T, U>(this T[] arr, Func<T, int, U> func)
    {
      U[] output = new U[arr.Length];
      for (var i = 0; i < arr.Length; i++)
      {
        output[i] = func(arr[i], i);
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

    public static Vector3Int Map(this Vector3Int vec, Func<int, int> func)
    {
      return new Vector3Int(func(vec.x), func(vec.y), func(vec.z));
    }

    public static (T, U)[] Zip<T, U>(this T[] arr, U[] other)
    {
      if (arr.Length != other.Length)
      {
        throw new ArgumentException("Arrays must be same length");
      }
      var output = new (T, U)[arr.Length];
      for (int i = 0; i < arr.Length; i++)
      {
        output[i] = (arr[i], other[i]);
      }
      return output;
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

      // TODO: This is wrong?
      return arr[offset + index % _len];
    }

    public static (T, T) GetCirc2<T>(this T[] arr, int index, int? length = null, int offset = 0)
    {
      return (arr.GetCirc(index, length, offset), arr.GetCirc(index + 1, length, offset));
    }

    public static U Reduce<T, U>(this T[] array, Func<U, T, U> reducer, U initialValue)
    {
      var acc = initialValue;
      foreach (var element in array)
      {
        acc = reducer(acc, element);
      }
      return acc;
    }

    public static T First<T>(this T[] arr, Func<T, bool> search)
    {
      foreach (var element in arr)
      {
        if (search(element))
        {
          return element;
        }
      }
      return default;
    }

    public static U First<T, U>(this (T a, U b)[] arr, T key)
    {
      foreach (var (a, b) in arr)
      {
        if (Equals(a, key))
        {
          return b;
        }
      }
      return default;
    }

    /// <summary>
    /// Given an element, create an array of length len filled entirely with that element.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="len"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T[] FillArray<T>(this T value, int len)
    {
      T[] output = new T[len];
      for (int i = 0; i < len; i++)
      {
        output[i] = value;
      }
      return output;
    }

    public static T[] Push<T>(this T[] arr, T newElement)
    {
      var output = new T[arr.Length + 1];
      Array.Copy(arr, output, arr.Length);
      output[arr.Length] = newElement;
      return output;
    }

    public static T[] Enqueue<T>(this T[] arr, T newElement)
    {
      var output = new T[arr.Length + 1];
      output[0] = newElement;
      Array.Copy(arr, 0, output, 1, arr.Length);
      return output;
    }

    public static T SafeGet<T>(this T[] arr, int index)
    {
      return arr[MoreMath.PosMod(index, arr.Length)];
    }

    public static void SafeSet<T>(this T[] arr, int index, T element)
    {
      arr[MoreMath.PosMod(index, arr.Length)] = element;
    }

    public static void SafeSet<T>(this T[] arr, int index, Func<T, T> setter)
    {
      var i = MoreMath.PosMod(index, arr.Length);
      arr[i] = setter(arr[i]);
    }

    public static bool Safe<T>(this (bool, T) tuple, out T result)
    {
      var (a, b) = tuple;
      if (a)
      {
        result = b;
        return true;
      }
      else
      {
        result = default;
        return false;
      }
    }

    public static (T, U) With<T, U>(this T value, U element)
    {
      return (value, element);
    }
  }
}
