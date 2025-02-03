using System;
using System.Collections.Generic;
using UnityEngine;

namespace Helpity
{
  public static class Ittr
  {
    private static Func<int, bool> GenerateCond(int length, bool inclusive)
    {
      return inclusive ? (i) => i <= length : (i) => i < length;
    }

    public static IEnumerable<int> Range(int length, bool inclusive = false)
    {
      Func<int, bool> Cond = GenerateCond(length, inclusive);

      for (int i = 0; Cond(i); i++)
      {
        yield return i;
      }
    }

    public static IEnumerable<(int, int)> Range2(int len1, int len2, bool inclusive = false)
    {
      Func<int, bool> Cond1 = GenerateCond(len1, inclusive);
      Func<int, bool> Cond2 = GenerateCond(len2, inclusive);

      for (int i = 0; Cond1(i); i++)
      {
        for (int j = 0; Cond2(j); j++)
        {
          yield return (i, j);
        }
      }
    }

    public static IEnumerable<(int, int, int)> Range3(
      int len1,
      int len2,
      int len3,
      bool inclusive = false
    )
    {
      Func<int, bool> Cond1 = GenerateCond(len1, inclusive);
      Func<int, bool> Cond2 = GenerateCond(len2, inclusive);
      Func<int, bool> Cond3 = GenerateCond(len3, inclusive);

      for (int i = 0; Cond1(i); i++)
      {
        for (int j = 0; Cond2(j); j++)
        {
          for (int k = 0; Cond3(k); k++)
          {
            yield return (i, j, k);
          }
        }
      }
    }

    /// <summary>
    /// Iterate between the start points [inclusive] and end points [inclusive]
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public static IEnumerable<(int, int)> Span2(int start, int end) =>
      Span2(start, end, start, end);

    /// <summary>
    /// Iterate between the start points [inclusive] and end points [inclusive]
    /// </summary>
    /// <param name="start1"></param>
    /// <param name="end1"></param>
    /// <param name="start2"></param>
    /// <param name="end2"></param>
    public static IEnumerable<(int, int)> Span2(int start1, int end1, int start2, int end2)
    {
      for (int i = start1; i <= end1; i++)
      {
        for (int j = start2; j <= end2; j++)
        {
          yield return (i, j);
        }
      }
    }

    /// <summary>
    /// Iterate between the start points [inclusive] and end points [inclusive]
    /// </summary>
    /// <param name="start1"></param>
    /// <param name="end1"></param>
    /// <param name="start2"></param>
    /// <param name="end2"></param>
    /// <param name="start3"></param>
    /// <param name="end3"></param>
    public static IEnumerable<(int, int, int)> Span3(
      int start1,
      int end1,
      int start2,
      int end2,
      int start3,
      int end3
    )
    {
      for (int i = start1; i <= end1; i++)
      {
        for (int j = start2; j <= end2; j++)
        {
          for (int k = start3; k <= end3; k++)
          {
            yield return (i, j, k);
          }
        }
      }
    }

    /// <summary>
    ///  Iterate between min [inclusive] and max [inclusive]
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static IEnumerable<Vector3Int> Span3(Vector3Int min, Vector3Int max)
    {
      for (int i = min.x; i <= max.x; i++)
      {
        for (int j = min.y; j <= max.y; j++)
        {
          for (int k = min.z; k <= max.z; k++)
          {
            yield return new Vector3Int(i, j, k);
          }
        }
      }
    }
  }
}
