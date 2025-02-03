using System.Collections.Generic;
using Helpity;
using Unity.VisualScripting.YamlDotNet.Serialization.ValueDeserializers;

public static class ArrayExtensions
{
  public static T Head<T>(this T[] arr)
  {
    return arr[0];
  }

  public static T Tail<T>(this T[] arr)
  {
    return arr[arr.Length - 1];
  }

  public static (T, T)[] Edges<T>(this T[] arr)
  {
    var output = new (T, T)[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
      output[i] = (arr[i], arr[(i + 1) % arr.Length]);
    }
    return output;
  }

  public static int IndexOf<T>(this T[] arr, T element)
  {
    for (int i = 0; i < arr.Length; i++)
    {
      if (Equals(arr[i], element))
      {
        return i;
      }
    }
    return -1;
  }

  /// <summary>
  /// Returns the set of elements that exist only in source.
  /// </summary>
  /// <param name="source"></param>
  /// <param name="other"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T[] Diff<T>(this T[] source, T[] other)
  {
    HashSet<T> otherSet = new HashSet<T>(other);
    List<T> output = new List<T>();
    foreach (var element in source)
    {
      if (!otherSet.Contains(element))
      {
        output.Add(element);
      }
    }
    return output.ToArray();
  }

  /// <summary>
  /// Return the set of elements in the source or other only.
  /// </summary>
  /// <param name="sourceOnly"></param>
  /// <param name="source"></param>
  /// <param name="other"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static (T[] sourceOnly, T[] otherOnly) BiDiff<T>(this T[] source, T[] other)
  {
    return (source.Diff(other), other.Diff(source));
  }
}
